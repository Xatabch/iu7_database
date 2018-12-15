using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Wrox
{
    class consoleApp
    {
        static void Main(string[] args)
        {
            // Change data in XML
            Console.Write("Read data from XML...\r\n");
            XDocument xdoc = XDocument.Load("../../../task2.xml");
            var query = from doc in xdoc.Elements("root").Elements("row")
            where doc.Attribute("ID").Value == "2"
            select doc;

            XElement a = query.ElementAt(0).Element("Title");
            a.SetValue("20");

            foreach (XElement item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(xdoc);

        }
    }
}
