using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent posible Status values. (Status byte of the documentation
    /// </summary>
    public enum StatusValue
    {
        /// <summary>
        ///
        /// When Measurement mode is Temperature Bit is 1 when unit is ºC, 0 when is ºF
        /// In another kind of measurement. Judge is 1 if measure is a percentage
        /// </summary>
        Judge = 8,
        /// <summary>
        /// Indicates when minus sign on the LCD panel is on or off
        /// </summary>
        Sign = 4,
        /// <summary>
        /// BATT field is 1 when battery low condition is true
        /// </summary>
        BATT = 2,
        /// <summary>
        /// OL indicates input overflow.
        /// </summary>
        OL = 1
    }
}
