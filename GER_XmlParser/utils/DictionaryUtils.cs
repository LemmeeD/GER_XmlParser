using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.utils
{
    public class DictionaryUtils
    {
        public static K GetFirstKeyFromValue<K, V>(Dictionary<K, V> dict, V value)
        {
            foreach (K key in dict.Keys)
            {
                if (dict[key].Equals(value)) return key;
            }
            throw new KeyNotFoundException();
        }
    }
}
