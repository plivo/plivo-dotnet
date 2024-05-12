# plivo-dotnet

[![UnitTest](https://github.com/plivo/plivo-dotnet/actions/workflows/unitTests.yml/badge.svg?branch=master)](https://github.com/plivo/plivo-dotnet/actions/workflows/unitTests.yml)

The Plivo .NET SDK makes it simpler to integrate communications into your .NET applications using the Plivo REST API. Using the SDK, you will be able to make voice calls, send SMS and generate Plivo XML to control your call flows.

**Supported .NET versions:** This SDK was written targeting at .NET Standard 1.3 & .NET Standard 2.0, and thus works with .NET Framework 4.6+ and .NET Core 1.0+. [Check here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) to know about all the other supported platforms.

## Installation
You can install this SDK either by referencing the .dll file or using NuGet.

Use the following line to install the latest SDK using the NuGet CLI.

```
PM> Install-Package Plivo -Version 5.46.0
```

You can also use the .NET CLI to install this package as follows

```
> dotnet add package Plivo --version 5.43.2
```

## Getting started

### Authentication
To make the API requests, you need to create a `PlivoApi` instance and provide it with authentication credentials (which can be found at [https://manage.plivo.com/dashboard/](https://manage.plivo.com/dashboard/)).

```csharp
var api = new PlivoApi("<auth_id>", "<auth_token>");
```

## The Basics
The SDK uses consistent interfaces to create, retrieve, update, delete and list resources. The pattern followed is as follows:

```csharp
api.Resource.Create(params);
api.Resource.Get(params);
api.Resource.Update(identifier, params);
api.Resource.Delete(identifier);
api.Resource.List();
```

Using `api.Resource.List()` would list the first 20 resources by default (which is the first page, with `limit` as 20, and `offset` as 0). To get more, you will have to use `limit` and `offset` to get the second page of resources.

## Examples

### Send a message

```csharp
internal class Program
{
    public static void Main(string[] args)
    {
        var api = new PlivoApi("<auth_id>", "<auth_token>");
        var response = api.Message.Create(
            src:"14156667778",
            dst:"14156667777",
            text:"Hello, this is a sample text from Plivo"
        );
        Console.WriteLine(response);
    }
}
```

### Make a call

```csharp
internal class Program
{
    public static void Main(string[] args)
    {
        var api = new PlivoApi("<auth_id>", "<auth_token>");
        var response = api.Call.Create(
            to:new List<String>{"the_to_number"},
            from:"the_from_number",
            answerMethod:"GET",
            answerUrl:"https://answer.url"
        );
        Console.WriteLine(response);
    }
}
```

### Lookup a number

```csharp
internal class Program
{
    public static void Main(string[] args)
    {
        var api = new PlivoApi("<auth_id>", "<auth_token>");
        var response = api.Lookup.Get("phone_number_here");
        Console.WriteLine(response);
    }
}
```

### Generate Plivo XML

```csharp
class MainClass
{
    public static void Main(string[] args)
    {
        Plivo.XML.Response response = new Plivo.XML.Response();
        response.AddSpeak("Hello, world!",
                          new Dictionary<string, string>() { });
        Console.WriteLine(response.ToString());
    }
}
```

This generates the following XML:

```xml
<Response>
  <Speak>Hello, world!</Speak>
</Response>
```

## WhatsApp Messaging
Plivo's WhatsApp API allows you to send different types of messages over WhatsApp, including templated messages, free form messages and interactive messages. Below are some examples on how to use the Plivo Go SDK to send these types of messages.

### Templated Messages
Templated messages are a crucial to your WhatsApp messaging experience, as businesses can only initiate WhatsApp conversation with their customers using templated messages.

WhatsApp templates support 4 components:  `header` ,  `body`,  `footer`  and `button`. At the point of sending messages, the template object you see in the code acts as a way to pass the dynamic values within these components.  `header`  can accomodate `text` or `media` (images, video, documents) content.  `body`  can accomodate text content.  `button`  can support dynamic values in a `url` button or to specify a developer-defined payload which will be returned when the WhatsApp user clicks on the `quick_reply` button. `footer`  cannot have any dynamic variables.

Example:
```csharp
```

### Free Form Messages
Non-templated or Free Form WhatsApp messages can be sent as a reply to a user-initiated conversation (Service conversation) or if there is an existing ongoing conversation created previously by sending a templated WhatsApp message.

#### Free Form Text Message
Example:
```csharp
```

#### Free Form Media Message
Example:
```csharp
```

### Interactive Messages
This guide shows how to send non-templated interactive messages to recipients using Plivo’s APIs.

#### Quick Reply Buttons
Quick reply buttons allow customers to quickly respond to your message with predefined options.

Example:
```csharp
```

#### Interactive Lists
Interactive lists allow you to present customers with a list of options.

Example:
```csharp
```

#### Interactive CTA URLs
CTA URL messages allow you to send links and call-to-action buttons.

Example:
```csharp
```

### Location Messages
This guide shows how to send templated and non-templated location messages to recipients using Plivo’s APIs.

#### Templated Location Messages
Example:
```csharp
```

#### Non-Templated Location Messages
Example:
```csharp
```

### More examples
Refer to the [Plivo API Reference](https://api-reference.plivo.com/latest/net/introduction/overview) for more examples.

## Reporting issues
Report any feedback or problems with this version by [opening an issue on Github](https://github.com/plivo/plivo-dotnet/issues).

## Local Development
> Note: Requires latest versions of Docker & Docker-Compose. If you're on MacOS, ensure Docker Desktop is running.
1. Export the following environment variables in your host machine:
```bash
export PLIVO_AUTH_ID=<your_auth_id>
export PLIVO_AUTH_TOKEN=<your_auth_token>
export PLIVO_API_DEV_HOST=<plivoapi_dev_endpoint>
export PLIVO_API_PROD_HOST=<plivoapi_public_endpoint>
```
2. Run `make build`. This will create a docker container in which the sdk will be setup and dependencies will be installed.
> The entrypoint of the docker container will be the `setup_sdk.sh` script. The script will handle all the necessary changes required for local development. It will also package the sdk and reinstall it as a dependecy for the test program.
3. The above command will print the docker container id (and instructions to connect to it) to stdout.
4. The testing code can be added to `<sdk_dir_path>/dotnet-sdk-test/Program.cs` in host  
 (or `/usr/src/app/dotnet-sdk-test/Program.cs` in container)
5. The sdk directory will be mounted as a volume in the container. So any changes in the sdk code will also be reflected inside the container. However, when any change is made, the dependencies for the test program need to be re-installed. To do that:
    * Either restart the docker container
    * Or Run the `setup_sdk.sh` script
6. To run test code, run `make run CONTAINER=<cont_id>` in host.
> `<cont_id>` is the docker container id created in 2.
(The docker container should be running)

> Test code can also be run within the container using
`make run`. (`CONTAINER` argument should be omitted when running from the container)