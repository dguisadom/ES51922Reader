using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represents information about the DDM limits states (option 2 byte on the documentation)
    /// </summary>
    internal enum LimitStatus
    {
        /// <summary>
        /// Represents minimum peak value measurement
        /// </summary>
        PMIN = 2,
        /// <summary>
        /// Represents maximum peak value measurement
        /// </summary>
        PMAX = 4,
        /// <summary>
        /// Represents Underlevel measurement oparation
        /// </summary>
        UL = 8
    }
}
