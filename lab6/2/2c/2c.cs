using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
			myDocument.Load(myStream);
            XmlNodeList summerGames = myDocument.SelectNodes("//participantList/Participant[@Team='Russia']/Game[@Season='Summer']");
			for (int i = 0; i < summerGames.Count; ++i) {
				Console.Write(summerGames[i].Attributes["YearG"].Value + "\r\n");
			}
			myStream.Close();
		}
	}
}