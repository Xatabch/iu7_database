using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace validator
{
    class Program
    {
        static void Main()
        {
            XmlReaderSettings bandsSettings = new XmlReaderSettings();
            bandsSettings.Schemas.Add("wnd", "wine.xsd");
            bandsSettings.ValidationType = ValidationType.Schema;
            bandsSettings.ValidationEventHandler += new ValidationEventHandler(bandsSettingsValidationEventHandler);
            XmlReader bands = XmlReader.Create("tests/bad_wine4.xml", bandsSettings);
            while (bands.Read()) { }
            Console.WriteLine("OK");
        }

        static void bandsSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
