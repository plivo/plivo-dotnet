using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Application;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestApplication : BaseTestCase
    {
        [Fact]
        public void TestApplicationCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"app_name", "Test Application"},
                {"answer_url", "http://answer.url"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Application/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/applicationCreateResponse.json"
                );
            Setup<ApplicationCreateResponse>(
                201,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Application.Create("Test Application", "http://answer.url")));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestApplicationList()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Application/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/applicationListResponse.json"
                );
            Setup<ListResponse<Application>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Application.List()));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestApplicationGet()
        {
            var id = "15784735442685051";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Application/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/applicationGetResponse.json"
                );
            Setup<Application>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Application.Get(id)));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestApplicationUpdate()
        {
            var id = "15784735442685051";
            var data = new Dictionary<string, object>()
            {
                {"answer_url", "http://updated.answer.url"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Application/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/applicationModifyResponse.json"
                );
            Setup<UpdateResponse<Application>>(
                202,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Application.Update(id, answerUrl: "http://updated.answer.url")));
            AssertRequest(request);
        }
        
        [Fact]
        public void TestApplicationDelete()
        {
            var id = "15784735442685051";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Application/" + id + "/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<Application>>(
                204,
                response
            );
            Assert.Null(Api.Application.Delete(id));
            AssertRequest(request);
        }
    }
}