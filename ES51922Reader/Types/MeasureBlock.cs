using System;
using ES51922Reader.Enums;
using ES51922Reader.Exceptions;

namespace ES51922Reader.Types
{
    public class MeasureBlock
    {
        private RawMeasureBlock rawBlock;
        private int rangeDivider = 1;

        public double Value { get; private set; }
        public UnitType Unit { get; private set; }
        public MeasureType MeasureType { get; private set; }
        public Status Status { get; private set; }


        public MeasureBlock(RawMeasureBlock rawMeasureBlock)
        {
            rawBlock = rawMeasureBlock;

            ProcessStatus();

            ProcessMeasureModeAndUnit();

            ProcessValue();
        }



        private void ProcessValue()
        {
            double unprocessedValue = 0;
            unprocessedValue += ((rawBlock.Digit0 - 48));
            unprocessedValue += ((rawBlock.Digit1 - 48) * 10);
            unprocessedValue += ((rawBlock.Digit2 - 48) * 100);
            unprocessedValue += ((rawBlock.Digit3 - 48) * 1000);
            unprocessedValue += ((rawBlock.Digit4 - 48) * 10000);

            Value = unprocessedValue / rangeDivider;
        }

        private void ProcessMeasureModeAndUnit()
        {
            switch (rawBlock.Function)
            {
                case (byte)MeasureMode.Voltage:
                    {
                        MeasureType = MeasureType.Voltage;
                        ProcessVoltageRange();
                        break;
                    }
                case (byte)MeasureMode.AutouACurrent:
                    {
                        MeasureType = MeasureType.Current;
                        ProcessAutoCurrentRange(UnitType.uA);
                        break;
                    }
                case (byte)MeasureMode.AutomACurrent:
                    {
                        MeasureType = MeasureType.Current;
                        ProcessAutoCurrentRange(UnitType.mA);
                        break;
                    }
                case (byte)MeasureMode.TwentyTwoAcurrent:
                    {
                        MeasureType = MeasureType.Current;
                        if (Status.FrequencyMeasurement)
                        {
                            Unit = Status.Judge ? UnitType.Percent : UnitType.Hz;
                            rangeDivider = 10;
                        }
                        else
                        {
                            rangeDivider = 1000;
                            Unit = UnitType.A;
                        }
                        break;
                    }
                case (byte)MeasureMode.ManualACurrent:
                    {
                        MeasureType = MeasureType.Current;
                        ProcessManualCurrentRange();
                        break;
                    }
                case (byte)MeasureMode.Ohms:
                    {
                        MeasureType = MeasureType.Resistance;
                        ProcessResistanceRange();
                        break;
                    }
                case (byte)MeasureMode.Continuity:
                    {
                        MeasureType = MeasureType.Continuity;
                        Unit = UnitType.Ohms;
                        rangeDivider = 100;
                        break;
                    }
                case (byte)MeasureMode.Diode:
                    {
                        MeasureType = MeasureType.Diode;
                        Unit = UnitType.V;
                        rangeDivider = 10000;
                        break;
                    }
                case (byte)MeasureMode.Frequency:
                    {
                        MeasureType = MeasureType.Frequency;
                        ProcessFrecuencyRange();
                        break;
                    }
                case (byte)MeasureMode.Capacitance:
                    {
                        MeasureType = MeasureType.Capacitance;
                        ProcessCapacitanceRange();
                        break;
                    }
                case (byte)MeasureMode.Temperature:
                    {
                        MeasureType = MeasureType.Temperature;
                        Unit = Status.Judge ? UnitType.ºC : UnitType.ºF;
                        rangeDivider = 10;
                        break;
                    }
                case (byte)MeasureMode.ADP:
                    {
                        MeasureType = MeasureType.ADP;
                        ProcessManualCurrentRange();
                        break;
                    }
                default:
                    throw new InvalidOperationException("Wrong block data");
            }
        }


