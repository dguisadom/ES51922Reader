using System;
namespace ES51922Reader.Types
{
    public class RawMeasureBlock
    {

        public Byte Range { get; private set; }
        public Byte Digit4 { get; private set; }
        public Byte Digit3 { get; private set; }
        public Byte Digit2 { get; private set; }
        public Byte Digit1 { get; private set; }
        public Byte Digit0 { get; private set; }
        public Byte Function { get; private set; }
        public Byte Status { get; private set; }
        public Byte Option1 { get; private set; }
        public Byte Option2 { get; private set; }
        public Byte Option3 { get; private set; }
        public Byte Option4 { get; private set; }


        public RawMeasureBlock(Byte[] dataBlock)
        {
            Range = dataBlock[0];
            Digit4 = dataBlock[1];
            Digit3 = dataBlock[2];
            Digit2 = dataBlock[3];
            Digit1 = dataBlock[4];
            Digit0 = dataBlock[5];
            Function = dataBlock[6];
            Status = dataBlock[7];
            Option1 = dataBlock[8];
            Option2 = dataBlock[9];
            Option3 = dataBlock[10];
            Option4 = dataBlock[11];
        }
    }

}
