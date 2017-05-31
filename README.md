Plivo C#.NET Helper Library
===========================

## About

__Plivo C#.NET Helper Library__ simplifies the process of making [Plivo API](http://plivo.com/docs/api/) calls and generating [Plivo XML](http://plivo.com/docs/xml/).

## Getting Started

### Minimum Prerequisites

1. Windows 7
2. Microsoft Visual Studio 2010
3. NuGet Package Manger

NOTE: _NuGET Package Manager installation procedure can be found in the [NuGet Documentation here](http://docs.nuget.org/docs/start-here/installing-nuget)_

### Installation

This helper library can be installed / used in two ways,

1. From Source.
2. From the [NuGet Package Manager](http://visualstudiogallery.msdn.microsoft.com/27077b70-9dad-4c64-adcf-c7cf6bc9970c) (recommended).

#### From Source

To use this library from source follow the instructions below, 

+ Get the source from Github using `git clone` or using the [download link](https://github.com/plivo/plivo-dotnet/archive/master.zip).
+ Open the solution file in Visual Studio.
+ Install [NuGet Package Manager](http://docs.nuget.org/docs/start-here/installing-nuget).
+ Go to `Tools -> Library Package Manager -> Packager Manager Console`.
+ Enter the following commands in the console to install [RestSharp](https://www.nuget.org/packages/RestSharp) (a Simple REST and HTTP API Client) and [Json.NET](https://www.nuget.org/packages/newtonsoft.json/) (a popular high-performance JSON framework for .NET),  
```
PM> Install-Package RestSharpSigned -Version 105.2.3
PM> Install-Package Newtonsoft.Json -Version 7.0.1
```
+ Once the RestSharp and Json.NET packages are successfully installed, close the console. Right Click on the solution (in this case Plivo) in the _Solution Explorer_ and click _Clean_ and then _Build_.
+ Next, to start using it in your project, Right Click on your Project Name in the _Solution Explorer_ and click _Add Reference_. In the dialog box which appears, go to the _Browse_ tab and Navigate to `plivo-dotnet\Plivo\bin\Debug` and select the `Plivo.dll` and click OK.
+ Now, you can use Plivo in your code! 

#### From NuGet Package Manager

+ Install [NuGet Package Manager](http://docs.nuget.org/docs/start-here/installing-nuget).
+ Go to `Tools -> Library Package Manager -> Packager Manager Console`.
+ RestSharp and Json.NET are automatically installed as a dependency.

```
PM> Install-Package Plivo
```

If you already have RestSharp or Json.NET installed, its best to uninstall it before installing the specific version.

```
PM> Uninstall-Package RestSharp -Force
PM> Uninstall-Package Newtonsoft.Json -Force
PM> Install-Package Plivo
```

### Examples

#### Plivo.API

```C#
using System;
using System.Collections.Generic;
using System.Reflection;
using RestSharp;
using Plivo.API;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string auth_id = "XXX";  // obtained from Plivo account dashboard
            string auth_token = "YYY";  // obtained from Plivo account dashboard

            // Creating the Plivo Client
            RestAPI plivo = new RestAPI(auth_id, auth_token);

            // Making a Call
            string from_number = "XXXXXXXXXXX";
            string to_number = "YYYYYYYYYYY";

            IRestResponse<Call> response = plivo.make_call(new Dictionary<string, string>() {
                { "from", from_number },
                { "to", to_number }, 
                { "answer_url", "http://some.domain.com/answer/" }, 
                { "answer_method", "GET" }
            });

            // The "Outbound call" API response has four properties -
            // message, request_uuid, error, and api_id.
            // error - contains the error response sent back from the server.
            if (response.Data != null)
            {
                PropertyInfo[] properties = response.Data.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(response.Data, null));
            }
            else
            {
                // ErrorMessage - contains error related to network failure.
                Console.WriteLine(response.ErrorMessage);
            }
            Console.Read();
        }
    }
}
```

#### Plivo.API

```C#
using System;
using System.Collection.Generic;
using Plivo.XML;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Response response = new Response();
            // add 'Speak' element to 'Response'
            response.AddSpeak("Go green, go Plivo", 
                new Dictionary<string, string>() {
                    { "loop", "3" },
                    { "language", "en-US");
            });

            // or you can add as below
            // Speak speak = new Speak("Go green, go Plivo", 
            //    new Dictionary<string, string>() {
            //         { "loop", "3" },
            //         { "language", "en-US");
            // });
            // response.Add(speak);

            Console.WriteLine(response.ToString());
            Console.Read();
        }
    }
}
```

## License

```
The MIT License (MIT)
Copyright (c) 2013 Plivo Inc

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
sell copies of the Software, and to permit persons to whom the Software is 
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

```
