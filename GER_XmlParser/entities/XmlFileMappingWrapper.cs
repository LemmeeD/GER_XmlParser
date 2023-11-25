using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.entities
{
    internal class XmlFileMappingWrapper : XmlFileWrapper
    {
        // FIELDS
        protected const string FIRST_DATASOURCE_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/Mapping/ERModelMapping/Datasource/ERModelDefinition/Contents.";
        protected const string FIRST_BINDING_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/Mapping/ERModelMapping/Binding/ERDataContainerBinding/Contents.";
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        // PROPERTIES
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }

        // CONSTRUCTORS
        public XmlFileMappingWrapper(string filePath) : base(filePath)
        {
            this._datasourceNode = this.XmlParser.SelectSingleNode(FIRST_DATASOURCE_BASE_NODE_XPATH);
            this._bindingNode = this.XmlParser.SelectSingleNode(FIRST_BINDING_BASE_NODE_XPATH);
        }

        // METHODS
        //public List<XmlNode> ComputeFromDatasource(string xPath)
        //{
        //    return this.Compute(this.DatasourceNode, xPath);
        //}
    }
}
