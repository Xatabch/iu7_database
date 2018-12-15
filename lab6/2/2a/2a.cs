using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
			myDocument.Load(myStream);
			Console.Write("Get element Participant\r\n");
			XmlNodeList participants = myDocument.GetElementsByTagName("Participant");
			for (int i = 0; i < participants.Count; i++) {
				Console.Write(participants[i].ChildNodes[0].Attributes["Season"].Value + "\r\n");
			}
		}
	}
}