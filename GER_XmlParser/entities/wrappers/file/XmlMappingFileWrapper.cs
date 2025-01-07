using GER_XmlParser.entities.wrappers.data;
using GER_XmlParser.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GER_XmlParser.entities.wrappers.file
{
    public class XmlMappingFileWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string XPATH_ERSOLUTIONVERSION = @"/ERSolutionVersion";
        public const string XPATH_BASE_ERSOLUTION = @"/ERSolutionVersion/Solution/ERSolution";
        public const string XPATH_VENDOR = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        public const string MODEL_MAPPING_VERSION_NODES_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/Mapping/ERModelMapping";
        public const string VERSIONS_ID_NODES_XPATH = @"/ERSolutionVersion/Contents./ERModelMappingVersion/@ID.";
        public static Func<string, string> DATASOURCE_NODE_XPATH = (id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Datasource/ERModelDefinition/Contents.", id); };
        public static Func<string, string> BINDING_NODE_XPATH = (id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping/Binding/ERDataContainerBinding/Contents.", id); };
        public static Func<string, string> XPATH_ERMODELMAPPINGVERSION = (id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']", id); };
        public static Func<string, string> XPATH_ERMODELMAPPING = (id) => { return string.Format(@"/ERSolutionVersion/Contents./ERModelMappingVersion[@ID.='{0}']/Mapping/ERModelMapping", id); };
        protected XmlNode _baseSolutionNode;
        protected List<XmlNode> _nodesMappingVersion;
        protected XmlNode _nodeERSolutionVersion;
        protected XmlNode _nodeBaseERSoLution;
        protected XmlNode _vendorNode;
        protected XmlNode _nodeModelMappingVersion;
        protected XmlNode _nodeModelMapping;
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        protected List<string> _idMappingVersions;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        protected string _mappingDefinition;
        protected string _mappingName;
        protected string _mappingDescription;
        protected GERIdentifier _identifier;
        protected GERIdentifier _baseModelIdentifier;
        protected GERIdentifier _baseMappingIdentifier;
        protected Dictionary<string, string> _labels;
        // PROPERTIES
        public XmlNode BaseSolutionNode { get { return _baseSolutionNode; } }
        public List<XmlNode> NodesMappingVersion { get { return _nodesMappingVersion; } }
        public XmlNode NodeERSolutionVersion { get { return _nodeERSolutionVersion; } }
        public XmlNode NodeBaseERSolution { get { return _nodeBaseERSoLution; } }
        public XmlNode VendorNode { get { return _vendorNode; } }
        public XmlNode NodeModelMappingVersion { get { return _nodeModelMappingVersion; } }
        public XmlNode NodeModelMapping { get { return _nodeModelMapping; } }
        public XmlNode DatasourceNode { get { return _datasourceNode; } }
        public XmlNode BindingNode { get { return _bindingNode; } }
        public List<string> IdMappingVersions { get { return _idMappingVersions; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public string PublicVersionNumber { get { return _publicVersionNumber; } }
        public string Vendor { get { return _vendor; } }
        public string MappingDefinition { get { return _mappingDefinition; } }
        public string MappingName { get { return _mappingName; } }
        public string MappingDescription { get { return _mappingDescription; } }
        public GERIdentifier Identifier { get { return _identifier; } }
        public GERIdentifier BaseModelIdentifier { get { return _baseModelIdentifier; } }
        public GERIdentifier BaseMappingIdentifier { get { return _baseMappingIdentifier; } }
        public Dictionary<string, string> Labels;
        public bool IsBaseModelComputable { get { return BaseModelIdentifier != null; } }
        public bool Extension { get { return BaseMappingIdentifier != null; } }

        // CONSTRUCTORS
        public XmlMappingFileWrapper(string filePath) : base(filePath)
        {
            _baseSolutionNode = ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            _nodesMappingVersion = ComputeXPath1(MODEL_MAPPING_VERSION_NODES_XPATH);
            _nodeERSolutionVersion = ComputeFirstXPath1(XPATH_ERSOLUTIONVERSION);
            _nodeBaseERSoLution = ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            _vendorNode = ComputeFirstXPath1(XPATH_VENDOR);
            _idMappingVersions = new List<string>();
            List<XmlNode> tmp = ComputeXPath1(VERSIONS_ID_NODES_XPATH);
            foreach (XmlNode n in tmp)
            {
                IdMappingVersions.Add(n.Value);
            }
            if (BaseSolutionNode == null || NodesMappingVersion.Count == 0 || NodeERSolutionVersion == null || NodeBaseERSolution == null || VendorNode == null || IdMappingVersions.Count < 1)
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Mapping", filePath));
            }

            SetMappingVersion(IdMappingVersions[0]);
            if (DatasourceNode == null || BindingNode == null || NodeModelMappingVersion == null || NodeModelMapping == null)
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Mapping", filePath));
            }
            XmlAttribute temp;
            //
            temp = BaseSolutionNode.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else _identifier = new GERIdentifier(temp.Value);
            //
            bool baseIdRefersBaseMapping = NodesMappingVersion.Where((node) => node.Attributes["Base"] != null).Count() > 0;
            temp = BaseSolutionNode.Attributes["Base"];
            if (baseIdRefersBaseMapping)
            {
                if (temp == null) _baseMappingIdentifier = null;
                else _baseMappingIdentifier = new GERIdentifier(temp.Value);
                _baseModelIdentifier = null;   // ???
            }
            else
            {
                if (temp == null) _baseModelIdentifier = null;
                else _baseModelIdentifier = new GERIdentifier(temp.Value);
                _baseMappingIdentifier = null;
            }

            //
            temp = BaseSolutionNode.Attributes["Name"];
            if (temp == null) _name = "";
            else _name = temp.Value;
            //
            temp = NodeERSolutionVersion.Attributes["Description"];
            if (temp == null) _description = "";
            else _description = temp.Value;
            //
            temp = NodeERSolutionVersion.Attributes["PublicVersionNumber"];
            if (temp == null) _publicVersionNumber = "";
            else _publicVersionNumber = temp.Value;
            //
            temp = NodeBaseERSolution.Attributes["Name"];
            if (temp == null) _name = "";
            else _name = temp.Value;
            //
            temp = VendorNode.Attributes["Name"];
            if (temp == null) _vendor = "";
            else _vendor = temp.Value;
        }

        // METHODS
        //[contains-ignore-case(@Name, '{0}')] <--> [matches(@Name, '{0}', 'i')] in XPath2.0
        public void SetMappingVersion(string idMappingVersion)
        {
            _nodeERSolutionVersion = ComputeFirstXPath1(XPATH_ERSOLUTIONVERSION);
            _baseSolutionNode = ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            _datasourceNode = ComputeFirstXPath1(DATASOURCE_NODE_XPATH(idMappingVersion));
            _bindingNode = ComputeFirstXPath1(BINDING_NODE_XPATH(idMappingVersion));
            _nodeModelMappingVersion = ComputeFirstXPath1(XPATH_ERMODELMAPPINGVERSION(idMappingVersion));
            _nodeModelMapping = ComputeFirstXPath1(XPATH_ERMODELMAPPING(idMappingVersion));

            XmlAttribute temp;
            //
            temp = NodeModelMapping.Attributes["DataContainerDescriptor"];
            if (temp == null) _mappingDefinition = "";
            else _mappingDefinition = temp.Value;

            //
            temp = NodeModelMapping.Attributes["Description"];
            if (temp == null) _mappingDescription = "";
            else _mappingDescription = temp.Value;
            //
            temp = NodeModelMapping.Attributes["Name"];
            if (temp == null) _mappingName = "";
            else _mappingName = temp.Value;
        }
        public void ParseLabelsFromModel(XmlModelFileWrapper modelWrapper)
        {
            foreach (string labelId in modelWrapper.Labels.Keys)
            {
                Labels.Add(labelId, modelWrapper.Labels[labelId]);
            }
        }

        public Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> FindEntireMappingContents(Dictionary<string, string> labels)
        {
            string xPathDatasource = @".//ERModelItemDefinition/ValueDefinition/ERModelItemValueDefinition";
            List<XmlNode> nodesDatasource = ComputeXPath1(DatasourceNode, xPathDatasource);

            // Gestire caso senza attributo ItemPath
            string xPathBinding = @".//ERDataContainerPathBinding/Expression/*[@ItemPath]";
            List<XmlNode> nodesBinding = ComputeXPath1(BindingNode, xPathBinding);

            return MyTree<string>.ComputeFromMappingFindRef(nodesDatasource, DatasourceNode, nodesBinding, BindingNode, labels);
        }

        public Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> FindReferences(string input, Dictionary<string, string> labels)
        {
            //string xPathDatasource = string.Format(@".//ERModelItemDefinition/ValueDefinition/ERModelItemValueDefinition[contains(@Name, '{0}')]", input);
            string xPathDatasource = string.Format(@".//ERModelItemDefinition/ValueDefinition/ERModelItemValueDefinition[matches(@Name, '{0}', 'i')]", input);
            List<XmlNode> nodesDatasource = ComputeXPath2(DatasourceNode, xPathDatasource);

            // Gestire caso senza attributo ItemPath
            //string xPathBinding = string.Format(@".//ERDataContainerPathBinding[contains(@Path, '{0}')]/Expression/*", input);
            string xPathBinding = string.Format(@".//ERDataContainerPathBinding[matches(@Path, '{0}', 'i')]/Expression/*[@ItemPath]", input);
            List<XmlNode> nodesBinding = ComputeXPath2(BindingNode, xPathBinding);

            return MyTree<string>.ComputeFromMappingFindRef(nodesDatasource, DatasourceNode, nodesBinding, BindingNode, labels);
        }
    }
}
