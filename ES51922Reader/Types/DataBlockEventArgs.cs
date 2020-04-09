using System;
namespace ES51922Reader.Types
{
    public class DataBlockEventArgs : EventArgs
    {
        public RawMeasureBlock RawMeasureBlock { get; set; }
    }
}
