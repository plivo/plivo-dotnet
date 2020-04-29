using System;
using System.Collections.Generic;
using Plivo;

namespace Plivo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var token = new Plivo.AccessToken("MADADADADADADADADADA", "qwerty", "username")
                .WithOutgoing(true)
                .WithIncoming(false)
                .WithLifetime(TimeSpan.FromHours(2))
                .WithValidTill(DateTime.Parse("2020-04-24"))
                .WithUid("uuid");
            Console.WriteLine(token.ToJwt());
        }
    }
}