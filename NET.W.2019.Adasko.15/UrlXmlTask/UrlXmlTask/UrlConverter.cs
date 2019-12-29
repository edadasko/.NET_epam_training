using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlXmlTask
{
    public static class UrlConverter
    {
        public static UrlAddress Convert(string stringUrl)
        {
            UrlHost host;
            List<string> segments;
            List<UrlParameter> urlParameters;

            try
            {
                var components = stringUrl.Split('/')[2..];

                host = new UrlHost { Name = components[0] };
                segments = components[1..].ToList();
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
                Segments = segments.ToArray(),
                Parameters = urlParameters?.ToArray()
            };
        }
    }
}
