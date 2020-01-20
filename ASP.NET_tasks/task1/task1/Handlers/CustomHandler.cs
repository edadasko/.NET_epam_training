using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace task1.Handlers
{
    public class CustomHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<h1>Custom Handler</h1>");
        }
    }
}