using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.entities
{
    public class MappingBindingPair : MappingPair
    {
        //FIELDS
        protected string _expression;
        // PROPERTIES
        public string DatasourcePath { get; set; }
        public string Expression { get { return this._expression == null ? "" : this._expression; } }

        // CONTRUCTORS
        public MappingBindingPair(string path, string datasourcePath)
        {
            this._path = path;
            this.DatasourcePath = datasourcePath;
            this._expression = null;
        }

        public MappingBindingPair(string path, string datasourcePath, string expression)
        {
            this._path = path;
            this.DatasourcePath = datasourcePath;
            this._expression = expression;
        }

        // METHODS
    }
}
