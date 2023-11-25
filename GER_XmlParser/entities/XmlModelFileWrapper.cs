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
        public const string BASE_CONTENTS_NODE_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel/Contents.";
        public const string BASIC_INFO_NODE1_XPATH = @"/ERSolutionVersion";
        public const string BASIC_INFO_NODE2_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel";
        public const string BASIC_INFO_NODE3_XPATH = @"/ERSolutionVersion/Contents./ERDataModelVersion/Model/ERDataModel";
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";
        protected XmlNode _basicInfoNode1;
        protected XmlNode _basicInfoNode2;
        protected XmlNode _basicInfoNode3;
        protected XmlNode _baseContentsNode;
        protected XmlNode _vendorNode;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        // PROPERTIES
        public XmlNode BasicInfoNode1 { get { return this._basicInfoNode1; } }
        public XmlNode BasicInfoNode2 { get { return this._basicInfoNode2; } }
        public XmlNode BasicInfoNode3 { get { return this._basicInfoNode3; } }
        public XmlNode BaseContentsNode { get { return this._baseContentsNode; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public string Vendor { get { return this._vendor; } }

        // CONSTRUCTORS
        public XmlModelFileWrapper(string filePath) : base(filePath)
        {
            this._basicInfoNode1 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE1_XPATH);
            this._basicInfoNode2 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE2_XPATH);
            this._basicInfoNode3 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE3_XPATH);
            this._baseContentsNode = this.XmlParser.SelectSingleNode(BASE_CONTENTS_NODE_XPATH);
            this._vendorNode = this.XmlParser.SelectSingleNode(VENDOR_NODE_XPATH);
            if ((this.BasicInfoNode1 == null) || (this.BasicInfoNode2 == null) || (this.BasicInfoNode3 == null) || (this.BaseContentsNode == null) || (this.VendorNode == null))
            {
                throw new InvalidModelException(string.Format("File individuato dal percorso '{0}' non valido come Model", filePath));
            }
            XmlAttribute temp;
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
        protected XmlNodeList ComputeFromBase(string xPath)
        {
            return this.Compute(this.BaseContentsNode, xPath);
        }

        public MyTree<XmlNode> FindReferences(string str)
        {
            string xPath = string.Format(@".//*[contains(@Name, '{0}')]", str);
            //string xPath = string.Format(@"(.//ERDataContainerDescriptorItem | .//ERDataContainerDescriptor[not(substring(@Name, string-length(@Name) - string-length('_1') +1) != '_1')])[contains(@Name, '{0}')]", str);
            XmlNodeList nodes = this.ComputeFromBase(xPath);
            return MyTree<XmlNode>.ComputeFromModelFindRef(nodes, this.BaseContentsNode);
        }
    }
}
