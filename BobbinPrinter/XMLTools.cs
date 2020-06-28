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
            tS.Add(new Textills("Frafil A100", "Czarny"));
            tS.Add(new Textills("TVU AB50/50", "Navy-Mel. 360"));
            tS.Add(new Textills("Skrętka AB50/50", "Popiel"));

            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista przędz"),
                new XElement("textills",
                    from record in tS
                    orderby record.TextillMaker
                    select new XElement("textill",
                        new XElement("maker", record.TextillMaker),
                        new XElement("color", record.TextillColor)
                        )
                    )
                );

            xml.Save("textills.xml");
        }
        */

        //TODO: add XElements: yarntypes, yarnsizes
        public void XMLcreate()
        {
            
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista przędz"),
                new XElement("database",
                new XElement("yarns"),
                new XElement("makers")
                )
                );

            xml.Save("yarns.xml");
        }

        // TODO: add XElements: type, size
        public void XMLAddElementYarn(string maker, string color)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("yarns").Add(
                new XElement("yarn",
                        new XElement("maker", maker),
                        new XElement("color", color)
                ));
            document.Save("yarns.xml");
        }

        public void XMLAddElementMaker(string maker)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("makers").Add(
                  new XElement("maker",
                  new XElement("makerName", maker)
                  ));
            document.Save("yarns.xml");
        }

        public void XMLEditElement(string nodeName, string elementName, string currentValue, string newValue)
        {
            XDocument document = XDocument.Load("yarns.xml");

            var records = document.Root.Elements(nodeName).Where(
                record => record.Element(elementName).Value == currentValue);
            if (records.Any())
                records.First().Element(elementName).Value = newValue;

            document.Save("yarns.xml");
        }

        public List<Makers> XMLToSelectYarnMakerComboBox()
        {
            XDocument document = XDocument.Load("yarns.xml");
            List<Makers> makersList = (from xml in document.Elements("database").Elements("makers").Elements("maker")
                                       select new Makers(

              xml.Element("makerName").Value
              )
                  ).ToList<Makers>();

            return makersList;
        }

    }

    
    
}
