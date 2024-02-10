using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Net;

namespace GER_XmlParser.utils
{
    public class StringUtils
    {
        public static string escapeHtmlEntities(string str)
        {
            return WebUtility.HtmlDecode(str);
        }
    }
}
