using System;
namespace ES51922Reader.Types
{
    public class PartialBlockEventArgs : EventArgs
    {
        public byte[] DataBlock { get; set; }
    }
}
