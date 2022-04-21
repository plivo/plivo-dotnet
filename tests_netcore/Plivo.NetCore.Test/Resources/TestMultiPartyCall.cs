using System;
using System.Collections.Generic;
using Xunit;
using Plivo.Http;
using Plivo.Resource;
using Plivo.Resource.MultiPartyCall;
using Plivo.Utilities;

namespace Plivo.NetCore.Test.Resources
{
    public class TestMultiPartyCall : BaseTestCase
    {
        [Fact]
        public void TestMpcList()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/",
                    "",
                    data);
            
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcListResponse.json"
                );
            Setup<ListResponse<MultiPartyCall>>(200, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.List()
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcGet()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_b1e37275-b8e2-42cd-ae63-fffcc54a50b5/",
                    "",
                    data);
            
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcGetResponse.json"
                );
            Setup<MultiPartyCall>(200, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.Get(mpcUuid: "b1e37275-b8e2-42cd-ae63-fffcc54a50b5")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcAddParticipant()
        {
            var data = new Dictionary<string, object>()
            {
                {"role", "agent"},
                {"from", "918888888888"},
                {"to", "917013835803"},
                {"caller_name", "918888888888"},
                {"call_status_callback_method", "POST"},
                {"confirm_key_sound_method", "GET"},
                {"dial_music", "Real"},
                {"ring_timeout", 45},
                {"max_duration", 14400},
                {"max_participants", 10},
                {"record_min_member_count", 1},
                {"wait_music_method", "GET"},
                {"agent_hold_music_method", "GET"},
                {"customer_hold_music_method", "GET"},
                {"recording_callback_method", "GET"},
                {"status_callback_method", "GET"},
                {"on_exit_action_method", "POST"},
                {"record", false},
                {"record_file_format", "mp3"},
                {"status_callback_events", "mpc-state-changes,participant-state-changes"},
                {"stay_alone", false},
                {"coach_mode", true},
                {"mute", false},
                {"hold", false},
                {"start_mpc_on_enter", true},
                {"end_mpc_on_exit", false},
                {"relay_dtmf_inputs", false},
                {"enter_sound", "beep:1"},
                {"enter_sound_method", "GET"},
                {"exit_sound", "beep:2"},
                {"exit_sound_method", "GET"},
                {"delay_dial", 0},
                {"start_recording_audio_method", "GET"},
                {"stop_recording_audio_method", "GET"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/name_thanos/Participant/",
                    "",
                    data);
            
            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcAddParticipantResponse.json"
                );
            Setup<MultiPartyCallAddParticipantResponse>(201, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.AddParticipant(role: "agent", 
                        friendlyName: "thanos",
                        from: "918888888888", to: "917013835803")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStart()
        {
            var data = new Dictionary<string, object>()
            {
                {"status", "active"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<MultiPartyCall>>(204, response);
            
            Assert.Null(
                    Api.MultiPartyCall.Start(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
                );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStop()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<MultiPartyCall>>(204, response);
            
            Assert.Null(
                    Api.MultiPartyCall.Stop(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
                );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStartRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"file_format", "mp3"},
                {"recording_callback_method", "POST"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Record/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/mpcStartRecordingResponse.json"
            );
            Setup<RecordCreateResponse<MultiPartyCall>>(202, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.StartRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStopRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Record/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<MultiPartyCall>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.StopRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcPauseRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Record/Pause/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<MultiPartyCall>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.PauseRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcResumeRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Record/Resume/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<MultiPartyCall>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.ResumeRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcListParticipants()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcListParticipantsResponse.json"
                );
            Setup<ListResponse<MultiPartyCallParticipant>>(200, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.ListParticipants(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b")
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcUpdateParticipant()
        {
            var data = new Dictionary<string, object>()
            {
                {"coach_mode", false},
                {"mute", true},
                {"hold", false},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/209/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcUpdateParticipantResponse.json"
                );
            Setup<UpdateResponse<MultiPartyCallParticipant>>(202, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.UpdateParticipant(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", 
                        participantId: "209", coachMode: false,
                       mute: true, hold: false )
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcGetParticipant()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "GET",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/209/",
                    "",
                    data);

            var response =
                System.IO.File.ReadAllText(
                    SOURCE_DIR + @"../Mocks/mpcGetParticipantResponse.json"
                );
            Setup<MultiPartyCallParticipant>(200, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.GetParticipant(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", 
                        participantId: "209" )
                )
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcKickParticipant()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/209/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<MultiPartyCallParticipant>>(204, response);
            
            Assert.Null(
                    Api.MultiPartyCall.KickParticipant(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", 
                        participantId: "209" )
                );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStartParticipantRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"file_format", "mp3"},
                {"recording_callback_method", "POST"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/10/Record/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/mpcStartParticipantRecordingResponse.json"
            );
            Setup<RecordCreateResponse<MultiPartyCallParticipant>>(200, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.StartParticipantRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b",
                        participantId: "10")
                )
            );
            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStopParticipantRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/10/Record/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<MultiPartyCallParticipant>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.StopParticipantRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", participantId: "10")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcPauseParticipantRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/10/Record/Pause/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<MultiPartyCallParticipant>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.PauseParticipantRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", participantId: "10")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcResumeParticipantRecording()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/uuid_ebacced2-21ab-466d-9df4-67339991761b/Participant/10/Record/Resume/",
                    "",
                    data);

            var response = "";
            Setup<UpdateResponse<MultiPartyCallParticipant>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.ResumeParticipantRecording(mpcUuid: "ebacced2-21ab-466d-9df4-67339991761b", participantId: "10")
            );

            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStartPlayAudio()
        {
            var data = new Dictionary<string, object>()
            {
                {"url", "https://s3.amazonaws.com/XXX/XXX.mp3"},
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "POST",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/name_sampleMpc/Member/10/Play/",
                    "",
                    data);

            var response = System.IO.File.ReadAllText(
                SOURCE_DIR + @"../Mocks/mpcStartPlayAudio.json"
            );
            Setup<MultiPartyCallParticipantPlayResponse<MultiPartyCallParticipant>>(202, response);
            
            Assert.Empty(
                ComparisonUtilities.Compare(
                    response,
                    Api.MultiPartyCall.StartPlayAudio(friendlyName: "sampleMpc",
                        participantId: "10", url: "https://s3.amazonaws.com/XXX/XXX.mp3")
                )
            );
            AssertRequest(request);
        }
        
        [Fact]
        public void TestMpcStopPlayAudio()
        {
            var data = new Dictionary<string, object>()
            {
                {"is_voice_request", true}
            };
            
            var request =
                new PlivoRequest(
                    "DELETE",
                    "Account/MAXXXXXXXXXXXXXXXXXX/MultiPartyCall/name_sampleMpc/Member/10/Play/",
                    "",
                    data);

            var response = "";
            Setup<DeleteResponse<MultiPartyCallParticipant>>(204, response);
            
            Assert.Null(
                Api.MultiPartyCall.StopPlayAudio(friendlyName: "sampleMpc", participantId: "10")
            );

            AssertRequest(request);
        }
    }
}