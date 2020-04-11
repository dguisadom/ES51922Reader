using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent possibles range values for the DMM measurement modes (Range Byte on the documentation)
    /// </summary>
    internal enum RangeValue
    {
        /// <summary>
        /// represents byte value for the first range value on the current measurement mode
        /// </summary>
        First = 48,
        /// <summary>
        /// represents byte value for the second range value on the current measurement mode
        /// </summary>
        Second = 49,
        /// <summary>
        /// represents byte value for the third range value on the current measurement mode
        /// </summary>
        Third = 50,
        /// <summary>
        /// represents byte value for the fourth range value on the current measurement mode
        /// </summary>
        Fourth = 51,
        /// <summary>
        /// represents byte value for the fifth range value on the current measurement mode
        /// </summary>
        Fifth = 52,
        /// <summary>
        /// represents byte value for the sixth range value on the current measurement mode
        /// </summary>
        Sixth = 53,
        /// <summary>
        /// represents byte value for the seventh range value on the current measurement mode
        /// </summary>
        Seventh = 54,
        /// <summary>
        /// represents byte value for the eighth range value on the current measurement mode
        /// </summary>
        Eighth = 55
    }
}
