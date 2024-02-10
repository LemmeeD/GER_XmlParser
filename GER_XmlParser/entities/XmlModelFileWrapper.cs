using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using GER_XmlParser.exceptions;

namespace GER_XmlParser.entities
{
    public class XmlModelFileWrapper : XmlFileWrapper
    {
        // FIELDS
        public const string BASE_SOLUTION_XPATH = @"/ERSolutionVersion/Solution/ERSolution";
        public const string BASE_CONTENTS_NODE_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel/Contents.";
        public const string BASIC_INFO_NODE1_XPATH = @"/ERSolutionVersion";
        public const string BASIC_INFO_NODE2_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel";
        public const string BASIC_INFO_NODE3_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel";
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        public static Func<string, string> XPATH_LABEL_NODES = (languageId) => { return string.Format(@"/ERSolutionVersion/Solution/ERSolution/Labels/ERClassList/Contents./ERLabel[@LabelId and @LabelValue and @LanguageId='{0}']", languageId); };
        protected XmlNode _baseSolutionNode;
        protected XmlNode _basicInfoNode1;
        protected XmlNode _basicInfoNode2;
        protected XmlNode _basicInfoNode3;
        protected XmlNode _baseContentsNode;
        protected XmlNode _vendorNode;
        protected GERIdentifier _identifier;
        protected GERIdentifier _referencedIdentifier;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        protected Dictionary<string, string> _labels;
        // PROPERTIES
        public XmlNode BaseSolutionNode { get { return this._baseSolutionNode; } }
        public XmlNode BasicInfoNode1 { get { return this._basicInfoNode1; } }
        public XmlNode BasicInfoNode2 { get { return this._basicInfoNode2; } }
        public XmlNode BasicInfoNode3 { get { return this._basicInfoNode3; } }
        public XmlNode BaseContentsNode { get { return this._baseContentsNode; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public GERIdentifier Identifier { get { return this._identifier; } }
        public GERIdentifier ReferencedIdentifier { get { return this._referencedIdentifier; } }
        public bool Extension { get { return this.ReferencedIdentifier != null; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public string Vendor { get { return this._vendor; } }
        public Dictionary<string, string> Labels { get { return this._labels; } }
        public int CountLabels { get { return this.Labels.Keys.Count; } }

        // CONSTRUCTORS
        public XmlModelFileWrapper(string filePath) : base(filePath)
        {
            this._labels = new Dictionary<string, string>();
            this.ParseLabels(Program.LABEL_LANGUAGEID);
            this._baseSolutionNode = this.ComputeFirstXPath1(BASE_SOLUTION_XPATH);
            this._basicInfoNode1 = this.ComputeFirstXPath1(BASIC_INFO_NODE1_XPATH);
            this._basicInfoNode2 = this.ComputeFirstXPath1(BASIC_INFO_NODE2_XPATH);
            this._basicInfoNode3 = this.ComputeFirstXPath1(BASIC_INFO_NODE3_XPATH);
            this._baseContentsNode = this.ComputeFirstXPath1(BASE_CONTENTS_NODE_XPATH);
            this._vendorNode = this.ComputeFirstXPath1(VENDOR_NODE_XPATH);
            if ((this._baseSolutionNode == null) || (this.BasicInfoNode1 == null) || (this.BasicInfoNode2 == null) || (this.BasicInfoNode3 == null) || (this.BaseContentsNode == null) || (this.VendorNode == null))
            {
                throw new InvalidModelException(string.Format("File individuato dal percorso '{0}' non valido come Model", filePath));
            }

            XmlAttribute temp;
            //
            temp = this.BaseSolutionNode.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else this._identifier = new GERIdentifier(temp.Value);
            //
            temp = this.BaseSolutionNode.Attributes["Base"];
            if (temp == null) this._referencedIdentifier = null;
            else this._referencedIdentifier = new GERIdentifier(temp.Value);
            //
            temp = this.BasicInfoNode1.Attributes["PublicVersionNumber"];
            if (temp == null) _publicVersionNumber = "";
            else _publicVersionNumber = temp.Value;
            //
            temp = this.BasicInfoNode1.Attributes["Description"];
            if (temp == null) _description = "";
            else _description = temp.Value;
            //
            temp = this.BasicInfoNode2.Attributes["Name"];
            if (temp == null) _name = "";
            else _name = temp.Value;
            //
            temp = this.VendorNode.Attributes["Name"];
            if (temp == null) _vendor = "";
            else _vendor = temp.Value;
        }

        // METHODS
        public MyTree<XmlNode> FindReferences(string str)
        {
            //string xPath = string.Format(@".//*[contains(@Name, '{0}') and not(ends-with(@Name, '_1'))]", str);
            string xPath = string.Format(@"(.//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor[not(ends-with(@Name, '_1')) or @IsEnum='1'])[contains(@Name, '{0}')]", str);
            List<XmlNode> nodes = this.ComputeXPath2(this.BaseContentsNode, xPath);
            return MyTree<XmlNode>.ComputeFromModelFindRef(nodes, this.BaseContentsNode, this.Labels);
        }

        public MyTree<XmlNode> FindEntireModelContents()
        {
            string xPath = @".//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor";
            List<XmlNode> nodes = this.ComputeXPath1(this.BaseContentsNode, xPath);
            return MyTree<XmlNode>.ComputeFromModelFindRef(nodes, this.BaseContentsNode, this.Labels);
        }

        protected void ParseLabels(string languageId)
        {
            List<XmlNode> nodes = this.ComputeXPath1(XPATH_LABEL_NODES(languageId));
            foreach (XmlNode node in nodes)
            {
                this.Labels.Add(node.Attributes["LabelId"].Value, node.Attributes["LabelValue"].Value);
            }
        }

        public void ParseLabelsFrom(XmlModelFileWrapper otherWrapper)
        {
            foreach (string labelId in otherWrapper.Labels.Keys)
            {
                this.Labels.Add(labelId, otherWrapper.Labels[labelId]);
            }
        }
    }
}
