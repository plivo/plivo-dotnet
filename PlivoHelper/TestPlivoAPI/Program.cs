using System;
using System.Collections.Generic;
using RestSharp;
using Plivo;

namespace TestPlivoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            RestAPI plivo = new RestAPI("MAGWNTM3ZTK1M2YZMDF5", "MThhNmRjZDFmY2I3MTg1NjAwODIxYWZi1UViNTQx");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("subauth_id", "SAYWY1NMM0YWFKMDMXOG");
            //IRestResponse<Gen response = plivo.get_cdr(param);
            IRestResponse<SubAccountList> response = plivo.get_subaccounts();
            //IRestResponse<Account> response = plivo.get_account();
            var data = response.Data.objects[0].account;

            Console.WriteLine(data);
            ////string error = response.ErrorMessage;
            //if (name.Equals(""))
            //    Console.WriteLine("error");
            //else
            //    //Console.WriteLine(response.StatusDescription);
            //    Console.WriteLine(String.Format("The server response content is \n{0}", name));

            Console.WriteLine("\nPress enter to exit...");
            Console.Read();
        }
    }
}