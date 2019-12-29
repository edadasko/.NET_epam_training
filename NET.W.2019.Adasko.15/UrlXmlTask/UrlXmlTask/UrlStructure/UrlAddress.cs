//-----------------------------------------------------------------------
// <copyright file="UrlAddress.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask.UrlStructure
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents url adress.
    /// </summary>
    public class UrlAddress
    {
        /// <summary>
        /// Gets or sets host of the url.
        /// </summary>
        [XmlElement("host")]
        public UrlHost Host { get; set; }

        /// <summary>
        /// Gets or sets url segments.
        /// </summary>
        [XmlArray("uri")]
        [XmlArrayItem("segment")]
        public string[] Segments { get; set; }

        /// <summary>
        /// Gets or sets parameters of the url.
        /// </summary>
        [XmlArray("parameters")]
        [XmlArrayItem("parametr")]
        public UrlParameter[] Parameters { get; set; }
    }
}
