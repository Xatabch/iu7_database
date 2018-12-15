using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
            myDocument.Load(myStream);
            XmlElement Element = (XmlElement)myDocument.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[0];
            Element.SetAttribute("attr", "NEWATTR");
            myDocument.Save("newXml.xml");
            myStream.Close();
		}
	}
}