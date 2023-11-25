using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.entities
{
    internal class XmlModelFileWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel/Contents.";
        protected XmlNode _baseNode;
        // PROPERTIES
        public XmlNode BaseNode { get { return this._baseNode; } }

        // CONSTRUCTORS
        public XmlModelFileWrapper(string filePath) : base(filePath)
        {
            this._baseNode = this.XmlParser.SelectSingleNode(BASE_NODE_XPATH);
        }

        // METHODS
        protected List<XmlNode> ComputeFromBase(string xPath)
        {
            return this.Compute(this.BaseNode, xPath);
        }

        public List<XmlNode> FindReferences(string str)
        {
            string xPath = string.Format(@".//*[contains(@Name, '{0}')]", str);
            return this.ComputeFromBase(xPath);
        }
    }
}
