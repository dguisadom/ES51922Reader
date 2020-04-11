using System;
using System.Runtime.Serialization;

namespace ES51922Reader.Exceptions
{
    /// <summary>
    /// Represents an error trying to read from serial port
    /// </summary>
    public class ReadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.ReadException" /> class.
        /// </summary>
        /// <param name="message">Error message related to new exception</param>
        public ReadException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.ReadException" /> class.
        /// </summary>
        /// <param name="message">Error message related to new exception</param>
        /// <param name="innerException">Inner exception data</param>
        public ReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.ReadException" /> class.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context data</param>
        protected ReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
