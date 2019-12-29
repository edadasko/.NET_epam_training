using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace UrlXmlTask
{
    public class UrlXmlWriter
    {
        private readonly UrlAdresses urlAdresses;
        private readonly string outputPath;

        public UrlXmlWriter(FileStream fileStream, string outputPath)
        {
            this.outputPath = outputPath;

            List<UrlAdress> adresses = GetAdressesFromFile(fileStream);
               
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

        private List<UrlAdress> GetAdressesFromFile(FileStream fileStream)
        {
            List<UrlAdress> adresses = new List<UrlAdress>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string urlString = reader.ReadLine();
                while (urlString != null)
                {
                    adresses.Add(UrlConverter.Convert(urlString));
                    urlString = reader.ReadLine();
                }
            }
            return adresses;
        }
    }
}
