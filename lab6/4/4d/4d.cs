using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
            myDocument.Load(myStream);

            XmlElement Participant = myDocument.CreateElement("Participant");
            XmlElement newGameElement1 = myDocument.CreateElement("Game");
            XmlElement newGameElement2 = myDocument.CreateElement("Game");
            XmlElement newGameElement3 = myDocument.CreateElement("Game");

            newGameElement1.SetAttribute("Game_id", "2323");
            newGameElement1.SetAttribute("YearG", "4015");
            newGameElement1.SetAttribute("Season", "Winter");
            newGameElement1.SetAttribute("City", "London");

            newGameElement2.SetAttribute("Game_id", "89234");
            newGameElement2.SetAttribute("YearG", "4020");
            newGameElement2.SetAttribute("Season", "Summer");
            newGameElement2.SetAttribute("City", "Kindom");

            newGameElement3.SetAttribute("Game_id", "3333");
            newGameElement3.SetAttribute("YearG", "4019");
            newGameElement3.SetAttribute("Season", "Autumn");
            newGameElement3.SetAttribute("City", "Russian");

            Participant.AppendChild(newGameElement1);
            Participant.AppendChild(newGameElement2);
            Participant.AppendChild(newGameElement3);

            XmlElement Element = (XmlElement)myDocument.DocumentElement.ChildNodes[0];
            Element.AppendChild(Participant);
            myDocument.Save("newXml.xml");
            myStream.Close();
		}
	}
}