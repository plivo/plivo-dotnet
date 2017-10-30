using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Message;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestMessage : BaseTestCase
    {
        [Test]
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
                    SOURCE_DIR + @"Mocks/messageSendResponse.json"
                );
            Setup<MessageCreateResponse>(
                201,
                response
            );
            Assert.IsEmpty(
                Util.Compare(
                    response,
                    Api.Message.Create("+919999999999", new List<string>(){"+919898989898", "+919090909090"}, "textext")));
            AssertRequest(request);
        }
        
        [Test]
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
                    SOURCE_DIR + @"Mocks/messageListResponse.json"
                );
            Setup<ListResponse<Message>>(
                200,
                response
            );
            Assert.IsEmpty(
                Util.Compare(
                    response,
                    Api.Message.List(limit:10)));
            
            AssertRequest(request);
        }
        
        [Test]
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
                    SOURCE_DIR + @"Mocks/messageGetResponse.json"
                );
            Setup<Message>(
                200,
                response
            );
            Assert.IsEmpty(
                Util.Compare(
                    response,
                    Api.Message.Get(id)));
            
            AssertRequest(request);
        }
    }
}
