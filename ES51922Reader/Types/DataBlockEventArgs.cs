using System;
namespace ES51922Reader.Types
{
    internal class DataBlockEventArgs : EventArgs
    {
        public RawMeasureBlock RawMeasureBlock { get; set; }
    }
}
