using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.entities
{
    internal class XmlFormatFileWrapper : XmlFileWrapper
    {
        // FIELDS
        protected const string FIRST_DATASOURCE_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Datasource/ERModelDefinition/Contents.";
        protected const string FIRST_BINDING_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Binding/ERFormatBinding/Contents.";
        protected static Func<string, string> XPATH_FIND_ITEM = (string str) => { return string.Format(@".//ERModelItemDefinition[contains(@ParentPath, '{0}')] | .//ERModelItemValueDefinition[contains(@Name, '{0}')]", str); };
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        // PROPERTIES
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }

        // CONSTRUCTORS
        public XmlFormatFileWrapper(string filePath) : base(filePath)
        {
            this._datasourceNode = this.XmlParser.SelectSingleNode(FIRST_DATASOURCE_BASE_NODE_XPATH);
            this._bindingNode = this.XmlParser.SelectSingleNode(FIRST_BINDING_BASE_NODE_XPATH);
        }

        public List<XmlNode> FindReferences(string str)
        {
            string xPath = string.Format(@".//ERModelItemValueDefinition[contains(@Name, '{0}')]", str);
            return this.Compute(this.DatasourceNode, xPath);
        }
    }
}
