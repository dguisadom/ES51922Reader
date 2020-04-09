using System;
using System.Runtime.Serialization;

namespace ES51922Reader.Exceptions
{
    public class PartialBlockException: Exception
    {
        public PartialBlockException() 
        {
        }

        public PartialBlockException(string message) : base(message)
        {
        }

        public PartialBlockException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PartialBlockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
