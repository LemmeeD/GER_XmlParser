using GER_XmlParser.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Wmhelp.XPath2;

namespace GER_XmlParser.entities
{
    public abstract class XmlFileWrapper
    {
        // FIELDS
        protected string _filePath;
        protected XmlDocument _xmlParser;
        // PROPERTIES
        public string FilePath { get { return this._filePath; } }
        protected XmlDocument XmlParser { get { return this._xmlParser; } }

        // CONSTRUCTORS
        public XmlFileWrapper(string filePath)
        {
            this._filePath = filePath;
            this._xmlParser = new XmlDocument();
            this.XmlParser.Load(this.FilePath);
        }

        // METHODS
        public XmlNode ComputeFirstXPath1(string xPath)
        {
            return this.ComputeFirstXPath1(this.XmlParser, xPath);
        }

        protected XmlNode ComputeFirstXPath1(XmlNode startingNode, string xPath)
        {
            return startingNode.SelectSingleNode(xPath);
        }

        public List<XmlNode> ComputeXPath1(string xPath)
        {
            return this.ComputeXPath1(this.XmlParser, xPath);

        }

        protected List<XmlNode> ComputeXPath1(XmlNode startingNode, string xPath)
        {
            XmlNodeList temp = startingNode.SelectNodes(xPath);
            return XmlNodeListUtils.ToSortedList(temp);
        }

        protected XmlNode ComputeFirstXPath2(string xPath)
        {
            return this.ComputeFirstXPath2(this.XmlParser, xPath);
        }

        protected XmlNode ComputeFirstXPath2(XmlNode startingNode, string xPath)
        {
            return startingNode.XPath2SelectSingleNode(xPath);
        }

        protected List<XmlNode> ComputeXPath2(string xPath)
        {
            return this.ComputeXPath2(this.XmlParser, xPath);
        }

        protected List<XmlNode> ComputeXPath2(XmlNode startingNode, string xPath)
        {
            XmlNodeList temp = startingNode.XPath2SelectNodes(xPath);
            return XmlNodeListUtils.ToSortedList(temp);
        }

        public void WriteFile()
        {
            this.XmlParser.Save(this.FilePath);
        }
    }
}
