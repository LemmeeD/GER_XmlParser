using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.exceptions
{
    class InvalidMappingException : Exception
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public InvalidMappingException() : base() { }
        public InvalidMappingException(string message) : base(message) { }
        public InvalidMappingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
