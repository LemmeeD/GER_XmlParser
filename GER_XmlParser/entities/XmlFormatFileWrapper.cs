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
    public class XmlFormatFileWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string XPATH_ERSOLUTIONVERSION = @"/ERSolutionVersion";
        public const string XPATH_BASE_ERSOLUTION = @"/ERSolutionVersion/Solution/ERSolution";
        public static Func<string, string> XPATH_LABEL_NODES = (languageId) => { return string.Format(@"/ERSolutionVersion/Solution/ERSolution/Labels/ERClassList/Contents./ERLabel[@LabelId and @LabelValue and @LanguageId='{0}']", languageId); };
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        public const string XPATH_TEXTFORMAT = @"/ERSolutionVersion/Contents./ERFormatVersion/Format/ERTextFormat";

        protected const string FIRST_DATASOURCE_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Datasource/ERModelDefinition/Contents.";
        protected const string FIRST_BINDING_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Binding/ERFormatBinding/Contents.";
        protected static Func<string, string> XPATH_FIND_ITEM = (string str) => { return string.Format(@".//ERModelItemDefinition[contains(@ParentPath, '{0}')] | .//ERModelItemValueDefinition[contains(@Name, '{0}')]", str); };
        protected XmlNode _nodeERSolutionVersion;
        protected XmlNode _nodeBaseERSoLution;
        protected XmlNode _vendorNode;
        protected XmlNode _nodeTextFormat;
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
        public XmlNode NodeERSolutionVersion { get { return this._nodeERSolutionVersion; } }
        public XmlNode NodeBaseERSolution { get { return this._nodeBaseERSoLution; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public XmlNode NodeTextFormat { get { return this._nodeTextFormat; } }
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public Dictionary<string, string> Labels { get { return this._labels; } }
        public string Vendor { get { return this._vendor; } }
        public GERIdentifier Identifier { get { return this._identifier; } }
        public GERIdentifier BaseModelIdentifier { get { return this._baseModelIdentifier; } }
        public GERIdentifier BaseFormatIdentifier { get { return this._baseFormatIdentifier; } }
        public bool IsBaseModelComputable { get { return this.BaseModelIdentifier != null; } }
        public bool Extension { get { return this.BaseFormatIdentifier != null; } }
        public int CountLabels { get { return this.Labels.Keys.Count; } }

        // CONSTRUCTORS
        public XmlFormatFileWrapper(string filePath) : base(filePath)
        {
            this._labels = new Dictionary<string, string>();
            this.ParseLabels(Program.LABEL_LANGUAGEID);
            this._nodeERSolutionVersion = this.ComputeFirstXPath1(XPATH_ERSOLUTIONVERSION);
            this._nodeBaseERSoLution = this.ComputeFirstXPath1(XPATH_BASE_ERSOLUTION);
            this._vendorNode = this.ComputeFirstXPath1(VENDOR_NODE_XPATH);
            this._nodeTextFormat = this.ComputeFirstXPath1(XPATH_TEXTFORMAT);
            this._datasourceNode = this.ComputeFirstXPath1(FIRST_DATASOURCE_BASE_NODE_XPATH);
            this._bindingNode = this.ComputeFirstXPath1(FIRST_BINDING_BASE_NODE_XPATH);
            if ((this.NodeERSolutionVersion == null) || (this.NodeBaseERSolution == null) || (this.VendorNode == null) || (this.DatasourceNode == null) || (this.BindingNode == null))
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Format", filePath));
            }

            XmlAttribute temp;
            //
            temp = this.NodeBaseERSolution.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else this._identifier = new GERIdentifier(temp.Value);
            //
            bool baseIdRefersBaseFormat = (this.NodeTextFormat.Attributes["Base"] != null);
            temp = this.NodeBaseERSolution.Attributes["Base"];
            if (baseIdRefersBaseFormat)
            {
                if (temp == null) this._baseFormatIdentifier = null;
                else this._baseFormatIdentifier = new GERIdentifier(temp.Value);
                this._baseModelIdentifier = null;   // ???
            }
            else
            {
                if (temp == null) this._baseModelIdentifier = null;
                else this._baseModelIdentifier = new GERIdentifier(temp.Value);
                this._baseFormatIdentifier = null;
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

        public List<XmlNode> FindReferences(string str)
        {
            string xPath = string.Format(@".//ERModelItemValueDefinition[contains(@Name, '{0}')]", str);
            return this.ComputeXPath2(this.DatasourceNode, xPath);
        }

        public int RemoveRevisionNumberAttributes()
        {
            List<XmlNode> nodes = this.ComputeXPath1(@".//*[@RevisionNumber]");
            foreach (XmlNode node in nodes)
            {
                node.Attributes.RemoveNamedItem("RevisionNumber");
            }
            this.WriteFile();
            return nodes.Count;
        }

        protected void ParseLabels(string languageId)
        {
            List<XmlNode> nodes = this.ComputeXPath1(XPATH_LABEL_NODES(languageId));
            foreach (XmlNode node in nodes)
            {
                this.Labels.Add(node.Attributes["LabelId"].Value, node.Attributes["LabelValue"].Value);
            }
        }

        public void ParseLabelsFrom(XmlFormatFileWrapper otherWrapper)
        {
            foreach (string labelId in otherWrapper.Labels.Keys)
            {
                this.Labels.Add(labelId, otherWrapper.Labels[labelId]);
            }
        }
    }
}