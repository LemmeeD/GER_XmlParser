using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.exceptions
{
    class InvalidModelException : Exception
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public InvalidModelException() : base() { }
        public InvalidModelException(string message) : base(message) { }
        public InvalidModelException(string message, Exception innerException) : base(message, innerException) { }
    }
}
