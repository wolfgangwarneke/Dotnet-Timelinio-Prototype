# _Timelinio (*Prototype*)_

#### _A timeline visualization tool to help keep track of your life (or anything else), October 5th, 2016_

#### By _**Wolfgang Warneke**_

## Description

_This is a story all about how, my life got flipped, got turned into a timeline.  Several timelines, to compare and contrast the past, to learn and grow from it, etc, etc... This timeline utility will allow users to create custom timelines with custom events and custom focuses and eventually will be able to compare various timelines side by side to really get into that personal 'big data' everyone seems to be talking about._
_In the future (**the future, Conan?**), this whole app will have a sleekly attractive graphic user interface to actually visualize the timelines and events instead of the boring tabular data rubric currently in deploy.  It would be nice to use a different services_

## Setup/Installation Requirements

* _Are you running Visual Studio 2015?_
* _Are you running SQL Server?_
* _Clone the project and open it in Visual Studio._
* _Do you have a Twilio account set up?_
* _Add EnvironmentVariables.cs to the models folder. *(follow along with code example below this bullet-point list)*_
* _Wait for the packages to restore..._
* _Navigate to the project folder on your command line and run `dotnet ef database update`_
* _Run it!_
* _Enjoy and please do send any feedback my way; I'd love to hear from you and I am eager to learn and improve!_

_EnvironmentVariables.cs:_
```
namespace Timelinio.Models
{
    public static class EnvironmentVariables
    {
        public static string AccountSid = "your Twilio SID here!";
        public static string AuthToken = "your Twilio token here!";
        public static string TwilioPhone = "your Twilio phone number here!";
        public static string OwnPhone = "your own phone number here!";
    }
}
```

## Known Bugs

* _Newly created events don't have functional delete and edit buttons._
* _Updating an event saves new values, but does not reflect changes on current page_
* _Update event form has prepopulated DATE field, but TITLE and DESCRIPTION are blank_

## Support and contact details

_@WolfgangWarneke is a good way to find a hold of me on the various social media_

## Technologies Used

_ASP.Net Core, Entity Framework Core, Bootstrap 3, and lots of raw JavaScript_

### License

Copyright (c) 2016 **_Wolfgang Warneke_**
