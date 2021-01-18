using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Message;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestMessage : BaseTestCase
    {
        [Fact]
        public void TestMessageCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"src", "+919999999999"},
                {"dst", "+919898989898<+919090909090"},
                {"text", "textext"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Message/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageSendResponse.json"
                );
            Setup<MessageCreateResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Message.Create(src:"+919999999999", dst:new List<string>() {"+919898989898", "+919090909090"},
                       text:"textext")));

            AssertRequest(request);
            Assert.Empty(
               ComparisonUtilities.Compare(
                   response,
                   Api.Message.Create(src: "+919999999999", dst:  "+919898989898<+919090909090",
                      text: "textext")));

            Assert.Empty(
               ComparisonUtilities.Compare(
                   response,
                   Api.Message.Create(dst: "+919898989898<+919090909090",
                      text: "textext",powerpack_uuid:"asdasd-asdasd-asdasd21-asd")));

            Assert.Empty(
               ComparisonUtilities.Compare(
                   response,
                   Api.Message.Create(dst: new List<string>() { "+919898989898", "+919090909090" },
                      text: "textext", powerpack_uuid: "asdasd-asdasd-asdasd21-asd")));
        }

        [Fact]
        public void TestMessageList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Message/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageListResponse.json"
                );
            Setup<ListResponse<Message>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Message.List(limit: 10)));

            AssertRequest(request);
        }

        [Fact]
        public void TestMessageGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Message/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageGetResponse.json"
                );
            Setup<Message>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Message.Get(id)));

            AssertRequest(request);
        }
    }
}