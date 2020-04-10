using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent information about the DMM operation mode (Option 3 Byte of the documentation)
    /// </summary>
    internal enum OperationMode
    {
        /// <summary>
        /// Represent frequency measurement.
        /// </summary>
        VAHZ = 1,
        /// <summary>
        /// Represent automatic operation mode.
        /// </summary>
        AUTO = 2,
        /// <summary>
        /// Repesent AC operation mode.
        /// </summary>
        AC = 4,
        /// <summary>
        /// Represent DC operation mode.
        /// </summary>
        DC = 8
    }
}
