using System;
using System.IO;
using UrlXmlTask;

namespace UrlXmlConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream("urls.txt", FileMode.Open, FileAccess.Read);
            UrlXmlWriter writer = new UrlXmlWriter(fileStream, "xml_urls.xml");
            writer.Write();
        }
    }
}
