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
            // Reading all in root/row
            Console.Write("Read data from XML...\r\n");
            XDocument xdoc = XDocument.Load("../../../task2.xml");
            var query = from xe in xdoc.Elements("root").Elements("row")
            select xe;

            foreach (XElement item in query)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
