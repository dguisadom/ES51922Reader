using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent information about the DMM extra operation mode (Option 4 Byte of the documentation)
    /// </summary>
    public enum ExtraOperationMode
    {
        /// <summary>
        /// Indicates that low-pass-filter function is active.
        /// </summary>
        LPF = 1,
        /// <summary>
        /// Indicates that hold mode is active.
        /// </summary>
        HOLD = 2,
        /// <summary>
        /// HIGH modify current measurement mode.
        /// </summary>
        VBAR = 4
    }
}
