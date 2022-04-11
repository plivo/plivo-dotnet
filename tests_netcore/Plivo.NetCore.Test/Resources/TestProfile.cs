using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Profile;
using Plivo.Utilities;
using System;

namespace Plivo.NetCore.Test.Resources
{
    public class TestProfile : BaseTestCase
    {
        [Fact]
        public void TestProfileList()
        {
            var data = new Dictionary<string, object>();
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Profile/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/profileListResponse.json"
                );
            Setup<ListResponse<ListProfiles>>(
                200,
                response
            );
           var resp =  Api.Profile.List();
            AssertRequest(request);
        }

        [Fact]
        public void TestProfileGet()
        {
            var id = "8a9f1eef-6273-4444-822a-a3c2941c51dd";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Profile/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/profileGetResponse.json"
                );
            Setup<GetProfile>(
                200,
                response
            );
            var resp =  Api.Profile.Get(id);
            AssertRequest(request);
        }
    }
}
