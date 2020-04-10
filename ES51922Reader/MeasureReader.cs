namespace ES51922Reader
{
    using System;
    using System.IO.Ports;
    using Exceptions;
    using Reader;
    using Types;

    public class MeasureReader
    {
        private readonly SerialReader reader;
        public event EventHandler<MeasureReceivedEventArg> MeasureReceived;
        public event EventHandler<PartialBlockEventArgs> WrongBlockReceived;

        public MeasureReader(string portName)
        {
            reader = new SerialReader(portName);
            reader.BlockReceived += Reader_BlockReceived;
            reader.ReadError += Reader_ReadError;
        }

        private void Reader_ReadError(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new ReadException(ErrorMessages.ERROR_READING);
        }

        public void Start()
        {
            reader.SerialPort.Open();
        }

        private void Reader_BlockReceived(object sender, Types.DataBlockEventArgs e)
        {
            try
            {
                var measureBlock = new MeasureBlock(e.RawMeasureBlock);
                MeasureReceived?.Invoke(this, new MeasureReceivedEventArg()
                {
                    MeasureBlock = measureBlock
                });

            }
            catch(PartialBlockException ex)
            {
                WrongBlockReceived?.Invoke(this, new PartialBlockEventArgs(e.RawMeasureBlock.DataBlock,ex.Message));
            }
        }

        public void Stop()
        {
            reader.SerialPort.Close();
        }

    }
}
