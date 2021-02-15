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
            
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista przędz"),
                new XElement("database",
                new XElement("yarnmakers"),
                new XElement("yarntypes"),
                new XElement("yarnsizes"),
                new XElement("yarns")
                )
                );

            xml.Save("yarns.xml");
        }

        
        public void XMLAddYarn(string maker, string type, string size, string color)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("yarns").Add(
                new XElement("yarn",
                        new XElement("maker", maker),
                        new XElement("type", type),
                        new XElement("size", size),
                        new XElement("color", color)
                ));
            document.Save("yarns.xml");
        }

        public void XMLAddMaker(string maker)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("yarnmakers").Add(
                  new XElement("yarnmaker",
                  new XElement("makerName", maker)
                  ));
            document.Save("yarns.xml");
        }

        public void XMLAddType(string type)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("yarntypes").Add(
                  new XElement("yarntype",
                  new XElement("typeName", type)
                  ));
            document.Save("yarns.xml");
        }

        public void XMLAddSize(string size)
        {
            XDocument document = XDocument.Load("yarns.xml");
            document.Element("database").Element("yarnsizes").Add(
                  new XElement("yarnsize",
                  new XElement("sizeName", size)
                  ));
            document.Save("yarns.xml");
        }

        

        public List<YarnmakersModel> XMLToSelectYarnMakerComboBox()
        {
            XDocument document = XDocument.Load("yarns.xml");
            List<YarnmakersModel> makersList = (from xml in document.Elements("database").Elements("yarnmakers").Elements("yarnmaker")
                                       select new YarnmakersModel(

              xml.Element("makerName").Value
              )
                  ).ToList<YarnmakersModel>();

            return makersList;
        }

        public List<YarntypesModel> XMLToSelectYarnTypeComboBox()
        {
            XDocument document = XDocument.Load("yarns.xml");
            List<YarntypesModel> typesList = (from xml in document.Elements("database").Elements("yarntypes").Elements("yarntype")
                                       select new YarntypesModel(

              xml.Element("typeName").Value
              )
                  ).ToList<YarntypesModel>();

            return typesList;
        }

        public List<YarnsizesModel> XMLToSelectYarnSizeComboBox()
        {
            XDocument document = XDocument.Load("yarns.xml");
            List<YarnsizesModel> sizesList = (from xml in document.Elements("database").Elements("yarnsizes").Elements("yarnsize")
                                     select new YarnsizesModel(

            xml.Element("sizeName").Value
            )
                  ).ToList<YarnsizesModel>();

            return sizesList;
        }

        public List<YarnsModel> XMLToYarnsListView()
        {
            XDocument document = XDocument.Load("yarns.xml");
            List<YarnsModel> yarnsList = (from xml in document.Elements("database").Elements("yarns").Elements("yarn")
                                     select new YarnsModel(

            xml.Element("maker").Value,
            xml.Element("type").Value,
            xml.Element("size").Value,
            xml.Element("color").Value
            )
                 ).ToList<YarnsModel>();

            return yarnsList;
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
        
        public bool XMLIsThereValue(string nodeName, string elementName, string elementValue)
        {
            XDocument document = XDocument.Load("yarns.xml");
            var wantedElement = document.Root.Descendants(nodeName).Where(
                wantedRecord => wantedRecord.Element(elementName).Value == elementValue);
            return wantedElement.Any();
        }

        public bool XMLIsThereColor(string makerValue, string typeValue, string sizeValue, string colorValue)
        {
            XDocument document = XDocument.Load("yarns.xml");
            var wantedElement = document.Root.Descendants("yarn").Where(
                wantedValue => wantedValue.Element("maker").Value == makerValue
                && wantedValue.Element("type").Value == typeValue
                && wantedValue.Element("size").Value == sizeValue
                && wantedValue.Element("color").Value == colorValue);
            return wantedElement.Any();
        }
        */
    }



    
    
}
