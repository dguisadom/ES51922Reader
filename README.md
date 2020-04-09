# ES51922Reader Version: 0.1.0 a


This is a .Net Core library for read ES51922 based DMMs.

This library provides the capability to read the serial data of ES51922 based DMMs like UNI-T UT61-E. As a .Net Core library it is cross-platform and you can code tools based on it for Windows, Mac Os or Linux.

# USAGE.

On this source you can find a console application as an example of the library usage.

When you instance MeasureReader class it automaticalle starts reading data blocks on the indicated port
  reader = new ES51922MeasureReader(portName);
  reader.MeasureReceived += Reader_MeasureReceived;

# CHANGELOG.

* 0.1.0 a (09/April/2020): First Release alpha. Provides all measure capabilities, but the code is so messy and it's poor tested.

Copyright David Guisado 2020.
