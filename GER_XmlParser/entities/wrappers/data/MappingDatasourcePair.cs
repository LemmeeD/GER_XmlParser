using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.entities.wrappers.data
{
    public class MappingDatasourcePair : MappingPair
    {
        // FIELDS
        // PROPERTIES
        public string BindingPath { get; set; }
        public string Expression { get; set; }

        // CONTRUCTORS
        public MappingDatasourcePair(string path, string bindingPath)
        {
            _path = path;
            BindingPath = bindingPath;
            Expression = "";
        }

        public MappingDatasourcePair(string path, string bindingPath, string expression)
        {
            _path = path;
            BindingPath = bindingPath;
            Expression = expression;
        }

        // METHODS
    }
}
