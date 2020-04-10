namespace ES51922Reader.Exceptions
{
    public static class ErrorMessages
    {
        public const string ERROR_READING = "Error reading from provided port";
        public const string WRONG_MEASURE_MODE = "Measure mode not recognized";
        public const string WRONG_MEASURE_DATA = "Partial or corrupted measure data received";
        public const string WRONG_RANGE_FOR_MEASURE_MODE = "The range does not apply for the current measure mode";
    }
}
