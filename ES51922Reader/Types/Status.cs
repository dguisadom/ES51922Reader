using System;
namespace ES51922Reader.Types
{
    /// <summary>
    /// Represents a status of a ES51922 measure
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Gets the judge flag value, related to temperature unit or hz/percentage measurement state.
        /// </summary>
        public bool Judge { get; internal set; }
        /// <summary>
        /// Gets the minus sign state flag state
        /// </summary>
        public bool MinusSign { get; internal set; }
        /// <summary>
        /// Gets the low battery flag state
        /// </summary>
        public bool LowBattery { get; internal set; }
        /// <summary>
        /// Gets the input overload flag state
        /// </summary>
        public bool InputOverload { get; internal set; }
        /// <summary>
        /// Gets the maximum value flag state
        /// </summary>
        public bool MaximumValue { get; internal set; }
        /// <summary>
        /// Gets the minimum value flag state
        /// </summary>
        public bool MinimumValue { get; internal set; }
        /// <summary>
        /// Gets the relative value flag state
        /// </summary>
        public bool RelativeValue { get; internal set; }
        /// <summary>
        /// Gets the RMR value flag state
        /// </summary>
        public bool RMRValue { get; internal set; }
        /// <summary>
        /// Gets the input under level flag state
        /// </summary>
        public bool InputUnderlevel { get; internal set; }
        /// <summary>
        /// Gets the maximum peak flag state
        /// </summary>
        public bool MaximumPeak { get; internal set; }
        /// <summary>
        /// Gets the minimum peak flag state
        /// </summary>
        public bool MinimumPeak { get; internal set; }
        /// <summary>
        /// Gets the DC measurement mode flag state
        /// </summary>
        public bool DCMode { get; internal set; }
        /// <summary>
        /// Gets the AC measurement mode flag state
        /// </summary>
        public bool ACMode { get; internal set; }
        /// <summary>
        /// Gets the automatic measurement mode flag state
        /// </summary>
        public bool AutomaticMode { get; set; }
        /// <summary>
        /// Gets the frequency measurement mode flag state
        /// </summary>
        public bool FrequencyMeasurement { get; internal set; }
        /// <summary>
        /// Gets the VBAR flag state. Related to current measurement mode.
        /// </summary>
        public bool VBAR { get; internal set; }
        /// <summary>
        /// Gets the hold value flag state
        /// </summary>
        public bool HoldValue { get; internal set; }
        /// <summary>
        /// Gets the low pass filter status flag.
        /// </summary>
        public bool LowPassFilterActive { get; internal set; }
    }
}
