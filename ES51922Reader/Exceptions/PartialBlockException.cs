namespace ES51922Reader.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Types;
    /// <summary>
    /// Represents an errors tryin to get 14 bytes from serial data block
    /// </summary>
    public class PartialBlockException : Exception
    {
        public Byte[] PartialMeasureData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.PartialBlockException" /> class.
        /// </summary>
        /// <param name="message">Error message related to new exception</param>
        /// <param name="partialMeasureData">Partial data block</param>
        public PartialBlockException(string message, Byte[] partialMeasureData) : base(message)
        {
            PartialMeasureData = partialMeasureData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.PartialBlockException" /> class.
        /// </summary>
        /// <param name="message">Error message related to new exception</param>
        /// <param name="innerException">Inner exception data</param>
        /// <param name="partialMeasureData">Partial data block</param>
        public PartialBlockException(string message, Exception innerException, Byte[] partialMeasureData) : base(message, innerException)
        {
            PartialMeasureData = partialMeasureData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ES51922Reader.Exceptions.PartialBlockException" /> class.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context data</param>
        /// <param name="partialMeasureData">Partial data block</param>
        protected PartialBlockException(SerializationInfo info, StreamingContext context, Byte[] partialMeasureData) : base(info, context)
        {
            PartialMeasureData = partialMeasureData;
        }
    }
}
