using System;
namespace ES51922Reader.Types
{
    public class Status
    {
        public bool Judge { get; set; }
        public bool MinusSign { get; set; }
        public bool BatteryLow { get; set; }
        public bool InputOverload { get; set; }
        public bool MaximumValue { get; set; }
        public bool MinimumValue { get; set; }
        public bool RelativeValue { get; set; }
        public bool RMRValue { get; set; }
        public bool InputUnderlevel { get; set; }
        public bool MaximumPeak { get; set; }
        public bool MinimumPeak { get; set; }
        public bool DCMode { get; set; }
        public bool ACMode { get; set; }
        public bool AutomaticMode { get; set; }
        public bool FrequencyMeasurement { get; set; }
        public bool VBAR { get; set; }
        public bool HoldValue { get; set; }
        public bool LowPassFilterActive { get; set; }
    }
}
