namespace ES51922Reader.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Types;

    public class PartialBlockException : Exception
    {
        public Byte[] PartialMeasureData { get; private set; }

        public PartialBlockException(string message, Byte[] partialMeasureData) : base(message)
        {
            PartialMeasureData = partialMeasureData;
        }

        public PartialBlockException(string message, Exception innerException, Byte[] partialMeasureData) : base(message, innerException)
        {
            PartialMeasureData = partialMeasureData;
        }

        protected PartialBlockException(SerializationInfo info, StreamingContext context, Byte[] partialMeasureData) : base(info, context)
        {
            PartialMeasureData = partialMeasureData;
        }
    }
}
