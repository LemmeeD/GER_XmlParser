using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.entities.wrappers.data
{
    public class FormatPair
    {
        // FIELDS
        protected XmlNode _node;
        // PROPERTIES
        public XmlNode Node { get { return this._node; } }
        public XmlNode BindingNode { get; set; }

        // CONSTRUCTORS
        public FormatPair(XmlNode node)
        {
            this._node = node;
            this.BindingNode = null;
        }

        public FormatPair(XmlNode node, XmlNode bindingNode)
        {
            this._node = node;
            this.BindingNode = bindingNode;
        }

        // METHODS
        public override string ToString()
        {
            return this.Node.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (obj is FormatPair)
            {
                FormatPair that = obj as FormatPair;
                return this.Node.Equals(that.Node);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return this.Node.GetHashCode();
        }
    }
}
