using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent posible relative status (Option 1 Byte of the documentation)
    /// </summary>
    public enum RelativeStatus
    {
        /// <summary>
        /// Indicates if RMR status is present
        /// </summary>
        RMR = 1,
        /// <summary>
        /// Indicates if DMM is in relative mode
        /// </summary>
        REL = 2,
        /// <summary>
        /// indicates if DMM is in MIN mode
        /// </summary>
        MIN = 4,
        /// <summary>
        /// Indicates if DMM is in MAX mode
        /// </summary>
        MAX = 8,
    }
}
