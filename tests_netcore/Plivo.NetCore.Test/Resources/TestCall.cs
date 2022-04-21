using System;
using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Call;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestCall : BaseTestCase
    {
        [Fact]
        public void TestCallCreate()
        {
            var data = new Dictionary<string, object>()
            {
                {"from", "+919999999999"},
                {"to", "+919898989898<+919090909090"},
                {"answer_url", "http://answer.com"},
                {"answer_method", "POST"},
                {"is_voice_request", true},
                {"new_send_on_preanswer", "<"},
                {"new_time_limit", "<"},
                {"new_hangup_on_ring", "<"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/callCreateResponse.json"
                );
            Setup<CallCreateResponse>(201, response);

            Assert.Empty(
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
        
        [Fact]
        public void TestCallCreateAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"from", "+919999999999"},
                {"to", "+919898989898<+919090909090"},
                {"answer_url", "http://answer.com"},
                {"answer_method", "POST"},
                {"is_voice_request", true},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.CreateAsync(
                        "+919999999999",
                        new List<string>()
                        {
                            {"+919898989898"},
                            {"+919090909090"}
                        },
                        "http://answer.com",
                        "POST",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallDelete()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.Null(Api.Call.Delete("abcabcabc"));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallDeleteAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/asyncResponse.json"
            );;
            Setup<AsyncResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.DeleteAsync(
                        id,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"end_time__gt", "2017-06-07 00:00:00.000000"},
                        {"is_voice_request", true}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/callListResponse.json"
                );
            Setup<ListResponse<Call>>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.List(endTime_Gt: DateTime.Parse("2017-06-07"))
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallListAsync()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"end_time__gt", "2017-06-07 00:00:00.000000"},
                        {"is_voice_request", true},
                        {"callback_url", "https://www.google.com"},
                        {"callback_method", "POST"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListAsync(endTime_Gt: DateTime.Parse("2017-06-07"),
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallGet()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/callGetResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<Call>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.Get(id)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallGetAsync()
        {
            var id = "abcabcabc";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetAsync(id,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestLiveCallList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "live"},
                        {"is_voice_request", true}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallListGetResponse.json"
                );
            Setup<LiveCallListResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListLive()
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestLiveCallListAsync()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "live"},
                        {"is_voice_request", true},
                        {"callback_url", "https://www.google.com"},
                        {"callback_method", "POST"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListLiveAsync(callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestQueuedCallList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "queued"},
                        {"is_voice_request", true}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallListGetResponse.json"
                );
            Setup<QueuedCallListResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListQueued()
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestQueuedCallListAsync()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "queued"},
                        {"is_voice_request", true},
                        {"callback_url", "https://www.google.com"},
                        {"callback_method", "POST"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.ListQueuedAsync(callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }


        [Fact]
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
                        {"status", "live"},
                        {"is_voice_request", true}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallGetResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<LiveCall>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetLive(id)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestLiveCallGetAsync()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "live"},
                        {"is_voice_request", true},
                        {"callback_url", "https://www.google.com"},
                        {"callback_method", "POST"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetLiveAsync(id, callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestQueuedCallGet()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "queued"},
                        {"is_voice_request", true}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/queuedCallGetResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<QueuedCall>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetQueued(id)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestQueuedCallGetAsync()
        {
            var id = "abcabcabc";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    new Dictionary<string, object>()
                    {
                        {"status", "queued"},
                        {"is_voice_request", true},
                        {"callback_url", "https://www.google.com"},
                        {"callback_method", "POST"}
                    });

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Assert.NotEmpty(response);

            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.GetQueuedAsync(id, callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallTranfer()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"legs", "aleg"},
                {"aleg_url", "http://asdsa.asdsa"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/callUpdateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.Transfer(id, "aleg", "http://asdsa.asdsa")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallTranferAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"legs", "aleg"},
                {"aleg_url", "http://asdsa.asdsa"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.TransferAsync(id, "aleg", "http://asdsa.asdsa",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallRecord()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"time_limit", 120},
                {"file_format", "wav"},
                {"callback_method", "http://a.a"},
                {"callback_url", "http://s.s"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallRecordCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartRecording(id, 120, "wav", callbackMethod: "http://a.a", callbackUrl: "http://s.s")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallRecordAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"time_limit", 120},
                {"file_format", "wav"},
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartRecordingAsync(id, 120, "wav", 
                            callbackMethod: "POST", callbackUrl: "http://google.com").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallSpeak()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"text", "120"},
                {"voice", "WOMAN"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallSpeakCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartSpeaking(id, "120", voice: "WOMAN")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallSpeakAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"text", "120"},
                {"voice", "WOMAN"},
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartSpeakingAsync(id, "120", voice: "WOMAN",
                        callbackMethod: "POST", callbackUrl: "http://google.com").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallPlay()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"urls", "http://wewewe.ewewew,http:/second.url"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallPlayCreateResponse.json"
                );
            Setup<UpdateResponse<Call>>(202, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartPlaying(id, new List<string>() {"http://wewewe.ewewew", "http:/second.url"})
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallPlayAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"urls", "http://wewewe.ewewew,http:/second.url"},
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StartPlayingAsync(id, new List<string>()
                    {
                        "http://wewewe.ewewew", "http:/second.url",
                    }, callbackUrl: "http://google.com", callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallStopRecording()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"URL", "http://wewewe.ewewew"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.Null(Api.Call.StopRecording(id, "http://wewewe.ewewew"));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallStopRecordingAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"URL", "http://wewewe.ewewew"},
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Record/",
                    "",
                    data);
            
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StopRecordingAsync(id, "http://wewewe.ewewew", callbackUrl:
                        "http://google.com", callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestCallStopPlaying()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<Call>>(204, response);

            Assert.Null(Api.Call.StopPlaying(id));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallStopPlayingAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StopPlayingAsync(id, callbackUrl:
                        "http://google.com", callbackMethod: "POST").Result
                )
            );
            
            AssertRequest(request);
        }

        [Fact]
        public void TestCallStopSpeaking()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/liveCallSpeakDeleteResponse.json"
                );
            Setup<DeleteResponse<Call>>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StopSpeaking(id)));

            AssertRequest(request);
        }
        
        [Fact]
        public void TestCallStopSpeakingAsync()
        {
            var id = "abcabcabc";

            var data = new Dictionary<string, object>()
            {
                {"callback_method", "POST"},
                {"callback_url", "http://google.com"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Call/" + id + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/asyncResponse.json"
                );
            Setup<AsyncResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Call.StopSpeakingAsync(id, callbackUrl:
                        "http://google.com", callbackMethod: "POST").Result
                )
            );
            
            AssertRequest(request);
        }
    }
}