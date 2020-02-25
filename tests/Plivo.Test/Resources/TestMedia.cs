using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Medis;
using Plivo.Utilities;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestMedia : BaseTestCase
    {

        [Test]
        public void TestMediaList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 1}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Media/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/mediaListResponse.json"
                );
            Setup<ListResponse<Message>>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Message.List(limit: 1)));

            AssertRequest(request);
        }

        [Test]
        public void TestMediaGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Media/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/mediaGetResponse.json"
                );
            Setup<Message>(
                200,
                response
            );
            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Message.Get(id)));

            AssertRequest(request);
        }
    }
}
