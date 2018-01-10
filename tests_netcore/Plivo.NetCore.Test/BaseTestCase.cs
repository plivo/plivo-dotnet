using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Plivo.Http;
using Plivo.Utilities;

namespace Plivo.NetCore.Test
{
    public class BaseTestCase
    {
        public PlivoApi Api;
        public TestClient TestClient;

        public string SOURCE_DIR = AppContext.BaseDirectory + @"/../../";

        public BaseTestCase()
        {
            Api = new PlivoApi("MAXXXXXXXXXXXXXXXXXX", "AbcdEfghIjklMnop1234");
            TestClient = new TestClient();
            Api.Client._client = TestClient;
        }

        public void Setup<T>(uint statusCode, string response)
            where T : new()
        {
            ((TestClient)Api.Client._client).Setup(response, statusCode);
        }

        public void AssertRequest(PlivoRequest request)
        {
            CompareRequests(request, ((TestClient)Api.Client._client).Request);
        }

        public void CompareRequests(PlivoRequest a, PlivoRequest b)
        {
            Assert.Equal(a.Method, b.Method);
            Assert.Equal(a.Uri, b.Uri);

            // Console.WriteLine(string.Join(",", a.Data.Select(kvp => kvp.Key + ":" + kvp.Value).ToList()));
            // Console.WriteLine(string.Join(",", b.Data.Select(kvp => kvp.Key + ":" + kvp.Value).ToList()));
            //
            // Console.WriteLine(JsonConvert.SerializeObject(a.Data));
            // Console.WriteLine(JsonConvert.SerializeObject(b.Data));

            Assert.Empty(
                ComparisonUtilities.CompareRawObjects(
                    JObject.Parse(JsonConvert.SerializeObject(a.Data)),
                    JObject.Parse(JsonConvert.SerializeObject(b.Data))).ToString()
            );
            Assert.Empty(
                ComparisonUtilities.CompareRawObjects(
                    JObject.Parse(JsonConvert.SerializeObject(b.Data)),
                    JObject.Parse(JsonConvert.SerializeObject(a.Data))).ToString()
            );
        }
    }
}
