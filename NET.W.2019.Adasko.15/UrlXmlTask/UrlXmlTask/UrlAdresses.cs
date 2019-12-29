using System.Xml.Serialization;

namespace UrlXmlTask
{
    [XmlRoot(ElementName = "urlAddresses", IsNullable = false)]
    public class UrlAdresses
    {
        [XmlElement("urlAddress")]
        public UrlAddress[] Adresses { get; set; }
    }

    public class UrlAddress
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
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }
    }
}
