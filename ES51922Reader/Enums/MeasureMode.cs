using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// Represent information about the DMM operation mode (Function Byte on the documentation)
    /// </summary>
    internal enum MeasureMode
    {
        /// <summary>
        /// Represents voltage measurement mode byte value
        /// </summary>
        Voltage = 59,

        /// <summary>
        /// Represents uA measurement mode byte value in auto measurement mode
        /// </summary>
        AutouACurrent = 61,

        /// <summary>
        /// Represents mA measurement mode byte value in auto measurement mode
        /// </summary>
        AutomACurrent = 63,

        /// <summary>
        /// Represents 22A limited current measurement mode byte value
        /// </summary>
        TwentyTwoAcurrent = 48,

        /// <summary>
        /// Represents current measurement mode byte value in manual measurement mode
        /// </summary>
        ManualACurrent = 57,

        /// <summary>
        /// Represents resistance measurement mode byte value
        /// </summary>
        Ohms = 51,

        /// <summary>
        /// Represents continuity measurement mode byte value
        /// </summary>
        Continuity = 53,

        /// <summary>
        /// Represents diode measurement mode byte value
        /// </summary>
        Diode = 49,

        /// <summary>
        /// Represents frecuency measurement mode byte value
        /// </summary>
        Frequency = 50,

        /// <summary>
        /// Represents capacitance measurement mode byte value
        /// </summary>
        Capacitance = 54,

        /// <summary>
        /// Represents temperature measurement mode byte value
        /// </summary>
        Temperature = 52,

        /// <summary>
        /// Represents ADP measurement mode byte value
        /// </summary>
        ADP = 62
    }
}
