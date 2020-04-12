
# ES51922Reader Version: 0.3.0 b


This is a .Net Core library for read ES51922 based DMMs.

This library provides the capability to read the serial data of ES51922 based DMMs like UNI-T UT61-E. As a .Net Core library it is cross-platform and you can code tools based on it for Windows, Mac Os or Linux.

# USAGE.

On this source you can find a console application as an example of the library usage.

When you instance MeasureReader class it automaticalle starts reading data blocks on the indicated port
    
    reader = new MeasureReader(portName);
    
    reader.MeasureReceived += Reader_MeasureReceived; // Invoked when a measure block is received and processed
    reader.WrongBlockReceived += Reader_WrongBlockReceived; // Invoked when a measure block is receved and can't process it
    reader.ErrorReading += Reader_ErrorReading; // Invoked when an error occurs reading from serial port.
    
    reader.Start();

# BE MY PATRON.

Help me to continue coding.

https://www.patreon.com/dguisadom

# EXAMPLE CONSOLE APP.

![Exaple APP](https://thumbs.gfycat.com/WellgroomedFrequentBabirusa-small.gif)

This solution includes a console app project with an example implementation.

# CHANGELOG.

* 0.3.0 b (10/April/2020):
	* Improve stability
	* Fix serial port open and close methods.
	* Fix WrongBlockReceived event.
	* Add WrongBlockReceived example implementation.
	* Added some code comments.
	* Added Cyrustek ES51922 official datasheet.

* 0.2.0 b (10/April/2020): 
	* Improve code stability. Change access modifiers from public to internal.
	* Added wrong data block control.
	* Added wrong data block event.
	* Improved example console app.
	* Added error messages constant class.
	* Added ReadingException throwed when an error reading serial port.
	
* 0.1.0 a (09/April/2020): 
	* First alpha Release. Provides all measure capabilities, but the code is so messy and it's poor tested.

Copyright David Guisado 2020.
