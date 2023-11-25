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
        public const string BASIC_INFO_NODE1_XPATH = @"/ERSolutionVersion";
        public const string BASIC_INFO_NODE2_XPATH = @"/ERSolutionVersion/Solution/ERSolution";
        public const string VENDOR_NODE_XPATH = @"/ERSolutionVersion/Solution/ERSolution/Vendor/ERVendor";

        protected const string FIRST_DATASOURCE_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Datasource/ERModelDefinition/Contents.";
        protected const string FIRST_BINDING_BASE_NODE_XPATH = @"/ERSolutionVersion/Contents./ERFormatMappingVersion/Mapping/ERFormatMapping/Binding/ERFormatBinding/Contents.";
        protected static Func<string, string> XPATH_FIND_ITEM = (string str) => { return string.Format(@".//ERModelItemDefinition[contains(@ParentPath, '{0}')] | .//ERModelItemValueDefinition[contains(@Name, '{0}')]", str); };
        protected XmlNode _basicInfoNode1;
        protected XmlNode _basicInfoNode2;
        protected XmlNode _vendorNode;
        protected XmlNode _datasourceNode;
        protected XmlNode _bindingNode;
        protected string _name;
        protected string _description;
        protected string _publicVersionNumber;
        protected string _vendor;
        // PROPERTIES
        public XmlNode BasicInfoNode1 { get { return this._basicInfoNode1; } }
        public XmlNode BasicInfoNode2 { get { return this._basicInfoNode2; } }
        public XmlNode VendorNode { get { return this._vendorNode; } }
        public XmlNode DatasourceNode { get { return this._datasourceNode; } }
        public XmlNode BindingNode { get { return this._bindingNode; } }
        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }
        public string PublicVersionNumber { get { return this._publicVersionNumber; } }
        public string Vendor { get { return this._vendor; } }

        // CONSTRUCTORS
        public XmlFormatFileWrapper(string filePath) : base(filePath)
        {
            this._basicInfoNode1 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE1_XPATH);
            this._basicInfoNode2 = this.XmlParser.SelectSingleNode(BASIC_INFO_NODE2_XPATH);
            this._vendorNode = this.XmlParser.SelectSingleNode(VENDOR_NODE_XPATH);

            this._datasourceNode = this.XmlParser.SelectSingleNode(FIRST_DATASOURCE_BASE_NODE_XPATH);
            this._bindingNode = this.XmlParser.SelectSingleNode(FIRST_BINDING_BASE_NODE_XPATH);
            if ((this.BasicInfoNode1 == null) || (this.BasicInfoNode2 == null) || (this.VendorNode == null) || (this.DatasourceNode == null) || (this.BindingNode == null))
            {
                throw new InvalidMappingException(string.Format("File individuato dal percorso '{0}' non valido come Format", filePath));
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

        public XmlNodeList FindReferences(string str)
        {
            string xPath = string.Format(@".//ERModelItemValueDefinition[contains(@Name, '{0}')]", str);
            return this.Compute(this.DatasourceNode, xPath);
        }

        public int RemoveRevisionNumberAttributes()
        {
            XmlNodeList nodes = this.Compute(@".//*[@RevisionNumber]");
            foreach (XmlNode node in nodes)
            {
                node.Attributes.RemoveNamedItem("RevisionNumber");
            }
            this.WriteFile();
            return nodes.Count;
        }
    }
}