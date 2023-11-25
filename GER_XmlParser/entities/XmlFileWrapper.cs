using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        protected List<XmlNode> Compute(XmlNode startingNode, string xPath)
        {
            List<XmlNode> result = new List<XmlNode>();
            XmlNodeList nodeList = startingNode.SelectNodes(xPath);
            foreach (XmlNode node in nodeList)
            {
                result.Add(node);
            }
            return result;
        }

        public List<XmlNode> Compute(string xPath)
        {
            return this.Compute(this.XmlParser, xPath);
        }
    }
}
