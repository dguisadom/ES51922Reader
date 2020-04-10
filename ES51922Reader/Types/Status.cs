using System;
namespace ES51922Reader.Types
{
    public class Status
    {
        public bool Judge { get; internal set; }
        public bool MinusSign { get; internal set; }
        public bool BatteryLow { get; internal set; }
        public bool InputOverload { get; internal set; }
        public bool MaximumValue { get; internal set; }
        public bool MinimumValue { get; internal set; }
        public bool RelativeValue { get; internal set; }
        public bool RMRValue { get; internal set; }
        public bool InputUnderlevel { get; internal set; }
        public bool MaximumPeak { get; internal set; }
        public bool MinimumPeak { get; internal set; }
        public bool DCMode { get; internal set; }
        public bool ACMode { get; internal set; }
        public bool AutomaticMode { get; set; }
        public bool FrequencyMeasurement { get; internal set; }
        public bool VBAR { get; internal set; }
        public bool HoldValue { get; internal set; }
        public bool LowPassFilterActive { get; internal set; }
    }
}