        private void ProcessStatus()
        {
            Status = new Status();
            Status.Judge = ((rawBlock.Status & (byte)StatusValue.Judge) != 0);
            Status.MinusSign = ((rawBlock.Status & (byte)StatusValue.Sign) != 0);
            Status.BatteryLow = ((rawBlock.Status & (byte)StatusValue.BATT) != 0);
            Status.InputOverload = ((rawBlock.Status & (byte)StatusValue.OL) != 0);

            Status.MaximumValue = ((rawBlock.Option1 & (byte)RelativeStatus.MAX) != 0);
            Status.MinimumValue = ((rawBlock.Option1 & (byte)RelativeStatus.MIN) != 0);
            Status.RelativeValue = ((rawBlock.Option1 & (byte)RelativeStatus.REL) != 0);
            Status.RMRValue = ((rawBlock.Option1 & (byte)RelativeStatus.RMR) != 0);

            Status.InputUnderlevel = ((rawBlock.Option2 & (byte)LimitStatus.UL) != 0);
            Status.MaximumPeak = ((rawBlock.Option2 & (byte)LimitStatus.PMAX) != 0);
            Status.MinimumPeak = ((rawBlock.Option2 & (byte)LimitStatus.PMIN) != 0);

            Status.DCMode = ((rawBlock.Option3 & (byte)OperationMode.DC) != 0);
            Status.ACMode = ((rawBlock.Option3 & (byte)OperationMode.AC) != 0);
            Status.AutomaticMode = ((rawBlock.Option3 & (byte)OperationMode.AUTO) != 0);
            Status.FrequencyMeasurement = ((rawBlock.Option3 & (byte)OperationMode.VAHZ) != 0);

            Status.VBAR = ((rawBlock.Option4 & (byte)ExtraOperationMode.VBAR) != 0);
            Status.HoldValue = ((rawBlock.Option4 & (byte)ExtraOperationMode.HOLD) != 0);
            Status.LowPassFilterActive = ((rawBlock.Option4 & (byte)ExtraOperationMode.LPF) != 0);
        }


