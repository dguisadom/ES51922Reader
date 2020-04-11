using System;
namespace ES51922Reader.Types
{
    /// <summary>
    /// Prepares data for the <see cref="MeasureReader.ErrorReading" /> event.
    /// </summary>
    public class ErrorReadingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the error message related to the partial data block
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Returns a <see cref="ErrorReadingEventArgs"/> instance
        /// </summary>
        /// <param name="message">Error message related to partial block identification</param>
        public ErrorReadingEventArgs( string message)
        {
            Message = message;
        }

    }
}
