using System;
using System.IO;
using System.Xml;

namespace Wrox {
	class consoleApp {
		static void Main(string[] args) {
			XmlDocument myDocument = new XmlDocument();
			FileStream myStream = new FileStream("../../task1-explicit.xml", FileMode.Open);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            settings.DtdProcessing = DtdProcessing.Parse;
			XmlReader reader = XmlReader.Create(myStream, settings);
            myDocument.Load(reader);
            XmlElement participant = myDocument.GetElementById("2");
            for(int i = 0; i < participant.ChildNodes.Count; i++){
                Console.Write(participant.ChildNodes[i].Attributes["City"].Value + "\r\n");
            }
            myStream.Close();
            
		}
	}
}