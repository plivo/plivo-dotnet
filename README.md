Plivo C# .NET Helper Library
=========================

Description
-----------

The Plivo C# .NET helper simplifies the process of making PLIVO API calls and generating RESTXML.

See [Plivo Documentation](http://www.plivo.com/docs/) for more information.

Prerequisites 
=============
This package depends on "RestSharp" for making API calls.
You can install RestSharp using NuGet package manager in Visual Studio.

NuGet terminal
> Install-Package RestSharp

How to use
==========
Plivo.API
---------
        using System;
        using System.Collections.Generic;
        using RestSharp;
        using Plivo.API;
	
        namespace yourapp
	{
    	      class Program
    	      {
                     static void Main(string[] args)
                     {
                                string authId=XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX;
                                string authToken=YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY;
                                				
                                // Creating the plivo client
                                RestAPI plivo = new RestAPI(authId, authToken);
                                 
                                // Making a Call
                                Dictionary<string, string> parameters = new Dictionary<string, string>();
                                string from_number = "XXXXXXXXXXX";
                                string to_number = "YYYYYYYYYYY";
                                parameters.Add("from", from_number);
                                parameters.Add("to", to_number);
                                parameters.Add("answer_url", "http://some.domain.com/answer/");
                                parameters.Add("answer_method", "GET");
                                   				
                                IRestResponse<Call> response = plivo.make_call(parameters);
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
                                PlivoElement response = new Response();
                                Dictionary<string, string> speak_params = new Dictionary<string, string>();
                                speak_params.Add("loop", "3");
                                speak_params.Add("language", "en-US");
                                PlivoElement speak = new Speak("Go green, go Plivo", speak_params);
                                response.Add(speak);
                                Console.WriteLine(response.ToString());
                                Console.Read();
                        }
                }
         }