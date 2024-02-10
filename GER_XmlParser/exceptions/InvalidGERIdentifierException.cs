using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.exceptions
{
    public class InvalidGERIdentifierException : Exception
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public InvalidGERIdentifierException() : base() { }
        public InvalidGERIdentifierException(string message) : base(message) { }
        public InvalidGERIdentifierException(string message, Exception innerException) : base(message, innerException) { }
    }
}
