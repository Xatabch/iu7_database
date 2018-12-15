using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
			myDocument.Load(myStream);
            XmlNode summerGames = myDocument.SelectSingleNode("//participantList/Participant[@Team='Russia']/Game[@Season='Summer']");
			Console.Write(summerGames.Attributes["City"].Value + "\r\n");
			myStream.Close();
		}
	}
}