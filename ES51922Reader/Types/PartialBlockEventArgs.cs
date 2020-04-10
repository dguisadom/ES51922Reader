using System;
namespace ES51922Reader.Types
{
    public class PartialBlockEventArgs : EventArgs
    {
        public Byte[] DataBlock { get; private set; }
        public string Message { get; private set; }

        public PartialBlockEventArgs(Byte[] dataBlock, string message)
        {
            DataBlock = dataBlock;
            Message = message;
        }

    }
}
