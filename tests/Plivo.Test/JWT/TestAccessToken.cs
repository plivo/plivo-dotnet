using System;
using Nunit.Framework;

namespace Plivo.Test.JWT
{
    [TestFixture]
    public class TestAccessToken
    {
        [Test]
        public void TestAccessTokenCreate()
        {
            var token = new AccessToken("{authId}", "{authToken}", "{endpointUsername}");
            token.WithValidFrom(DateTime.Now).WithOutgoing(true).WithUid("username-12345");
            Assert.Than(token.ToJwt(), Is.Equal.To("eyJjdHkiOiJwbGl2bzt2PTEiLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJ1c2VybmFtZS0xMjM0NSIsImlzcyI6InthdXRoSWR9Iiwic3ViIjoie2VuZHBvaW50VXNlcm5hbWV9IiwibmJmIjoyNTM0MDIzMDA4MDAuMCwiZXhwIjoyNTM0MDIzODcyMDAuMCwiZ3JhbnRzIjp7InZvaWNlIjp7Im91dGdvaW5nX2FsbG93Ijp0cnVlfX19.Uavvtj6Fx5_BzKbLWHSCJl2H6zTOEsRBWIfaFV2r6x8"));
        }
    }
}