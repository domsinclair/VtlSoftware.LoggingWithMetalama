# Metalama.Logging.Console

TODO: Do not name your project with the prefix Metalama. It's reserved for us on nuget.org.

This class library provides aspects to add logging to a project which will print out to the console.

It uses Microsoft.Extensions.Logging, which means that you should in fact be able to use this with any Logging Framework of your choice that supports the production of Text based logs.

## Available Attributes in this Library

### [Log]


This is the basic logging attribute.  It logs entry and exit parameters if they are present.
It will also log any exception if one occurs and the final return value should there be one. 
It will be added to all public methods by default, unless they are decorated with the [NoLog] attribute
or the [TimedLog] attribute.


### [NoLog]

A simple attribute that does what it says.  When applied to a Method no logging will be applied to that method.


### [TimedLog]

This is essentially the same as the [Log] attribute with the sole exception that it also times the execution of the code being logged.

Realistically providing elapsed time for all logged methods is superfluous so this attribute should be applied manually to those methods where such additional metrics would be useful to have.

### [NotLogged]

An attribute intended to be assigned to parameters whose real value should NOT be returned in a log in order that confidential information remains confisential.