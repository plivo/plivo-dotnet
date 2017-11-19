using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Recording;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    
    public class TestRecording : BaseTestCase
    {
        [Fact]
        public void TestRecordingList()
        {
            var data = new Dictionary<string, object>()
            {
                {"limit", 10}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Recording/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/recordingListResponse.json"
                );
            Setup<ListResponse<Recording>>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Recording.List(limit:10)));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestRecordingGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Recording/" + id + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/recordingGetResponse.json"
                );
            Setup<Recording>(
                200,
                response
            );
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Recording.Get(id)));
            
            AssertRequest(request);
        }
        
        [Fact]
        public void TestRecordingDelete()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Recording/" + id + "/",
                    "");
            
            var response = "";
            Setup<UpdateResponse<Recording>>(
                204,
                response
            );
            Api.Recording.Delete(id);
            AssertRequest(request);
        }
    }
}
