﻿using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using ES51922Reader;
using ES51922Reader.Types;

namespace Example
{
    class Program
    {
        private static MeasureReader reader;
        private const int DATA_TIMEOUT = 1500;
        private static Stopwatch lastMeasureElapsedTime;
        private static bool DataPresent = true;

        static void Main(string[] args)
        {
            var portName = SetPortName();
            reader = new MeasureReader(portName);
            reader.MeasureReceived += Reader_MeasureReceived;
            lastMeasureElapsedTime = Stopwatch.StartNew();
            while (!Console.KeyAvailable)
            {
                if(lastMeasureElapsedTime.ElapsedMilliseconds >= DATA_TIMEOUT && DataPresent)
                {
                    DataPresent = false;
                    Console.Clear();
                    Console.WriteLine("No data available");
                }
            }
        }

        private static void Reader_MeasureReceived(object sender, MeasureReceivedEventArg e)
        {
            DataPresent = true;
            lastMeasureElapsedTime.Restart();
            var measure = e.measureBlock;
            Console.Clear();
            Console.WriteLine(measure.Status.DCMode ? "DC" : "AC");
            if (!measure.Status.InputOverload && !measure.Status.InputUnderlevel) { 
                Console.WriteLine($"{(measure.Status.MinusSign? "-": "")}{measure.Value} {measure.Unit}");
            }
            else
            {
                Console.WriteLine(measure.Status.InputOverload ? "OL" : "UL");
            }
        }

        public static string SetPortName()
        {
            Console.Clear();
            string portName = "";

            var availablePorts = SerialPort.GetPortNames().ToList();

            Console.WriteLine("Available Ports:");
            int i = 1;
            foreach (string port in SerialPort.GetPortNames())
            {
                Console.WriteLine($"{i} - {port}");
                i++;
            }

            Console.Write($"Select SERIAl port name: ");
            var option = int.Parse(Console.ReadLine());
            if (option <= availablePorts.Count)
                portName = availablePorts[option - 1] ?? "";

            if (String.IsNullOrWhiteSpace(portName))
            {
                portName = SetPortName();
            }
            return portName;
        }
    }
}