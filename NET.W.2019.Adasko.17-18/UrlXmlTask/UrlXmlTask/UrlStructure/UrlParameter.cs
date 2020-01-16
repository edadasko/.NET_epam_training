//-----------------------------------------------------------------------
// <copyright file="UrlParameter.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask.UrlStructure
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents parameter of url.
    /// </summary>
    public class UrlParameter
    {
        /// <summary>
        /// Gets or sets value of the parameter.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets key of the parameter.
        /// </summary>
        [XmlAttribute("key")]
        public string Key { get; set; }
    }
}
