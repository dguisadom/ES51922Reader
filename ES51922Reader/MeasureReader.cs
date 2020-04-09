using System;
using System.Collections.Generic;
using ES51922Reader.Exceptions;
using ES51922Reader.Reader;
using ES51922Reader.Types;

namespace ES51922Reader
{
    public class MeasureReader
    {
        private readonly string PortName;
        private readonly SerialReader reader;
        public event EventHandler<MeasureReceivedEventArg> MeasureReceived;
        //TODO Replace with custom event Arg
        public event EventHandler<PartialBlockEventArgs> WrongBlockReceived;

        public MeasureReader(string portName)
        {
            PortName = portName;
            reader = new SerialReader(portName);
            reader.BlockReceived += Reader_BlockReceived;
            reader.StartReading();
        }

        private void Reader_BlockReceived(object sender, Types.DataBlockEventArgs e)
        {
            try
            {
                var measureBlock = new MeasureBlock(e.RawMeasureBlock);
                MeasureReceived?.Invoke(this, new MeasureReceivedEventArg()
                {
                    measureBlock = measureBlock
                });
            }catch(PartialBlockException ex)
            {
                
            }
        }


    }
}
