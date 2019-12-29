using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NLog;

namespace UrlXmlTask
{
    public class UrlXmlWriter
    {
        private readonly UrlAdresses urlAdresses;
        private readonly string outputPath;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UrlXmlWriter(FileStream fileStream, string outputPath)
        {
            this.outputPath = outputPath;

            List<UrlAddress> adresses = GetAdressesFromFile(fileStream);
               
            urlAdresses = new UrlAdresses
            {
                Adresses = adresses.ToArray()
            };
        }

        public void Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UrlAdresses));
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            using StreamWriter writer = new StreamWriter(outputPath);
            serializer.Serialize(writer, urlAdresses, xns);
        }

        private List<UrlAddress> GetAdressesFromFile(FileStream fileStream)
        {
            List<UrlAddress> adresses = new List<UrlAddress>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string urlString = reader.ReadLine();
                while (urlString != null)
                {
                    UrlAddress address = UrlConverter.Convert(urlString);
                    if (address != null)
                    {
                        adresses.Add(UrlConverter.Convert(urlString));
                        logger.Info(urlString + " was succesfully written.");
                    }
                    else
                    {
                        logger.Error(urlString + " was not written.");
                    }
                    urlString = reader.ReadLine();
                }
            }
            return adresses;
        }
    }
}
