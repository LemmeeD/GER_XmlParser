using GER_XmlParser.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GER_XmlParser.entities
{
    public class XmlMappingWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string BASIC_INFO_NODE1_XPATH = @"/ERSolutionVersion";
        public const string BASIC_INFO_NODE2_XPATH = @"/ERSolutionVersion/Solution/ERSolution";
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";

        public const string VERSIONS_ID_NODES_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/@ID.";
        public static Func<string, string> DATASOURCE_NODE_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Datasource/ERModelDefinition/Contents.", id); };
        public static Func<string, string> BINDING_NODE_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Binding/ERDataContainerBinding/Contents.", id); };
        public static Func<string, string> VERSION_NODE_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']", id); };
        protected XmlNode _basicInfoNode1;
        protected XmlNode _basicInfoNode2;
        protected XmlNode _vendorNode;
        protected XmlNode _versionNode;
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        protected List<string> _idMappingVersions;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        // PROPERTIES
        public XmlNode BasicInfoNode1 { get { return this._basicInfoNode1; } }
        public XmlNode BasicInfoNode2 { get { return this._basicInfoNode2; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public XmlNode VersionNode { get { return this._versionNode; } }
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }
        public List<string> IdMappingVersions { get { return this._idMappingVersions; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public string Vendor { get { return this._vendor; } }

        // CONSTRUCTORS
        public XmlMappingWrapper(string filePath) : base(filePath)
        {
            this._basicInfoNode1 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE1_XPATH);
            this._basicInfoNode2 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE2_XPATH);
            this._vendorNode = this.XmlParser.SelectSingleNode(VENDOR_NODE_XPATH);

            this._idMappingVersions = new List<string>();
            XmlNodeList tmp = this.XmlParser.SelectNodes(VERSIONS_ID_NODES_XPATH);
            foreach (XmlNode n in tmp)
            {
                this.IdMappingVersions.Add(n.Value);
            }
            this.SetMappingVersion(this.IdMappingVersions[0]);
            if ((this.BasicInfoNode1 == null) || (this.BasicInfoNode2 == null) || (this.VendorNode == null) || (this.DatasourceNode == null) || (this.BindingNode == null) || (this.VersionNode == null) || (this.IdMappingVersions.Count < 1))
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Mapping", filePath));
            }
            XmlAttribute temp;
            //
            temp = this.BasicInfoNode1.Attributes["PublicVersionNumber"];
            if (temp == null) this._publicVersionNumber = "";
            else this._publicVersionNumber = temp.Value;
            //
            temp = this.BasicInfoNode1.Attributes["Description"];
            if (temp == null) this._description = "";
            else this._description = temp.Value;
            //
            temp = this.BasicInfoNode2.Attributes["Name"];
            if (temp == null) _name = "";
            else this._name = temp.Value;
            //
            temp = this.VendorNode.Attributes["Name"];
            if (temp == null) this._vendor = "";
            else this._vendor = temp.Value;
        }

        // METHODS
        public void SetMappingVersion(string idMappingVersion)
        {
            this._datasourceNode = this.XmlParser.SelectSingleNode(DATASOURCE_NODE_XPATH(idMappingVersion));
            this._bindingNode = this.XmlParser.SelectSingleNode(BINDING_NODE_XPATH(idMappingVersion));
            this._versionNode = this.XmlParser.SelectSingleNode(VERSION_NODE_XPATH(idMappingVersion));

            XmlAttribute temp;
            temp = this.VersionNode.Attributes["Description"];
            if (temp == null) this._description = "";
            else this._description = temp.Value;
        }

        //public List<XmlNode> ComputeFromDatasource(string xPath)
        //{
        //    return this.Compute(this.DatasourceNode, xPath);
        //}
    }
}
