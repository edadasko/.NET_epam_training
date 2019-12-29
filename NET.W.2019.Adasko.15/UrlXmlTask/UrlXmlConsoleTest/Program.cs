using System;
using UrlXmlTask;

namespace UrlXmlConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = UrlConverter.Convert("https://github.com/AnzhelikaKravchuk?tab=repositories");
        }
    }
}
