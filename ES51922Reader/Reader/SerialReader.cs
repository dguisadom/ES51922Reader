using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using ES51922Reader.Types;

namespace ES51922Reader.Reader
{
    public class SerialReader
    {
        private const int BAUD_RATE = 19200;
        private const Parity PARITY = Parity.Odd;
        private const int DATA_BITS = 7;
        private const StopBits STOP_BITS = StopBits.One;
        private const Handshake HANDSHAKE = Handshake.None;
        private const bool DTR_ENABLED = true;
        private const int TIMEOUT = 500;

        public SerialPort SerialPort { get; private set; }

        public event EventHandler<DataBlockEventArgs> BlockReceived;
        public event EventHandler<PartialBlockEventArgs> PartialBlockReceived;
        public event EventHandler<SerialErrorReceivedEventArgs> ReadError;

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
            ReadError?.Invoke(this, e);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[SerialPort.BytesToRead];
            SerialPort.Read(buffer, 0, buffer.Length);
            if (buffer.Length == 14)
            {
                var measureBlock = new RawMeasureBlock(buffer);
                BlockReceived?.Invoke(this, new DataBlockEventArgs()
                {
                    RawMeasureBlock = measureBlock
                });
            }
            else
            {
                PartialBlockReceived?.Invoke(this, new PartialBlockEventArgs()
                {
                    DataBlock = buffer
                });
            }

        }

        public void StartReading()
        {
            SerialPort.Open();
        }
    }
}

