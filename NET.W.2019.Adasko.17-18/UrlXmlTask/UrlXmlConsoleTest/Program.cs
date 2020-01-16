//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace UrlXmlConsoleTest
{
    using System;
    using System.IO;
    using UrlXmlTask;

    /// <summary>
    /// Main class in the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Reads file with URLs and creates new XML document with these URLs.
        /// </summary>
        public static void Main()
        {
            using FileStream fileStream = new FileStream("urls.txt", FileMode.Open, FileAccess.Read);
            UrlXmlWriter writer = new UrlXmlWriter(fileStream, "xml_urls.xml");
            writer.Write();

            Console.WriteLine("XML has been created.");
        }
    }
}
