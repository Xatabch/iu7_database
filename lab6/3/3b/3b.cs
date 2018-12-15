using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("test.xml", FileMode.Open);
            myDocument.Load(myStream);
            Console.Write(myDocument.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[0].Value + "\r\n");
            myStream.Close();
		}
	}
}