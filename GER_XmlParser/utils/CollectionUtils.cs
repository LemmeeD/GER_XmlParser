using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using GER_XmlParser.enums;
using GER_XmlParser.utils;

namespace GER_XmlParser.utils
{
    internal class CollectionUtils
    {
        // FIELDS
        public const bool PRINT_INDEXES = false;
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public static string Stringify<T>(ICollection<T> collection, Func<T, string> stringifyFunction, string separator = ", ", string prefix = "", string postfix = "")
        {
            string result = separator;
            int count = 0;
            foreach (T elem in collection)
            {
                if (PRINT_INDEXES) result += string.Format(@"[{0}/{1}] ", count + 1, collection.Count);
                if (count == (collection.Count - 1)) result += stringifyFunction(elem);
                else result += (stringifyFunction(elem) + separator);
                count++;
            }
            result += postfix;
            return result;
        }

        public static string Stringify<T>(ICollection<T> collection, string separator = ", ", string prefix = "", string postfix = "")
        {
            return Stringify<T>(collection, (T t) => { return t.ToString(); }, separator, prefix, postfix);
        }

        public static string StringifyNodeList(List<XmlNode> nodes, ShowAttributes showAttributes)
        {
            string result = "";
            int count = 0;
            bool showAttr = false;
            foreach (XmlNode node in nodes)
            {
                if (showAttributes == ShowAttributes.NONE) showAttr = false;
                else if (showAttributes == ShowAttributes.ONLY_LAST_NODE)
                {
                    if (count == (nodes.Count - 1)) showAttr = true;
                    else showAttr = false;
                }
                else if (showAttributes == ShowAttributes.ALL) showAttr = true;
                else throw new ApplicationException("Unsupported ShowAttributes enum..");

                result += XmlNodeUtils.Stringify(node, showAttr);
                count++;
            }
            return result;
        }

        public static string PrettifyNodeListAsModel(List<XmlNode> nodes, XmlNode baseNode)
        {
            return XmlNodeUtils.PrettifyAsModel(nodes[nodes.Count - 1], baseNode);
        }
    }
}
