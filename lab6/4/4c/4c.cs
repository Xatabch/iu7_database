using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
            myDocument.Load(myStream);
            XmlElement newGameElement = myDocument.CreateElement("Game");
            newGameElement.SetAttribute("Game_id", "2323");
            newGameElement.SetAttribute("YearG", "4015");
            newGameElement.SetAttribute("Season", "Winter");
            newGameElement.SetAttribute("City", "London");
            XmlElement gameElement = (XmlElement)myDocument.DocumentElement.ChildNodes[0].ChildNodes[0];
            gameElement.AppendChild(newGameElement);
            myDocument.Save("newXml.xml");
            myStream.Close();
		}
	}
}