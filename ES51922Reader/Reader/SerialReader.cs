namespace ES51922Reader.Reader
{
    using System;
    using System.IO.Ports;
    using Exceptions;
    using Types;

    /// <summary>
    /// Represents a serial reader resource that abstract SerialPort configuration for ES51922
    /// </summary>
    internal class SerialReader
    {
        private const int BAUD_RATE = 19200;
        private const Parity PARITY = Parity.Odd;
        private const int DATA_BITS = 7;
        private const StopBits STOP_BITS = StopBits.One;
        private const Handshake HANDSHAKE = Handshake.None;
        private const bool DTR_ENABLED = true;
        private const int TIMEOUT = 500;

        /// <summary>
        /// serial port resource
        /// </summary>
        public SerialPort SerialPort { get; private set; }
        /// <summary>
        /// Indicates that a measure block was received
        /// </summary>
        public event EventHandler<DataBlockEventArgs> BlockReceived;
        /// <summary>
        /// Indicates that an error occurs reading from serial port
        /// </summary>
        public event EventHandler<ErrorReadingEventArgs> ReadError;
        /// <summary>
        /// Indicates that a partial block was received (less or more than 14 bytes blocks)
        /// </summary>
        public event EventHandler<PartialBlockEventArgs> PartialBlockReceived;

        /// <summary>
        /// Returns a <see cref="SerialReader" instance over the provided port/>
        /// </summary>
        /// <param name="portName">Port name where the DMM is connected</param>
        public SerialReader(string portName)
        {
            SerialPort = new SerialPort()
            {
                PortName = portName,
                BaudRate = BAUD_RATE,
                Parity = PARITY,
                DataBits = DATA_BITS,
                StopBits = STOP_BITS,
                Handshake = HANDSHAKE,
                DtrEnable = DTR_ENABLED,
                ReadTimeout = TIMEOUT
            };

            SerialPort.DataReceived += SerialPort_DataReceived;
            SerialPort.ErrorReceived += SerialPort_ErrorReceived;

        }

        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            ReadError?.Invoke(this, new ErrorReadingEventArgs(ErrorMessages.ERROR_READING));
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[SerialPort.BytesToRead];
            SerialPort.Read(buffer, 0, buffer.Length);
            try { 
                var measureBlock = new RawMeasureBlock(buffer);
                BlockReceived?.Invoke(this, new DataBlockEventArgs(measureBlock));
            }catch(PartialBlockException ex)
            {
                PartialBlockReceived?.Invoke(this, new PartialBlockEventArgs(buffer, ex.Message));

            }catch(Exception ex)
            {
                ReadError?.Invoke(this, new ErrorReadingEventArgs(ex.Message));
            }

        }

    }
}

