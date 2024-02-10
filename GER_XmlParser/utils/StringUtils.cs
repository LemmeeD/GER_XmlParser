using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace GER_XmlParser.utils
{
    public class StringUtils
    {
        public static string escapeHtmlEntities(string str)
        {
            return WebUtility.HtmlDecode(str);
        }

        public static List<string> cumulativeSplit(string str, char separator)
        {
            List<string> result = new List<string>();
            string[] splitString = str.Split(separator);
            string cumulativeStr = "";
            int count = 0;
            foreach (string s in splitString)
            {
                if (count == 0)
                {
                    cumulativeStr += s;
                }
                else
                {
                    cumulativeStr += (separator + s);
                }
                result.Add(cumulativeStr);
                count++;
            }
            return result;
        }

        public static string StringifyAsMapping(string name, Dictionary<string, string> labels)
        {
            string result = "";
            try
            {
                string label = labels[name];
                result = String.Format(@"{0}({1})", label, name);
            }
            catch (KeyNotFoundException)
            {
                result = name;
            }
            return result;
        }
    }
}
