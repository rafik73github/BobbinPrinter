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

        public void XMLAddElement()
        {
            XDocument document = XDocument.Load("textills.xml");
            document.Element("textills").Add(
                new XElement("textill",
                        new XElement("maker", "Skrętka"),
                        new XElement("stuff", "AB50/50"),
                        new XElement("color", "Biały")
                ));
            document.Save("textills.xml");
        }

        public void XMLchange()
        {
            XDocument document = XDocument.Load("textills.xml");

            var records = document.Root.Elements("textill").Where(
                record => record.Element("color").Value == "Biały");
            if (records.Any())
                records.First().Element("color").Value = "Różowy";

            document.Save("textills.xml");
        }

    }

    
    
}
