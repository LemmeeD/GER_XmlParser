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
    public class XmlFormatFileWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string XPATH_ERSOLUTIONVERSION = @"/ERSolutionVersion";
        public const string XPATH_BASE_ERSOLUTION = @"/ERSolutionVersion/Solution/ERSolution";
        public static Func<string, string> XPATH_LABEL_NODES = (languageId) => { return string.Format(@"/ERSolutionVersion/Solution/ERSolution/Labels/ERClassList/Contents./ERLabel[@LabelId and @LabelValue and @LanguageId='{0}']", languageId); };
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        public const string XPATH_TEXTFORMAT = @"/ERSolutionVersion/Contents./ERFormatVersion/Format/ERTextFormat";
        public const string XPATH_TEXTFORMAT_ROOT = @"/ERSolutionVersion/Contents./ERFormatVersion/Format/ERTextFormat/Root";
        public const string XPATH_TEXTFORMAT_ENUMLIST = @"/ERSolutionVersion/Contents./ERFormatVersion/Format/ERTextFormat/EnumList/EREnumDefinitionList/Contents.";

        protected const string FIRST_DATASOURCE_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Datasource/ERModelDefinition/Contents.";
        protected const string FIRST_BINDING_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Binding/ERFormatBinding/Contents.";
        protected static Func<string, string> XPATH_FIND_ITEM = (str) => { return string.Format(@".//ERModelItemDefinition[contains(@ParentPath, '{0}')] | .//ERModelItemValueDefinition[contains(@Name, '{0}')]", str); };
        protected XmlNode _nodeERSolutionVersion;
        protected XmlNode _nodeBaseERSoLution;
        protected XmlNode _vendorNode;
        protected XmlNode _nodeTextFormat;
        protected XmlNode _nodeTextFormatRoot;
        protected XmlNode _nodeTextFormatEnumList;
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected Dictionary<string, string> _labels;
        protected string _vendor;
        protected GERIdentifier _identifier;
        protected GERIdentifier _baseModelIdentifier;
        protected GERIdentifier _baseFormatIdentifier;
        // PROPERTIES
        public XmlNode NodeERSolutionVersion { get { return _nodeERSolutionVersion; } }
        public XmlNode NodeBaseERSolution { get { return _nodeBaseERSoLution; } }
        public XmlNode VendorNode { get { return _vendorNode; } }
        public XmlNode NodeTextFormat { get { return _nodeTextFormat; } }
        public XmlNode NodeTextFormatRoot { get { return _nodeTextFormatRoot; } }
        public XmlNode NodeTextFormatEnumList { get { return _nodeTextFormatEnumList; } }
        public XmlNode DatasourceNode { get { return _datasourceNode; } }
        public XmlNode BindingNode { get { return _bindingNode; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public string PublicVersionNumber { get { return _publicVersionNumber; } }
        public Dictionary<string, string> Labels { get { return _labels; } }
        public string Vendor { get { return _vendor; } }
        public GERIdentifier Identifier { get { return _identifier; } }
        public GERIdentifier BaseModelIdentifier { get { return _baseModelIdentifier; } }
        public GERIdentifier BaseFormatIdentifier { get { return _baseFormatIdentifier; } }
        public bool IsBaseModelComputable { get { return BaseModelIdentifier != null; } }
        public bool Extension { get { return BaseFormatIdentifier != null; } }
        public int CountLabels { get { return Labels.Keys.Count; } }

        // CONSTRUCTORS
        public XmlFormatFileWrapper(string filePath) : base(filePath)
        {
            this._labels = new Dictionary<string, string>();
            this.ParseLabels(Program.LABEL_LANGUAGEID);
            this._nodeERSolutionVersion = ComputeFirstXPath1(XPATH_ERSOLUTIONVERSION);
            this._nodeBaseERSoLution = ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            this._vendorNode = ComputeFirstXPath1(VENDOR_NODE_XPATH);
            this._nodeTextFormat = ComputeFirstXPath1(XPATH_TEXTFORMAT);
            this._nodeTextFormatRoot = ComputeFirstXPath1(XPATH_TEXTFORMAT_ROOT);
            this._nodeTextFormatEnumList = ComputeFirstXPath1(XPATH_TEXTFORMAT_ENUMLIST);
            this._datasourceNode = ComputeFirstXPath1(FIRST_DATASOURCE_BASE_NODE_XPATH);
            this._bindingNode = ComputeFirstXPath1(FIRST_BINDING_BASE_NODE_XPATH);
            if (NodeERSolutionVersion == null || NodeBaseERSolution == null || VendorNode == null || DatasourceNode == null || BindingNode == null)
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Format", filePath));
            }

            XmlAttribute temp;
            //
            temp = NodeBaseERSolution.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else _identifier = new GERIdentifier(temp.Value);
            //
            bool baseIdRefersBaseFormat = NodeTextFormat.Attributes["Base"] != null;
            temp = NodeBaseERSolution.Attributes["Base"];
            if (baseIdRefersBaseFormat)
            {
                if (temp == null) _baseFormatIdentifier = null;
                else _baseFormatIdentifier = new GERIdentifier(temp.Value);
                _baseModelIdentifier = null;   // ???
            }
            else
            {
                if (temp == null) _baseModelIdentifier = null;
                else _baseModelIdentifier = new GERIdentifier(temp.Value);
                _baseFormatIdentifier = null;
            }

            //
            temp = NodeERSolutionVersion.Attributes["PublicVersionNumber"];
            if (temp == null) _publicVersionNumber = "";
            else _publicVersionNumber = temp.Value;
            //
            temp = NodeERSolutionVersion.Attributes["Description"];
            if (temp == null) _description = "";
            else _description = temp.Value;
            //
            temp = NodeBaseERSolution.Attributes["Name"];
            if (temp == null) _name = "";
            else _name = temp.Value;
            //
            temp = VendorNode.Attributes["Name"];
            if (temp == null) _vendor = "";
            else _vendor = temp.Value;
        }

        public List<XmlNode> FindReferences(string str)
        {
            //string xPath = string.Format(@".//ERModelItemValueDefinition[contains(@Name, '{0}')]", str);
            string xPath = string.Format(@"//ERModelItemValueDefinition[contains(@Name, '{0}')]", str);
            return ComputeXPath2(NodeTextFormatRoot, xPath);
        }

        public MyTree<FormatPair> FindEntireFormatContents()
        {
            //string xPath = @".//ERTextFormatFileComponent | .//ERTextFormatXMLElement | .//ERTextFormatXMLAttribute | .//ERTextFormatDate | .//ERTextFormatString .//ERTextFormatNumeric";
            string xPathFormat = @".//*[starts-with(name(), 'ERTextFormat')]";
            List<XmlNode> nodes = ComputeXPath2(NodeTextFormatRoot, xPathFormat);

            string xPathBindings = @".//ERFormatComponentPropertyBinding";
            List<XmlNode> nodesBindings = ComputeXPath2(BindingNode, xPathFormat);

            return MyTree<FormatPair>.ComputeFromFormatFindRef(nodes, NodeTextFormatRoot, nodesBindings, Labels);
        }

        public int RemoveRevisionNumberAttributes()
        {
            List<XmlNode> nodes = ComputeXPath1(@".//*[@RevisionNumber]");
            foreach (XmlNode node in nodes)
            {
                node.Attributes.RemoveNamedItem("RevisionNumber");
            }
            WriteFile();
            return nodes.Count;
        }

        protected void ParseLabels(string languageId)
        {
            List<XmlNode> nodes = ComputeXPath1(XPATH_LABEL_NODES(languageId));
            foreach (XmlNode node in nodes)
            {
                Labels.Add(node.Attributes["LabelId"].Value, node.Attributes["LabelValue"].Value);
            }
        }

        public void ParseLabelsFrom(XmlFormatFileWrapper otherWrapper)
        {
            foreach (string labelId in otherWrapper.Labels.Keys)
            {
                Labels.Add(labelId, otherWrapper.Labels[labelId]);
            }
        }

        public static string TranslateXmlNodeValueToMyTreeNode(XmlNode node)
        {
            if (node.Name == "ERTextFormatDate") return "DateTime";
            else if (node.Name == "ERTextFormatString") return "String";
            else if (node.Name == "ERTextFormatNumeric") return "Value";
            else if (node.Name == "ERTextFormatBase64Component") return "Base64";
            else return "???";
        }
    }
}