        private void ProcessCapacitanceRange()
        {
            switch (rawBlock.Range)
            {
                case (byte)RangeValue.First:
                    {
                        rangeDivider = 1000;
                        Unit = UnitType.nF;
                        break;
                    }
                case (byte)RangeValue.Second:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.nF;
                        break;
                    }
                case (byte)RangeValue.Third:
                    {
                        rangeDivider = 10000;
                        Unit = UnitType.uF;
                        break;
                    }
                case (byte)RangeValue.Fourth:
                    {
                        rangeDivider = 1000;
                        Unit = UnitType.uF;
                        break;
                    }
                case (byte)RangeValue.Fifth:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.uF;
                        break;
                    }
                case (byte)RangeValue.Sixth:
                    {
                        rangeDivider = 10000;
                        Unit = UnitType.mF;
                        break;
                    }
                case (byte)RangeValue.Seventh:
                    {
                        rangeDivider = 1000;
                        Unit = UnitType.mF;
                        break;
                    }
                case (byte)RangeValue.Eighth:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.mF;
                        break;
                    }
                default:
                    {
                        throw new PartialBlockException("Wrong Data block");
                    }
            }
        }

        private void ProcessFrecuencyRange()
        {
            switch (rawBlock.Range)
            {
                case (byte)RangeValue.First:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.Hz;
                        break;
                    }
                case (byte)RangeValue.Second:
                    {
                        rangeDivider = 10;
                        Unit = UnitType.Hz;
                        break;
                    }
                case (byte)RangeValue.Fourth:
                    {
                        rangeDivider = 1000;
                        Unit = UnitType.KHz;
                        break;
                    }
                case (byte)RangeValue.Fifth:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.KHz;
                        break;
                    }
                case (byte)RangeValue.Sixth:
                    {
                        rangeDivider = 10000;
                        Unit = UnitType.MHz;
                        break;
                    }
                case (byte)RangeValue.Seventh:
                    {
                        rangeDivider = 1000;
                        Unit = UnitType.MHz;
                        break;
                    }
                case (byte)RangeValue.Eighth:
                    {
                        rangeDivider = 100;
                        Unit = UnitType.MHz ;
                        break;
                    }
                default:
                    {
                        throw new PartialBlockException("Wrong Data block");
                    }
            }
        }

        private void ProcessResistanceRange()
        {
            if (Status.FrequencyMeasurement)
            {
                Unit = Status.Judge ? UnitType.Percent : UnitType.Hz;
                rangeDivider = 10;
            }
            else
            {

                switch (rawBlock.Range)
                {
                    case (byte)RangeValue.First:
                        {
                            rangeDivider = 100;
                            Unit = UnitType.Ohms;
                            break;
                        }
                    case (byte)RangeValue.Second:
                        {
                            rangeDivider = 10000;
                            Unit = UnitType.KOhms;
                            break;
                        }
                    case (byte)RangeValue.Third:
                        {
                            rangeDivider = 1000;
                            Unit = UnitType.KOhms;
                            break;
                        }
                    case (byte)RangeValue.Fourth:
                        {
                            rangeDivider = 100;
                            Unit = UnitType.KOhms;
                            break;
                        }
                    case (byte)RangeValue.Fifth:
                        {
                            rangeDivider = 10000;
                            Unit = UnitType.MOhms;
                            break;
                        }
                    case (byte)RangeValue.Sixth:
                        {
                            rangeDivider = 1000;
                            Unit = UnitType.MOhms;
                            break;
                        }
                    case (byte)RangeValue.Seventh:
                        {
                            rangeDivider = 100;
                            Unit = UnitType.MOhms;
                            break;
                        }
                    default:
                        {
                            throw new PartialBlockException("Wrong Data block");
                        }
                }
            }
        }


        private void ProcessVoltageRange()
        {
            if (Status.FrequencyMeasurement)
            {
                Unit = Status.Judge ? UnitType.Percent : UnitType.Hz;
                rangeDivider = 10;
            }
            else
            {
                Unit = UnitType.V;

                switch (rawBlock.Range)
                {
                    case (byte)RangeValue.First:
                        {
                            rangeDivider = 10000;
                            break;
                        }
                    case (byte)RangeValue.Second:
                        {
                            rangeDivider = 1000;
                            break;
                        }
                    case (byte)RangeValue.Third:
                        {
                            rangeDivider = 100;
                            break;
                        }
                    case (byte)RangeValue.Fourth:
                        {
                            rangeDivider = 10;
                            break;
                        }
                    case (byte)RangeValue.Fifth:
                        {
                            rangeDivider = 100;
                            Unit = UnitType.mV;
                            break;
                        }
                    default:
                        {
                            throw new PartialBlockException("Wrong Data block");
                        }
                }
            }
        }



        private void ProcessManualCurrentRange()
        {
            if (Status.FrequencyMeasurement)
            {
                Unit = Status.Judge ? UnitType.Percent : UnitType.Hz;
                rangeDivider = 10;
            }
            else
            {
                Unit = UnitType.A;

                switch (rawBlock.Range)
                {
                    case (byte)RangeValue.First:
                        {
                            rangeDivider = 10000;
                            break;
                        }
                    case (byte)RangeValue.Second:
                        {
                            rangeDivider = 1000;
                            break;
                        }
                    case (byte)RangeValue.Third:
                        {
                            rangeDivider = 100;
                            break;
                        }
                    case (byte)RangeValue.Fourth:
                        {
                            rangeDivider = 10;
                            break;
                        }
                    case (byte)RangeValue.Fifth:
                        {
                            rangeDivider = 1;
                            break;
                        }
                    default:
                        {
                            throw new PartialBlockException("Wrong Data block");
                        }
                }
            }
        }

        /// <summary>
        /// Process auto Current range values related to VBAR state
        /// </summary>
        /// <param name="unitType"></param>
        private void ProcessAutoCurrentRange(UnitType unitType)
        {
            if (Status.FrequencyMeasurement)
            {
                Unit = Status.Judge ? UnitType.Percent : UnitType.Hz;
                rangeDivider = 10;
            }
            else
            {
                switch (rawBlock.Range)
                {
                    case (byte)RangeValue.First:
                        {
                            rangeDivider = 100*(unitType == UnitType.mA ? 10:1);
                            break;
                        }
                    case (byte)RangeValue.Second:
                        {
                            rangeDivider = 10 * (unitType == UnitType.mA ? 10 : 1);
                            break;
                        }
                    default:
                        {
                            throw new PartialBlockException("Wrong Data block");
                        }
                }
                Unit = Status.VBAR ? UnitType.A: unitType;
            }
        }
    }
}
