# Vtl.LogToConsole



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


## Additional Files of Interest

### SensitiveParameterFilter.cs

This class is essentially using a configuration mechanism that has been provided to read a list of names that have been applied to parameters by the developer(s) of the solution using this logging class library that may contain sensitive information that should be obfuscated in the output log.

The combination of this and the [NotLogged] attribute should, in theory at least, provide an efficient catch all.

**NB This is by no means 100% foolproof.  Sensitive data could still slip through the net and it is up to you to ensure that you have sufficient unit tests in place to ensure that this doesn't happen.**

### LoggingOptions.cs

This file is responsible for accessing and controlling our configuration.

In this example we are refercing a file 'sensitive.txt' which we have set as an MSBuild property.

### LogHelpers.cs

This static class contains a helper method (BuildInterpolatedString) that provides string building for the log entries that we create and send to the console.

### LogFabric.cs

This file is the one that performs the magic and ensures that the classes and their methods in the projects that reference this class library get the [Log} aspect added to them according to our ruleset defined within.