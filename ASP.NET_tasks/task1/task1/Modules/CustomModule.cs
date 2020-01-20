using System;
using System.IO;
using System.Web;

namespace task1.Modules
{
    public class CustomModule : IHttpModule
    {
        private const string FilePath = "log.txt";
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.HandleBeginRequest);
            context.EndRequest += new EventHandler(this.HandleEndRequest);
        }

        public void HandleEndRequest(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(FilePath), true))
            {
                sw.WriteLine("End request called at " + DateTime.Now.ToString());
            }
        }

        public void HandleBeginRequest(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(FilePath), true))
            {
                sw.WriteLine("Begin request called at " + DateTime.Now.ToString());
            }
        }
    }
}