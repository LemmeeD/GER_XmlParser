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
        public const string XPATH_ERSOLUTIONVERSION = @"/ERSolutionVersion";
        public const string XPATH_BASE_ERSOLUTION = @"/ERSolutionVersion/Solution/ERSolution";
        public const string XPATH_VENDOR = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        public const string MODEL_MAPPING_VERSION_NODES_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/Mapping/ERModelMapping";
        public const string VERSIONS_ID_NODES_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/@ID.";
        public static Func<string, string> DATASOURCE_NODE_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Datasource/ERModelDefinition/Contents.", id); };
        public static Func<string, string> BINDING_NODE_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Binding/ERDataContainerBinding/Contents.", id); };
        public static Func<string, string> VERSION_NODE1_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']", id); };
        public static Func<string, string> VERSION_NODE2_XPATH = (string id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping", id); };
        protected XmlNode _baseSolutionNode;
        protected List<XmlNode> _nodesMappingVersion;
        protected XmlNode _nodeERSolutionVersion;
        protected XmlNode _nodeBaseERSoLution;
        protected XmlNode _vendorNode;
        protected XmlNode _versionNode1;
        protected XmlNode _versionNode2;
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        protected List<string> _idMappingVersions;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        protected string _mappingName;
        protected GERIdentifier _identifier;
        protected GERIdentifier _baseModelIdentifier;
        protected GERIdentifier _baseMappingIdentifier;
        // PROPERTIES
        public XmlNode BaseSolutionNode { get { return this._baseSolutionNode; } }
        public List<XmlNode> NodesMappingVersion { get { return this._nodesMappingVersion; } }
        public XmlNode NodeERSolutionVersion { get { return this._nodeERSolutionVersion; } }
        public XmlNode NodeBaseERSolution { get { return this._nodeBaseERSoLution; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public XmlNode VersionNode1 { get { return this._versionNode1; } }
        public XmlNode VersionNode2 { get { return this._versionNode2; } }
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }
        public List<string> IdMappingVersions { get { return this._idMappingVersions; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public string Vendor { get { return this._vendor; } }
        public string MappingName { get { return this._mappingName; } }
        public GERIdentifier Identifier { get { return this._identifier; } }
        public GERIdentifier BaseModelIdentifier { get { return this._baseModelIdentifier; } }
        public GERIdentifier BaseMappingIdentifier { get { return this._baseMappingIdentifier; } }
        public bool IsBaseModelComputable { get { return this.BaseModelIdentifier != null; } }
        public bool Extension { get { return this.BaseMappingIdentifier != null; } }

        // CONSTRUCTORS
        public XmlMappingWrapper(string filePath) : base(filePath)
        {
            this._baseSolutionNode = this.ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            this._nodesMappingVersion = this.ComputeXPath1(MODEL_MAPPING_VERSION_NODES_XPATH);
            this._nodeERSolutionVersion = this.ComputeFirstXPath1(XPATH_ERSOLUTIONVERSION);
            this._nodeBaseERSoLution = this.ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            this._vendorNode = this.ComputeFirstXPath1(XPATH_VENDOR);
            this._idMappingVersions = new List<string>();
            List<XmlNode> tmp = this.ComputeXPath1(VERSIONS_ID_NODES_XPATH);
            foreach (XmlNode n in tmp)
            {
                this.IdMappingVersions.Add(n.Value);
            }
            if ((this.BaseSolutionNode == null) || (this.NodesMappingVersion.Count == 0) || (this.NodeERSolutionVersion == null) || (this.NodeBaseERSolution == null) || (this.VendorNode == null) || (this.IdMappingVersions.Count < 1))
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Mapping", filePath));
            }

            this.SetMappingVersion(this.IdMappingVersions[0]);
            if ((this.DatasourceNode == null) || (this.BindingNode == null) || (this.VersionNode1 == null) || (this.VersionNode2 == null))
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Mapping", filePath));
            }
            XmlAttribute temp;
            //
            temp = this.BaseSolutionNode.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else this._identifier = new GERIdentifier(temp.Value);
            //
            bool baseIdRefersBaseMapping = (this.NodesMappingVersion.Where((node) => node.Attributes["Base"] != null).Count() > 0);
            temp = this.BaseSolutionNode.Attributes["Base"];
            if (baseIdRefersBaseMapping)
            {
                if (temp == null) this._baseMappingIdentifier = null;
                else this._baseMappingIdentifier = new GERIdentifier(temp.Value);
                this._baseModelIdentifier = null;   // ???
            }
            else
            {
                if (temp == null) this._baseModelIdentifier = null;
                else this._baseModelIdentifier = new GERIdentifier(temp.Value);
                this._baseMappingIdentifier = null;
            }

            //
            temp = this.NodeERSolutionVersion.Attributes["PublicVersionNumber"];
            if (temp == null) this._publicVersionNumber = "";
            else this._publicVersionNumber = temp.Value;
            //
            temp = this.NodeERSolutionVersion.Attributes["Description"];
            if (temp == null) this._description = "";
            else this._description = temp.Value;
            //
            temp = this.NodeBaseERSolution.Attributes["Name"];
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
            this._datasourceNode = this.ComputeFirstXPath1(DATASOURCE_NODE_XPATH(idMappingVersion));
            this._bindingNode = this.ComputeFirstXPath1(BINDING_NODE_XPATH(idMappingVersion));
            this._versionNode1 = this.ComputeFirstXPath1(VERSION_NODE1_XPATH(idMappingVersion));
            this._versionNode2 = this.ComputeFirstXPath1(VERSION_NODE2_XPATH(idMappingVersion));

            XmlAttribute temp;
            //
            temp = this.VersionNode1.Attributes["Description"];
            if (temp == null) this._description = "";
            else this._description = temp.Value;
            //
            temp = this.VersionNode2.Attributes["DataContainerDescriptor"];
            if (temp == null) this._mappingName = "";
            else this._mappingName = temp.Value;
        }
    }
}
