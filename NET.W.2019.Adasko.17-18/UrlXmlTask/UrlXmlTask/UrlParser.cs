//-----------------------------------------------------------------------
// <copyright file="UrlConverter.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UrlXmlTask.UrlStructure;

    /// <summary>
    /// Represents helper class for converting url string to UrlAddress class.
    /// </summary>
    public static class UrlParser
    {
        /// <summary>
        /// Converts url string to UrlAddress class.
        /// </summary>
        /// <param name="stringUrl">String to convert.</param>
        /// <returns>Object of UrlAddress.</returns>
        public static UrlAddress Parse(string stringUrl)
        {
            UrlHost host;
            List<string> segments;
            List<UrlParameter> urlParameters;

            try
            {
                var startIndex = stringUrl.IndexOf("://", StringComparison.InvariantCulture);

                if (startIndex == -1)
                {
                    return null;
                }

                var components = stringUrl[(startIndex + "://".Length)..].Split('/');

                host = new UrlHost { Name = components[0] };
                segments = components[1..].ToList();

                if (segments.Count > 0)
                {
                    segments.RemoveAll(s => string.IsNullOrEmpty(s));

                    var lastSegmentAndParameters = segments[^1].Split('?');
                    segments[^1] = lastSegmentAndParameters[0];

                    if (lastSegmentAndParameters.Length > 1)
                    {
                        var parameters = lastSegmentAndParameters[1].Split('&');

                        urlParameters = new List<UrlParameter>();

                        foreach (var parameter in parameters)
                        {
                            var pair = parameter.Split('=');
                            urlParameters.Add(new UrlParameter { Key = pair[0], Value = pair[1] });
                        }
                    }
                    else
                    {
                        urlParameters = null;
                    }
                }
                else
                {
                    segments = null;
                    urlParameters = null;
                }
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
            catch(ArgumentOutOfRangeException)
            {
                return null;
            }

            return new UrlAddress
            {
                Host = host,
                Segments = segments?.ToArray(),
                Parameters = urlParameters?.ToArray()
            };
        }
    }
}
