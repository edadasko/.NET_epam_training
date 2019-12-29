using System.Xml.Serialization;

namespace UrlXmlTask
{
    public class UrlAdresses
    {
        [XmlArray("urlAdresses")]
        [XmlArrayItem("urlAddress")]
        public UrlAdress[] Adresses { get; set; }
    }

    public class UrlAdress
    {
        [XmlElement("host")]
        public UrlHost Host { get; set; }

        [XmlArray("uri")]
        [XmlArrayItem("segment")]
        public string[] Segments { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parametr")]
        public UrlParameter[] Parameters { get; set; }
    }

    public class UrlHost
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class UrlParameter
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
