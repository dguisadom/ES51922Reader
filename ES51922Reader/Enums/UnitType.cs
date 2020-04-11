using System;
namespace ES51922Reader.Enums
{
    /// <summary>
    /// represents all units that the Cyrustek can represent
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Represents milivolt voltage measurement unit
        /// </summary>
        mV,
        /// <summary>
        /// Represents volt voltage measurement unit
        /// </summary>
        V,
        /// <summary>
        /// Represents ohm resistance measurement unit
        /// </summary>
        Ohm,
        /// <summary>
        /// Represents kiloohm resistance measurement unit
        /// </summary>
        KOhm,
        /// <summary>
        /// Represents megaohm resistance measurement unit
        /// </summary>
        MOhm,
        /// <summary>
        /// Represents nanofarad capacitance measurement unit
        /// </summary>
        nF,
        /// <summary>
        /// Represents microfarad capacitance measurement unit
        /// </summary>
        uF,
        /// <summary>
        /// Represents milifarad capacitance measurement unit
        /// </summary>
        mF,
        /// <summary>
        /// Represents microampere current measurement unit
        /// </summary>
        uA,
        /// <summary>
        /// Represents miliampere current measurement unit
        /// </summary>
        mA,
        /// <summary>
        /// Represents ampere current measurement unit
        /// </summary>
        A,
        /// <summary>
        /// Represents hertz frecuency measurement unit
        /// </summary>
        Hz,
        /// <summary>
        /// Represents kilohertz frecuency measurement unit
        /// </summary>
        KHz,
        /// <summary>
        /// Represents megahertz frecuency measurement unit
        /// </summary>
        MHz,
        /// <summary>
        /// Represents percentage measurement unit
        /// </summary>
        Percent,
        /// <summary>
        /// Represents Celsius temperature measurement unit
        /// </summary>
        ºC,
        /// <summary>
        /// Represents Fahrenheit temperature measurement unit
        /// </summary>
        ºF
    }
}
