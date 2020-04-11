using System;
namespace ES51922Reader.Types
{
    /// <summary>
    /// Prepares data for the <see cref="MeasureReader.WrongBlockReceived" /> event.
    /// </summary>
    public class PartialBlockEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the data block received
        /// </summary>
        public byte[] DataBlock { get; private set; }
        /// <summary>
        /// Gets the error message related to the partial data block
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Returns a <see cref="PartialBlockEventArgs"/> instance
        /// </summary>
        /// <param name="dataBlock">raw measure block data byte array/></param>
        /// <param name="message">Error message related to partial block identification</param>
        public PartialBlockEventArgs(Byte[] dataBlock, string message)
        {
            DataBlock = dataBlock;
            Message = message;
        }

    }
}
