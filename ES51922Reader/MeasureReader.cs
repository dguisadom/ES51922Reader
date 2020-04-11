namespace ES51922Reader
{
    using System;
    using Exceptions;
    using Reader;
    using Types;
    /// <summary>
    /// Represents a measure reader to get ES51922 based DMMs measurements
    /// </summary>
    public class MeasureReader
    {
        /// <summary>
        /// Serial reader instance to communicate with DMM
        /// </summary>
        private readonly SerialReader reader;
        /// <summary>
        /// Indicates that a measure was received from the DMM
        /// </summary>
        public event EventHandler<MeasureReceivedEventArgs> MeasureReceived;
        /// <summary>
        /// Indicates that a partial or wrong measure was received from the DMM
        /// </summary>
        public event EventHandler<PartialBlockEventArgs> WrongBlockReceived;
        /// <summary>
        /// Indicates that an error was receive trying to read a measure
        /// </summary>
        public event EventHandler<ErrorReadingEventArgs> ErrorReading;

        public MeasureReader(string portName)
        {
            reader = new SerialReader(portName);
            reader.BlockReceived += Reader_BlockReceived;
            reader.ReadError += Reader_ReadError;
        }

        /// <summary>
        /// Opens the serial port connection and starts reading from the DMM 
        /// </summary>
        public void Start()
        {
            reader.SerialPort.Open();
        }


        /// <summary>
        /// Closes the serial port connection and starts reading from the DMM 
        /// </summary>
        public void Stop()
        {
            reader.SerialPort.Close();
        }

        /// <summary>
        /// Handle read error events
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">Event args</param>
        private void Reader_ReadError(object sender, ErrorReadingEventArgs e)
        {
            ErrorReading?.Invoke(this, e);
        }


        /// <summary>
        /// Handle block received events
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">Event args</param>
        private void Reader_BlockReceived(object sender, Types.DataBlockEventArgs e)
        {
            try
            {
                var measureBlock = new MeasureBlock(e.RawMeasureBlock);
                MeasureReceived?.Invoke(this, new MeasureReceivedEventArgs(measureBlock));

            }
            catch(PartialBlockException ex)
            {
                WrongBlockReceived?.Invoke(this, new PartialBlockEventArgs(e.RawMeasureBlock.DataBlock,ex.Message));
            }
        }
    }
}
