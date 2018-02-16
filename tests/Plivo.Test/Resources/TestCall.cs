using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Plivo.Client;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Call;
using Plivo.Utilities;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestCall : BaseTestCase
    {
        [Test]
        public void TestCallCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"from", "+919999999999"},
                {"to", "+919898989898<+919090909090"},
                {"answer_url", "http://answer.com"},
                {"answer_method", "POST"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/callCreateResponse.json"
                );
            Setup<CallCreateResponse>(201, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.Create(
                        "+919999999999",
                        new List<string>()
                        {
                            {"+919898989898"},
                            {"+919090909090"}
                        },
                        "http://answer.com",
                        "POST"
                    )
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallDelete()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>();

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.IsNull(Api.Call.Delete("abcabcabc"));

            AssertRequest(request);
        }

        [Test]
        public void TestCallList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"end_time__gt", "2017-06-07 00:00[:00[.000000]]"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/callListResponse.json"
                );
            Setup<ListResponse<Call>>(200, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.List(endTime_Gt: DateTime.Parse("2017-06-07"))
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "");

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/callGetResponse.json"
                );
            Assert.IsNotEmpty(response);

            Setup<Call>(200, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.Get(id)
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestLiveCallList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "live"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallListGetResponse.json"
                );
            Setup<LiveCallListResponse>(200, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListLive()
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestLiveCallGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "live"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallGetResponse.json"
                );
            Assert.IsNotEmpty(response);

            Setup<LiveCall>(200, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetLive(id)
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallTranfer()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"legs", "aleg"},
                {"aleg_url", "http://asdsa.asdsa"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/callUpdateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.Transfer(id, "aleg", "http://asdsa.asdsa")
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallRecord()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"time_limit", 120},
                {"file_format", "wav"},
                {"callback_method", "http://a.a"},
                {"callback_url", "http://s.s"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallRecordCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartRecording(id, 120, "wav", callbackMethod: "http://a.a", callbackUrl: "http://s.s")
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallSpeak()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"text", "120"},
                {"voice", "WOMAN"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallSpeakCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartSpeaking(id, "120", voice: "WOMAN")
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallPlay()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"urls", "http://wewewe.ewewew,http:/second.url"},
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallPlayCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartPlaying(id, new List<string>() {"http://wewewe.ewewew", "http:/second.url"})
                )
            );

            AssertRequest(request);
        }

        [Test]
        public void TestCallStopRecording()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"URL", "http://wewewe.ewewew"},
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.IsNull(Api.Call.StopRecording(id, "http://wewewe.ewewew"));

            AssertRequest(request);
        }

        [Test]
        public void TestCallStopPlaying()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>();

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.IsNull(Api.Call.StopPlaying(id));

            AssertRequest(request);
        }

        [Test]
        public void TestCallStopSpeaking()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>();

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/liveCallSpeakDeleteResponse.json"
                );
            Setup<DeleteResponse<Call>>(204, response);

            // Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            Assert.IsEmpty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StopSpeaking(id)));

            AssertRequest(request);
        }
    }
}