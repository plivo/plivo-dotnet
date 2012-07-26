Plivo C# .NET Helper Library
=========================

Description
-----------

The Plivo C# .NET helper simplifies the process of making PLIVO API calls and generating RESTXML.

See [Plivo Documentation](http://www.plivo.com/docs/) for more information.

Installation 
=============
This package can be installed using NuGet package manager in Visual Studio 2010 or later.

NuGet terminal
> PM\> Install-Package Plivo

How to use
==========
Plivo.API
---------
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using RestSharp;
    using Plivo.API;
    	
    namespace mywebapp
    {
        class Program
    	{
            static void Main(string[] args)
            {
                string authId=XXXXXXXXXXXXXXXXXXXXXXXX;
                string authToken=YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY;
                                				
                // Creating the plivo client
                RestAPI plivo = new RestAPI(authId, authToken);
                                 
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
                if (resp.Data != null)
                {
                    PropertyInfo[] properties = resp.Data.GetType().GetProperties();
                    foreach (PropertyInfo property in properties)
                        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(resp.Data, null);
                }
                else
                    // ErrorMessage - contains error related to network failure.
                    Console.WriteLine(resp.ErrorMessage);
                //Console.Read();
            }
        }
    }
         
Plivo.XML
---------
    using System;
    using System.Collection.Generic;
    using Plivo.XML;
        
    namespace myrestxml
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
                //Speak speak = new Speak("Go green, go Plivo", 
                //   new Dictionary<string, string>() {
                //        { "loop", "3" },
                //        { "language", "en-US");
                //});
                //response.Add(speak);
                Console.WriteLine(response.ToString());
                Console.Read();
            }
        }
    }