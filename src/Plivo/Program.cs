using System;
using Plivo.Client;
using System.Diagnostics;
namespace Plivo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var api = new PlivoApi(authId: "MAM2I4NGU1ODM2NDM1M2", authToken: "YzRjZTE4MTJhOTYxMGQ0OGIzNzBhNTllZTM4YWE0");
            var response = api.Account.Get();

            Debug.WriteLine(response);
        }
    }
}
