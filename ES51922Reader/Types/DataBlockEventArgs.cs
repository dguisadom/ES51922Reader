using System;
namespace ES51922Reader.Types
{
    /// <summary>
    /// Prepares data for the <see cref="ES51922Reader.Reader.SerialReader.BlockReceived" /> event.
    /// </summary>
    internal class DataBlockEventArgs : EventArgs
    {
        /// <summary>
        /// Get the raw measure block
        /// </summary>
        public RawMeasureBlock RawMeasureBlock { get; private set; }

        /// <summary>
        /// Returns a <see cref="DataBlockEventArgs"/> instance
        /// </summary>
        /// <param name="rawMeasureBlock">raw measure block data of type <see cref="RawMeasureBlock"/></param>
        public DataBlockEventArgs(RawMeasureBlock rawMeasureBlock)
        {
            RawMeasureBlock = rawMeasureBlock;
        }
    }
}
