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

        [Fact]
        public void TestMessageGetUsdAccountHasNoInrFields()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageGetResponse.json"
                );
            Setup<Message>(200, response);

            var message = Api.Message.Get("abcabcabc");

            Assert.Equal("0.00250", message.TotalAmount);
            Assert.Null(message.TotalAmountInr);
            Assert.Null(message.TotalRateInr);
            Assert.Null(message.CarrierFeesInr);
            Assert.Null(message.CarrierFeesRateInr);
        }

        [Fact]
        public void TestMessageGetInrAccount()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Message/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageGetInrResponse.json"
                );
            Setup<Message>(200, response);

            var message = Api.Message.Get(id);

            Assert.Empty(ComparisonUtilities.Compare(response, message));
            Assert.Equal("0.00500", message.TotalAmount);
            Assert.Equal("0.41500", message.TotalAmountInr);
            Assert.Equal("0.00500", message.TotalRate);
            Assert.Equal("0.41500", message.TotalRateInr);
            Assert.Equal("0.00100", message.CarrierFees);
            Assert.Equal("0.08300", message.CarrierFeesInr);
            Assert.Equal("0.00100", message.CarrierFeesRate);
            Assert.Equal("0.08300", message.CarrierFeesRateInr);
            AssertRequest(request);
        }

        [Fact]
        public void TestMessageListInrAccount()
        {
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/messageListInrResponse.json"
                );
            Setup<ListResponse<Message>>(200, response);

            var messages = Api.Message.List(limit: 10);

            Assert.Empty(ComparisonUtilities.Compare(response, messages));
            Assert.Equal(2, messages.Objects.Count);
            Assert.Equal("0.41500", messages.Objects[0].TotalAmountInr);
            Assert.Equal("0.41500", messages.Objects[0].TotalRateInr);
            Assert.Equal("0.08300", messages.Objects[0].CarrierFeesInr);
            Assert.Equal("0.08300", messages.Objects[0].CarrierFeesRateInr);
            Assert.Equal("0.83000", messages.Objects[1].TotalAmountInr);
            Assert.Equal("0.41500", messages.Objects[1].TotalRateInr);
            Assert.Equal("0.16600", messages.Objects[1].CarrierFeesInr);
            Assert.Equal("0.08300", messages.Objects[1].CarrierFeesRateInr);
        }
    }
}