using System;
using Xunit;

namespace Plivo.NetCore.Test.JWT
{
    public class TestAccessToken
    {
        [Fact]
        public void TestAccessTokenCreate()
        {
            var token = new AccessToken("{authId}", "{authToken}", "{endpointUsername}");
            token.WithValidFrom(DateTime.MaxValue).WithOutgoing(true).WithUid("username-12345");
            Assert.Equal("eyJjdHkiOiJwbGl2bzt2PTEiLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJ1c2VybmFtZS0xMjM0NSIsImlzcyI6InthdXRoSWR9Iiwic3ViIjoie2VuZHBvaW50VXNlcm5hbWV9IiwibmJmIjoyNTM0MDIzMDA4MDAuMCwiZXhwIjoyNTM0MDIzODcyMDAuMCwiZ3JhbnRzIjp7InZvaWNlIjp7Im91dGdvaW5nX2FsbG93Ijp0cnVlfX19.Uavvtj6Fx5_BzKbLWHSCJl2H6zTOEsRBWIfaFV2r6x8", token.ToJwt());
        }
    }
}