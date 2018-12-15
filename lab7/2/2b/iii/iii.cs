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
            XElement row = new XElement("row");
            XElement title = new XElement("Title", "TestTitle");
            XElement variety = new XElement("Variety", "TestVariety");
            XElement price = new XElement("Price", "TestPrice");
            XDocument xdoc = XDocument.Load("../../../task2.xml");

            row.Add(title);
            row.Add(variety);
            row.Add(price);

            var query = from root in xdoc.Elements("root")
            select root;

            // Here I add row to my DOM
            query.ElementAt(0).Add(row);

            foreach (XElement item in query)
            {
                Console.WriteLine(item);
            }

        }
    }
}
