using GER_XmlParser.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GER_XmlParser.entities
{
    public class GERIdentifier
    {
        // FIELDS
        protected static Regex REGEX = new Regex(@"^\{(?<serial>.+)\}\,{0,1}(?<num>\d*)$");
        protected string _input;
        protected string _serial;
        protected int _number;
        // PROPERTIES
        public string Input { get { return this._input; } }
        public string Serial { get { return this._serial; } }
        public int Number { get { return this._number; } }
        public string NumberString { get { return this.Number < 0 ? "" : this.Number.ToString(); } }
        public string Description { get; set; }
        public string Name { get; set; }

        // CONSTRUCTORS
        public GERIdentifier(string _input)
        {
            this.init(_input);
        }

        public GERIdentifier(string _input, string _name, string _description)
        {
            this.init(_input);
            this.Name = _name;
            this.Description = _description;
        }

        // METHODS
        private void init(string _input)
        {
            Match match = REGEX.Match(_input);
            Group groupSerial = match.Groups["serial"];
            Group groupNumber = match.Groups["num"];
            if (!groupSerial.Success && !groupNumber.Success)
            {
                throw new InvalidGERIdentifierException("Identificatore GER malformato..");
            }
            if (groupSerial.Success) this._serial = groupSerial.Value;
            else this._serial = null;
            if (groupNumber.Success && (groupNumber.Value != "")) this._number = Int32.Parse(groupNumber.Value);
            else this._number = -1;
            this._input = _input;
        }

        public bool SameSerial(GERIdentifier that)
        {
            return this.Serial == that.Serial;
        }

        public bool SameVersion(GERIdentifier that)
        {
            return this.Number == that.Number;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (obj is GERIdentifier)
            {
                GERIdentifier that = obj as GERIdentifier;
                return (this.Serial == that.Serial) && (this.Number == that.Number);
            }
            else return false;
        }

        public override string ToString()
        {
            return this.Input;
        }

        public override int GetHashCode()
        {
            return this.Input.GetHashCode();
        }

        public GERIdentifier DeepCopy()
        {
            GERIdentifier deepCopy = new GERIdentifier(this.Input, this.Name, this.Description);
            return deepCopy;
        }
    }
}
