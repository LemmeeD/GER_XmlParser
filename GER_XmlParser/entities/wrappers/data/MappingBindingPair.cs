using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.entities.wrappers.data
{
    public class MappingBindingPair : MappingPair
    {
        //FIELDS
        protected string _expression;
        // PROPERTIES
        public string DatasourcePath { get; set; }
        public string Expression { get { return _expression == null ? "" : _expression; } }

        // CONTRUCTORS
        public MappingBindingPair(string path, string datasourcePath)
        {
            _path = path;
            DatasourcePath = datasourcePath;
            _expression = null;
        }

        public MappingBindingPair(string path, string datasourcePath, string expression)
        {
            _path = path;
            DatasourcePath = datasourcePath;
            _expression = expression;
        }

        // METHODS
    }
}
