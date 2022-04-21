using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Conference;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestConference : BaseTestCase
    {
        [Fact]
        public void TestConferenceList()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceListResponse.json"
                );
            Setup<ConferenceListResponse>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.List()
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceListAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"callback_method", "POST"},
                {"callback_url", "http://www.google.com"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
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
                    Api.Conference.ListAsync(
                        callbackUrl: "http://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceGet()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceGetResponse.json"
                );
            Setup<Conference>(200, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.Get(name)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceGetAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"callback_method", "POST"},
                {"callback_url", "https://www.google.com"},
                {"is_voice_request", true}
            };
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
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
                    Api.Conference.GetAsync(name,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceDelete()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceDeleteResponse.json"
                );
            Setup<Conference>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.Delete(name)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceDeleteAsync()
        {
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
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
                    Api.Conference.DeleteAsync(name,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceDeleteAll()
        {
            // var name = "my conference";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceDeleteAllResponse.json"
                );
            Setup<Conference>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.DeleteAll()
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceDeleteAllAsync()
        {
            // var name = "my conference";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
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
                    Api.Conference.DeleteAllAsync(
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberDelete()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberDeleteResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.HangupMember(name, memberId)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberDeleteAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/",
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
                    Api.Conference.HangupMemberAsync(name, memberId,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberKick()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Kick/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberKickCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.KickMember(name, memberId)
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberKickAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Kick/",
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
                    Api.Conference.KickMemberAsync(name, memberId, callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberMute()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberMuteCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.MuteMember(name, new List<string>() {"11"})
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberMuteAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
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
                    Api.Conference.MuteMemberAsync(name, new List<string>() {"11"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberUnMute()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
                    "",
                    data);

            var response = "";
            Setup<ConferenceMemberActionResponse>(204, response);

            Api.Conference.UnmuteMember(name, new List<string>() {"11"});

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberUnMuteAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/asyncResponse.json"
            );
            Setup<AsyncResponse>(204, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.UnmuteMemberAsync(name, 
                        new List<string>() {"11"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberPlay()
        {
            var name = "my conference";
            var memberId = "11";

            var data = new Dictionary<string, object>()
            {
                {"url", "http://url.url"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberPlayCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.PlayMember(name, new List<string>() {"11"}, "http://url.url")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberPlayAsync()
        {
            var name = "my conference";
            var memberId = "11";

            var data = new Dictionary<string, object>()
            {
                {"url", "http://url.com"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
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
                    Api.Conference.PlayMemberAsync(name, 
                        new List<string>() {"11"}, "http://url.com",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberStopPlaying()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberPlayDeleteResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.StopPlayMember(name, new List<string>() {"11"})
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberStopPlayingAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
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
                    Api.Conference.StopPlayMemberAsync(name, new List<string>() {"11"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberSpeak()
        {
            var name = "my conference";
            var memberId = "11";

            var data = new Dictionary<string, object>()
            {
                {"text", "speak this"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberSpeakCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.SpeakMember(name, new List<string>() {"11"}, "speak this")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberSpeakAsync()
        {
            var name = "my conference";
            var memberId = "11";

            var data = new Dictionary<string, object>()
            {
                {"text", "speak this"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
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
                    Api.Conference.SpeakMemberAsync(name, new List<string>() {"11"}, "speak this",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST").Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberStopSpeaking()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberSpeakCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.StopSpeakMember(name, new List<string>() {"11"})
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberStopSpeakingAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
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
                    Api.Conference.StopSpeakMemberAsync(name, new List<string>() {"11"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberDeaf()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceMemberDeafCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.DeafMember(name, new List<string>() {"11"})
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceMemberDeafAsync()
        {
            var name = "my conference";
            var memberId = "11";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
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
                    Api.Conference.DeafMemberAsync(name, new List<string>() {"11"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberUnDeaf()
        {
            var name = "my conference";
            var memberId = "11,123";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
                    "",
                    data);

            var response = "";

            Setup<ConferenceMemberActionResponse>(204, response);

            Api.Conference.UnDeafMember(name, new List<string>() {"11", "123"});

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceMemberUnDeafAsync()
        {
            var name = "my conference";
            var memberId = "11,123";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
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
                    Api.Conference.UnDeafMemberAsync(name, new List<string>() {"11", "123"},
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceRecord()
        {
            var name = "my conference";
            // var memberId = "11,123";

            var data = new Dictionary<string, object>()
            {
                {"file_format", "mp3"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/conferenceRecordCreateResponse.json"
                );
            Setup<RecordCreateResponse<Conference>>(202, response);

            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.Conference.StartRecording(name, fileFormat: "mp3")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceRecordAsync()
        {
            var name = "my conference";
            // var memberId = "11,123";

            var data = new Dictionary<string, object>()
            {
                {"file_format", "mp3"},
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };

            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
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
                    Api.Conference.StartRecordingAsync(name, fileFormat: "mp3",
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }

        [Fact]
        public void TestConferenceStopRecording()
        {
            var name = "my conference";
            // var memberId = "11,123";
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
                    "",
                    data);

            var response = "";

            Setup<ConferenceMemberActionResponse>(204, response);

            Api.Conference.StopRecording(name);

            AssertRequest(request);
        }
        
        [Fact]
        public void TestConferenceStopRecordingAsync()
        {
            var name = "my conference";
            // var memberId = "11,123";
            var data = new Dictionary<string, object>()
            {
                {"callback_url", "https://www.google.com"},
                {"callback_method", "POST"},
                {"is_voice_request", true}
            };
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
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
                    Api.Conference.StopRecordingAsync(name,
                        callbackUrl: "https://www.google.com",
                        callbackMethod: "POST"
                    ).Result
                )
            );

            AssertRequest(request);
        }
    }
}