using System.Collections.Generic;
using NUnit.Framework;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.Call;
using Plivo.Resource.Conference;

namespace Plivo.Test.Resources
{
    [TestFixture]
    public class TestConference : BaseTestCase
    {
        [Test]
        public void TestConferenceList()
        {
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceListResponse.json"
                );
            Setup<ConferenceListResponse>(200, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.List()
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceGet()
        {
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceGetResponse.json"
                );
            Setup<Conference>(200, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.Get(name)
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceDelete()
        {
            var name = "my conference";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceDeleteResponse.json"
                );
            Setup<Conference>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.Delete(name)
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceDeleteAll()
        {
            // var name = "my conference";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceDeleteAllResponse.json"
                );
            Setup<Conference>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.DeleteAll()
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberDelete()
        {
            var name = "my conference";
            var memberId = "11";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberDeleteResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.HangupMember(name, memberId)
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberKick()
        {
            var name = "my conference";
            var memberId = "11";
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Kick/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberKickCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.KickMember(name, memberId)
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberMute()
        {
            var name = "my conference";
            var memberId = "11";
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberMuteCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.MuteMember(name, new List<string>(){"11"})
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberUnMute()
        {
            var name = "my conference";
            var memberId = "11";
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Mute/",
                    "");

            var response = "";
            Setup<ConferenceMemberActionResponse>(204, response);

            Api.Conference.UnmuteMember(name, new List<string>() {"11"});
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberPlay()
        {
            var name = "my conference";
            var memberId = "11";
            
            var data = new Dictionary<string ,object>()
            {
                {"url", "http://url.url"}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberPlayCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.PlayMember(name, new List<string>(){"11"}, "http://url.url")
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberStopPlaying()
        {
            var name = "my conference";
            var memberId = "11";
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Play/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberPlayDeleteResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.StopPlayMember(name, new List<string>(){"11"})
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberSpeak()
        {
            var name = "my conference";
            var memberId = "11";
            
            var data = new Dictionary<string ,object>()
            {
                {"text", "speak this"}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberSpeakCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.SpeakMember(name, new List<string>(){"11"}, "speak this")
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberStopSpeaking()
        {
            var name = "my conference";
            var memberId = "11";
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Speak/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberSpeakCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.StopSpeakMember(name, new List<string>(){"11"})
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberDeaf()
        {
            var name = "my conference";
            var memberId = "11";
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
                    "");
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceMemberDeafCreateResponse.json"
                );
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.DeafMember(name, new List<string>(){"11"})
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceMemberUnDeaf()
        {
            var name = "my conference";
            var memberId = "11,123";
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Member/" + memberId + "/Deaf/",
                    "");

            var response = "";
            
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Api.Conference.UnDeafMember(name, new List<string>() {"11", "123"});
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceRecord()
        {
            var name = "my conference";
            // var memberId = "11,123";
            
            var data = new Dictionary<string, object>()
            {
                {"file_format", "mp3"}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
                    "",
                    data);
            
            var response = 
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"Mocks/conferenceRecordCreateResponse.json"
                );
            Setup<RecordCreateResponse<Conference>>(202, response);
            
            Assert.IsEmpty(
                Util.Compare(
                    response, 
                    Api.Conference.StartRecording(name, fileFormat:"mp3")
                )
            );
            
            AssertRequest(request);
        }
        
        [Test]
        public void TestConferenceStopRecording()
        {
            var name = "my conference";
            // var memberId = "11,123";
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/Conference/" + name + "/Record/",
                    "");

            var response = "";
            
            Setup<ConferenceMemberActionResponse>(204, response);
            
            Api.Conference.StopRecording(name);
            
            AssertRequest(request);
        }
    }
}
