using System;
using System.Collections.Generic;
using Plivo;

namespace Plivo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var token0 = new Plivo.AccessToken("MADADADADADADADADADA", "qwerty", "username")
                .WithOutgoing(true)
                .WithIncoming(false)
                .WithValidFrom(DateTime.Parse("2020-03-22"))
                .WithLifetime(TimeSpan.FromHours(2))
                .WithUid("uuid");
            Console.WriteLine(token0.ToJwt());

            var token1 = new Plivo.AccessToken("MADADADADADADADADADA", "qwerty", "username")
                .WithOutgoing(true)
                .WithIncoming(false)
                .WithValidFrom(DateTime.Parse("2020-03-22"))
                .WithValidTill(DateTime.Parse("2020-03-23"))
                .WithUid("uuid");
            Console.WriteLine(token1.ToJwt());

            var token2 = new Plivo.AccessToken("MADADADADADADADADADA", "qwerty", "username")
                .WithOutgoing(true)
                .WithIncoming(false)
                .WithLifetime(TimeSpan.FromHours(2))
                .WithValidTill(DateTime.Parse("2020-03-22"))
                .WithUid("uuid");
            Console.WriteLine(token2.ToJwt());

        }
    }
}
