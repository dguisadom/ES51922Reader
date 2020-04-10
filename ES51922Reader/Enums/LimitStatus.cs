using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent information about the DDM limits states (option 2 byte on the documentation)
    /// </summary>
    internal enum LimitStatus
    {
        /// <summary>
        /// Represent minimum peak value measurement
        /// </summary>
        PMIN = 2,
        /// <summary>
        /// Represent maximum peak valuemeasurement
        /// </summary>
        PMAX = 4,
        /// <summary>
        /// Represent Underlevel measurement
        /// </summary>
        UL = 8
    }
}
