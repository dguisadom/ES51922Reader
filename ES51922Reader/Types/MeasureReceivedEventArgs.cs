using System;
namespace ES51922Reader.Types
{
    /// <summary>
    /// Prepares data for the <see cref="MeasureReader.MeasureReceived" /> event.
    /// </summary>
    public class MeasureReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the measure block data
        /// </summary>
        public MeasureBlock MeasureBlock { get; private set; }

        /// <summary>
        /// Returns a <see cref="MeasureReceivedEventArgs"/> instance
        /// </summary>
        /// <param name="rawMeasureBlock">Measure block data of type <see cref="RawMeasureBlock"/></param>
        public MeasureReceivedEventArgs(MeasureBlock measureBlock)
        {
            MeasureBlock = measureBlock;
        }
    }
}
