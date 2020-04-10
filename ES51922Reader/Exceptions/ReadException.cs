using System;
using System.Runtime.Serialization;

namespace ES51922Reader.Exceptions
{
    public class ReadException : Exception
    {
        public ReadException(string message) : base(message)
        {
        }

        public ReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
