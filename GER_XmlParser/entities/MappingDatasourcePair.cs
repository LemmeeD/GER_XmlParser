using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.entities
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
            this._path = path;
            this.BindingPath = bindingPath;
            this.Expression = "";
        }

        public MappingDatasourcePair(string path, string bindingPath, string expression)
        {
            this._path = path;
            this.BindingPath = bindingPath;
            this.Expression = expression;
        }

        // METHODS
    }
}
