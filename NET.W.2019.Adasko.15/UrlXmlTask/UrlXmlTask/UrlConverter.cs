using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlXmlTask
{
    public static class UrlConverter
    {
        public static UrlAdress Convert(string stringUrl)
        {
            UrlHost host;
            List<string> segments;
            List<UrlParameter> urlParameters;

            try
            {
                var components = stringUrl.Split('/')[2..];

                host = new UrlHost { Name = components[0] };
                segments = components[1..].ToList();
                segments[^1] = segments[^1].Split('?')[0];

                var parameters = components[^1].Split('?')[1].Split('&');

                urlParameters = new List<UrlParameter>();

                foreach (var parameter in parameters)
                {
                    var pair = parameter.Split('=');
                    urlParameters.Add(new UrlParameter { Key = pair[0], Value = pair[1] });
                }
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }

            return new UrlAdress
            {
                Host = host,
                Segments = segments.ToArray(),
                Parameters = urlParameters.ToArray()
            };
        }
    }
}
