using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.utils
{
    public class XmlNodeListUtils
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public static List<XmlNode> ToSortedList(XmlNodeList nodes)
        {
            Comparison<XmlNode> comparison = delegate (XmlNode node1, XmlNode node2)
            {
                return node1.Name.CompareTo(node2.Name);
            };
            return ToSortedList(nodes, comparison);
        }

        public static List<XmlNode> ToSortedList(XmlNodeList nodes, Comparison<XmlNode> comparison)
        {
            List<XmlNode> result = new List<XmlNode>();
            foreach (XmlNode node in nodes)
            {
                result.Add(node);
            }
            result.Sort(comparison);
            return result;
        }
    }
}
