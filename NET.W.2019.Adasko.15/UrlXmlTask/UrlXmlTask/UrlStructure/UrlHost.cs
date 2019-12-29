//-----------------------------------------------------------------------
// <copyright file="UrlHost.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask.UrlStructure
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents host of url.
    /// </summary>
    public class UrlHost
    {
        /// <summary>
        /// Gets or sets name of the host.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
