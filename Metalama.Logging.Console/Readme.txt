This Net Standard 2 class Library provides logging to the console.

The Following Attributes are provided:

[Log]

This is the basic logging attribute.  It logs entry and exit and parameters if they are present.
It will also log any exception if one occurs and the final return value should there be one. 
It will be added to all public methods by default, unless they are Decorated with the [NoLog] attribute
or the [TimedLog] attribute.



[NoLog]

A simple attribute to be applied to Methods indicating that they should not be logged.  

This is really for use when using a Fabric to apply logging across the entire project.



[NotLogged]

An attribute to apply to parameters that do not or should not be logged