//-----------------------------------------------------------------------
// <copyright file="UrlXmlWriter.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using NLog;
    using UrlXmlTask.UrlStructure;

    /// <summary>
    /// Repsesents class for creating XML document from file with URL strings.
    /// </summary>
    public class UrlXmlWriter
    {
        /// <summary>
        /// Converted Url addresses from strings from file.
        /// </summary>
        private readonly UrlAddresses urlAdresses;

        /// <summary>
        /// Output path for XML document.
        /// </summary>
        private readonly string outputPath;

        /// <summary>
        /// NLogger for logging result of converting.
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlXmlWriter"/> class.
        /// </summary>
        /// <param name="fileStream">FileStream for file with URL strings.</param>
        /// <param name="outputPath">Output path for XML document.</param>
        public UrlXmlWriter(FileStream fileStream, string outputPath)
        {
            this.outputPath = outputPath;

            List<UrlAddress> adresses = this.GetAdressesFromFile(fileStream);
               
            this.urlAdresses = new UrlAddresses
            {
                Adresses = adresses.ToArray()
            };
        }

        /// <summary>
        /// Creates or rewrites XML file with URLs.
        /// </summary>
        public void Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrlAddresses));
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            using StreamWriter writer = new StreamWriter(this.outputPath);
            serializer.Serialize(writer, this.urlAdresses, xns);
        }

        /// <summary>
        /// Retrieves and converts URLs from file.
        /// </summary>
        /// <param name="fileStream">FileStream for file with URLs.</param>
        /// <returns>List of UrlAddress objects.</returns>
        private List<UrlAddress> GetAdressesFromFile(FileStream fileStream)
        {
            List<UrlAddress> adresses = new List<UrlAddress>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string urlString = reader.ReadLine();
                while (urlString != null)
                {
                    UrlAddress address = UrlParser.Parse(urlString);
                    if (address != null)
                    {
                        adresses.Add(UrlParser.Parse(urlString));
                        this.logger.Info(urlString + " was succesfully written.");
                    }
                    else
                    {
                        this.logger.Error(urlString + " was not written.");
                    }

                    urlString = reader.ReadLine();
                }
            }

            return adresses;
        }
    }
}
