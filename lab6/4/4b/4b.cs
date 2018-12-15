using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
            myDocument.Load(myStream);
            Console.Write("Get XmlElement:\r\n");
            XmlElement gameElement = (XmlElement)myDocument.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[0];
            gameElement.Attributes["Season"].Value = "100000000";
            myDocument.Save("newXml.xml");
            myStream.Close();
		}
	}
}