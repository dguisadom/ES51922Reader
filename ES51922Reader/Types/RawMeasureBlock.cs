using System;
using ES51922Reader.Exceptions;

namespace ES51922Reader.Types
{
    /// <summary>
    /// Represent a raw measure block with separated bytes identification
    /// </summary>
    public class RawMeasureBlock
    {
        /// <summary>
        /// Gets the whole byte array data block included carriage return and line feed bytes
        /// </summary>
        public byte[] DataBlock { get; private set; }
        /// <summary>
        /// Gets the range byte block
        /// </summary>
        public byte Range { get; private set; }
        /// <summary>
        /// Gets the tens of thousands digit byte block
        /// </summary>
        public byte Digit4 { get; private set; }
        /// <summary>
        /// Gets the thousands digit byte block
        /// </summary>
        public byte Digit3 { get; private set; }
        /// <summary>
        /// Gets the hundreds byte block
        /// </summary>
        public byte Digit2 { get; private set; }
        /// <summary>
        /// Gets the tens byte block
        /// </summary>
        public byte Digit1 { get; private set; }
        /// <summary>
        /// Gets the units byte block
        /// </summary>
        public byte Digit0 { get; private set; }
        /// <summary>
        /// Gets the function byte block
        /// </summary>
        public byte Function { get; private set; }
        /// <summary>
        /// Gets the status byte block
        /// </summary>
        public byte Status { get; private set; }
        /// <summary>
        /// Gets the option 1 byte block
        /// </summary>
        public byte Option1 { get; private set; }
        /// <summary>
        /// Gets the option 2 byte block
        /// </summary>
        public byte Option2 { get; private set; }
        /// <summary>
        /// Gets the option 3 byte block
        /// </summary>
        public byte Option3 { get; private set; }
        /// <summary>
        /// Gets the option 4 byte block
        /// </summary>
        public byte Option4 { get; private set; }


        /// <summary>
        /// Initializes a new instance of <see cref="RawMeasureBlock"/>
        /// </summary>
        /// <param name="dataBlock"></param>
        public RawMeasureBlock(Byte[] dataBlock)
        {
            if (dataBlock.Length == 14)
            {
                DataBlock = dataBlock;
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
            else
            {
                throw new PartialBlockException(ErrorMessages.WRONG_MEASURE_DATA,dataBlock);
            }
        }
    }

}
