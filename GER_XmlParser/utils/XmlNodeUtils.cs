using GER_XmlParser.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.utils
{
    internal class XmlNodeUtils
    {
        // FIELDS
        public const ShowAttributes SHOW_ATTRIBUTES = ShowAttributes.ONLY_LAST_NODE;
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public static List<XmlNode> ParentsChain(XmlNode node)
        {
            List<XmlNode> chains = new List<XmlNode>();
            chains.Add(node);
            return InnerParentsChain(node, chains);
        }

        public static List<XmlNode> ParentsChainReverse(XmlNode node)
        {
            List<XmlNode> result = ParentsChain(node);
            result.Reverse();
            return result;
        }

        protected static List<XmlNode> InnerParentsChain(XmlNode node, List<XmlNode> parents)
        {
            XmlNode parentNode = node.ParentNode;
            if ((parentNode != null) && (parentNode.LocalName != "#document"))
            {
                parents.Add(parentNode);
                return InnerParentsChain(parentNode, parents);
            }
            else
            {
                return parents;
            }
        }

        public static List<XmlNode> ParentsChainUntilReserve(XmlNode startingNode, XmlNode targetNode)
        {
            List<XmlNode> result = ParentsChainUntil(startingNode, targetNode, new HashSet<string>());
            result.Reverse();
            return result;
        }

        public static List<XmlNode> ParentsChainUntilReserve(XmlNode startingNode, XmlNode targetNode, HashSet<string> blacklistNodeNames)
        {
            List<XmlNode> result = ParentsChainUntil(startingNode, targetNode, blacklistNodeNames);
            result.Reverse();
            return result;
        }

        public static List<XmlNode> ParentsChainUntil(XmlNode startingNode, XmlNode targetNode)
        {
            List<XmlNode> chains = new List<XmlNode>();
            chains.Add(startingNode);
            return InnerParentsChainUntil(startingNode, targetNode, chains, new HashSet<string>());
        }

        public static List<XmlNode> ParentsChainUntil(XmlNode startingNode, XmlNode targetNode, HashSet<string> blacklistNodeNames)
        {
            List<XmlNode> chains = new List<XmlNode>();
            chains.Add(startingNode);
            return InnerParentsChainUntil(startingNode, targetNode, chains, blacklistNodeNames);
        }

        protected static List<XmlNode> InnerParentsChainUntil(XmlNode startingNode, XmlNode targetNode, List<XmlNode> parents, HashSet<string> blacklistNodeNames)
        {
            XmlNode parentNode = startingNode.ParentNode;
            if ((parentNode != null) && (parentNode.LocalName != "#document") && !parentNode.Equals(targetNode))
            {
                if (!blacklistNodeNames.Contains(parentNode.Name))
                {
                    parents.Add(parentNode);
                }
                return InnerParentsChainUntil(parentNode, targetNode, parents, blacklistNodeNames);
            }
            else
            {
                return parents;
            }
        }

        public static string Stringify(XmlNode node, bool showAttributes = true)
        {
            string result = "";
            string separator = " and ";
            if ((node.Attributes == null) || (showAttributes == false)) result = string.Format(@"/{0}", node.Name);
            else
            {
                string stringAttr = "[";
                foreach (XmlAttribute attr in node.Attributes)
                {
                    stringAttr += (string.Format(@"@{0} = '{1}'", attr.Name, attr.Value) + separator);
                }
                stringAttr = stringAttr.Remove(stringAttr.Length - separator.Length);
                stringAttr = (stringAttr + "]");
                result = string.Format(@"/{0}{1}", node.LocalName, stringAttr);
            }
            return result;
        }

        public static string PrettifyAsModel(XmlNode matchednode, XmlNode baseNode)
        {
            string result = "";
            string separator = " ==> ";
            int count = 0;
            List<XmlNode> chain = XmlNodeUtils.ParentsChainUntilReserve(matchednode, baseNode, new HashSet<string>() { "Contents." });
            foreach (XmlNode node in chain)
            {
                if (count == (chain.Count - 1)) result += StringifyAsModel(node);
                else result += (StringifyAsModel(node) + separator);
                count++;
            }
            return result;
        }

        public static string StringifyAsModel(XmlNode node)
        {
            string result = "";
            if (node.Attributes == null) throw new ArgumentException("Non dovrebbe essere possibile");
            else
            {
                string attrName = null;
                if (node.Attributes["Name"] != null) attrName = node.Attributes["Name"].Value;
                string attrLabel = null;
                if (node.Attributes["Label"] != null) attrLabel = node.Attributes["Label"].Value;

                if ((attrLabel != null) && (!attrLabel.StartsWith("@"))) result += attrLabel;
                if (result != "") result += string.Format(@"({0})", attrName);
                else result += attrName;
            }
            return result;
        }
    }
}
