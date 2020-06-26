using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BobbinPrinter
{
    class XMLTools
    {

        /*
        public void XMLcreate()
        {
            List<Textills> tS = new List<Textills>();
            tS.Add(new Textills("Frafil", "A100", "Czarny"));
            tS.Add(new Textills("TVU", "AB50/50", "Navy-Mel. 360"));
            tS.Add(new Textills("Skrętka", "AB50/50", "Popiel"));

            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista przędz"),
                new XElement("textills",
                    from record in tS
                    orderby record.TextillMaker
                    select new XElement("textill",
                        new XElement("maker", record.TextillMaker),
                        new XElement("stuff", record.TextillStuff),
                        new XElement("color", record.TextillColor)
                        )
                    )
                );

            xml.Save("textills.xml");
        }
        */

        public void XMLcreate()
        {
            
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista przędz"),
                new XElement("database",
                new XElement("textills"),
                new XElement("makers")
                )
                );

            xml.Save("textills.xml");
        }

        public void XMLAddElementTextill(string maker, string stuff, string color)
        {
            XDocument document = XDocument.Load("textills.xml");
            document.Element("database").Element("textills").Add(
                new XElement("textill",
                        new XElement("maker", maker),
                        new XElement("stuff", stuff),
                        new XElement("color", color)
                ));
            document.Save("textills.xml");
        }

        public void XMLAddElementMaker(string maker)
        {
            XDocument document = XDocument.Load("textills.xml");
            document.Element("database").Element("makers").Add(
                  new XElement("maker", maker)
                  );
            document.Save("textills.xml");
        }

        public void XMLEditElement(string nodeName, string elementName, string currentValue, string newValue)
        {
            XDocument document = XDocument.Load("textills.xml");

            var records = document.Root.Elements(nodeName).Where(
                record => record.Element(elementName).Value == currentValue);
            if (records.Any())
                records.First().Element(elementName).Value = newValue;

            document.Save("textills.xml");
        }

    }

    
    
}
