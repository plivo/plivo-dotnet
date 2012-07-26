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
                
                // The "Outbound call" API response has three fields, namely, message, request_uuid, and api_id. 
                // You can capture any of the above three fields 
                // if it was a success, all the parameters of response would available.
                // else if there was an error, the error will available in response.Content. 
                var requestuuid = response.Data.request_uuid;
                var error_or_request_uuid = String.IsNullOrEmpty(requestuuid) ? response.Content : requestuuid;
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