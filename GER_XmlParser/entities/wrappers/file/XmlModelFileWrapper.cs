using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GER_XmlParser.exceptions;

namespace GER_XmlParser.entities.wrappers.file
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
        public XmlNode BaseSolutionNode { get { return _baseSolutionNode; } }
        public XmlNode BasicInfoNode1 { get { return _basicInfoNode1; } }
        public XmlNode BasicInfoNode2 { get { return _basicInfoNode2; } }
        public XmlNode BasicInfoNode3 { get { return _basicInfoNode3; } }
        public XmlNode BaseContentsNode { get { return _baseContentsNode; } }
        public XmlNode VendorNode { get { return _vendorNode; } }
        public GERIdentifier Identifier { get { return _identifier; } }
        public GERIdentifier ReferencedIdentifier { get { return _referencedIdentifier; } }
        public bool Extension { get { return ReferencedIdentifier != null; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public string PublicVersionNumber { get { return _publicVersionNumber; } }
        public string Vendor { get { return _vendor; } }
        public Dictionary<string, string> Labels { get { return _labels; } }
        public int CountLabels { get { return Labels.Keys.Count; } }

        // CONSTRUCTORS
        public XmlModelFileWrapper(string filePath) : base(filePath)
        {
            _labels = new Dictionary<string, string>();
            ParseLabels(Program.LABEL_LANGUAGEID);
            _baseSolutionNode = ComputeFirstXPath1(BASE_SOLUTION_XPATH);
            _basicInfoNode1 = ComputeFirstXPath1(BASIC_INFO_NODE1_XPATH);
            _basicInfoNode2 = ComputeFirstXPath1(BASIC_INFO_NODE2_XPATH);
            _basicInfoNode3 = ComputeFirstXPath1(BASIC_INFO_NODE3_XPATH);
            _baseContentsNode = ComputeFirstXPath1(BASE_CONTENTS_NODE_XPATH);
            _vendorNode = ComputeFirstXPath1(VENDOR_NODE_XPATH);
            if (_baseSolutionNode == null || BasicInfoNode1 == null || BasicInfoNode2 == null || BasicInfoNode3 == null || BaseContentsNode == null || VendorNode == null)
            {
                throw new InvalidModelException(string.Format("File individuato dal percorso '{0}' non valido come Model", filePath));
            }

            XmlAttribute temp;
            //
            temp = BaseSolutionNode.Attributes["ID."];
            if (temp == null) throw new InvalidFormatException("Non può esistere un GER senza identificatore..");
            else _identifier = new GERIdentifier(temp.Value);
            //
            temp = BaseSolutionNode.Attributes["Base"];
            if (temp == null) _referencedIdentifier = null;
            else _referencedIdentifier = new GERIdentifier(temp.Value);
            //
            temp = BasicInfoNode1.Attributes["PublicVersionNumber"];
            if (temp == null) _publicVersionNumber = "";
            else _publicVersionNumber = temp.Value;
            //
            temp = BasicInfoNode1.Attributes["Description"];
            if (temp == null) _description = "";
            else _description = temp.Value;
            //
            temp = BasicInfoNode2.Attributes["Name"];
            if (temp == null) _name = "";
            else _name = temp.Value;
            //
            temp = VendorNode.Attributes["Name"];
            if (temp == null) _vendor = "";
            else _vendor = temp.Value;
        }

        // METHODS
        //[contains-ignore-case(@Name, '{0}')] <--> [matches(@Name, '{0}', 'i')] in XPath2.0
        public MyTree<XmlNode> FindReferences(string str)
        {
            //string xPath = string.Format(@".//*[contains(@Name, '{0}') and not(ends-with(@Name, '_1'))]", str);
            //string xPath = string.Format(@"(.//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor[not(ends-with(@Name, '_1')) or @IsEnum='1'])[contains(@Name, '{0}')]", str);
            string xPath = string.Format(@"(.//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor[not(ends-with(@Name, '_1')) or @IsEnum='1'])[matches(@Name, '{0}', 'i')]", str);
            List<XmlNode> nodes = ComputeXPath2(BaseContentsNode, xPath);
            return MyTree<XmlNode>.ComputeFromModelFindRef(nodes, BaseContentsNode, Labels);
        }

        public MyTree<XmlNode> FindEntireModelContents()
        {
            string xPath = @".//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor";
            List<XmlNode> nodes = ComputeXPath1(BaseContentsNode, xPath);
            return MyTree<XmlNode>.ComputeFromModelFindRef(nodes, BaseContentsNode, Labels);
        }

        protected void ParseLabels(string languageId)
        {
            List<XmlNode> nodes = ComputeXPath1(XPATH_LABEL_NODES(languageId));
            foreach (XmlNode node in nodes)
            {
                Labels.Add(node.Attributes["LabelId"].Value, node.Attributes["LabelValue"].Value);
            }
        }

        public void ParseLabelsFrom(XmlModelFileWrapper otherWrapper)
        {
            foreach (string labelId in otherWrapper.Labels.Keys)
            {
                Labels.Add(labelId, otherWrapper.Labels[labelId]);
            }
        }
    }
}
