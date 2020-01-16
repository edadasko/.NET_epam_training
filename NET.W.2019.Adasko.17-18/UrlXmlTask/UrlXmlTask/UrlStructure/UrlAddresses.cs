//-----------------------------------------------------------------------
// <copyright file="UrlAddresses.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask.UrlStructure
{
    using System.Xml.Serialization;

    /// <summary>
    /// Repsesents list of url adresses for XML serialization.
    /// </summary>
    [XmlRoot(ElementName = "urlAddresses", IsNullable = false)]
    public class UrlAddresses
    {
        /// <summary>
        /// Gets or sets list of url adresses.
        /// </summary>
        [XmlElement("urlAddress")]
        public UrlAddress[] Adresses { get; set; }
    }
}
