namespace ES51922Reader.Exceptions
{
    /// <summary>
    /// Stores error messages contant values for reading operations
    /// </summary>
    internal static class ErrorMessages
    {
        /// <summary>
        /// Describes errors reading data form de port
        /// </summary>
        public const string ERROR_READING = "Error reading from provided port";
        /// <summary>
        /// Describes errors trying to identify current measurement mode.
        /// </summary>
        public const string WRONG_MEASURE_MODE = "Measure mode not recognized";
        /// <summary>
        /// Describes errors trying to convert measure data.
        /// </summary>
        public const string WRONG_MEASURE_DATA = "Partial or corrupted measure data received";
        /// <summary>
        /// Describes errors trying to identify range value measure data.
        /// </summary>
        public const string WRONG_RANGE_FOR_MEASURE_MODE = "The range does not apply for the current measure mode";
    }
}
