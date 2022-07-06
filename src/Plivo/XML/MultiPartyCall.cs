using dict = System.Collections.Generic.Dictionary<string, string>;
using list = System.Collections.Generic.List<string>;
using Plivo.Exception;
using System;
using System.Globalization;
using Plivo.Utilities;

namespace Plivo.XML
{
    public class MultiPartyCall : PlivoElement
    {
        public MultiPartyCall(string body, dict parameters)
            : base(body, parameters)
        {
            Nestables = new list() {""};
            ValidAttributes = new list()
            {
                "role",
                "maxDuration",
                "maxParticipants",
                "recordMinMemberCount",
                "waitMusicUrl",
                "waitMusicMethod",
                "agentHoldMusicUrl",
                "agentHoldMusicMethod",
                "customerHoldMusicUrl",
                "customerHoldMusicMethod",
                "record",
                "recordFileFormat",
                "recordingCallbackUrl",
                "recordingCallbackMethod",
                "statusCallbackEvents",
                "statusCallbackUrl",
                "statusCallbackMethod",
                "stayAlone",
                "coachMode",
                "mute",
                "hold",
                "startMpcOnEnter",
                "endMpcOnExit",
                "enterSound",
                "enterSoundMethod",
                "exitSound",
                "exitSoundMethod",
                "onExitActionUrl",
                "onExitActionMethod",
                "relayDTMFInputs",
                "startRecordingAudio",
                "startRecordingAudioMethod",
                "stopRecordingAudio",
                "stopRecordingAudioMethod"
            };
            if (body == null)
            {
                throw new PlivoXMLException("No MultiPartyCall name set for " + Element.Name);
            }
            var VALID_ROLE_VALUES = new list() {"agent", "supervisor", "customer"};
            var VALID_METHOD_VALUES = new list() {"GET", "POST"};
            var VALID_RECORD_FILE_FORMAT_VALUES = new list() {"mp3", "wav"};
            var VALID_BOOL_VALUES = new list() {"true", "false"};

            if (!Attributes.ContainsKey("role"))
            {
                throw new PlivoXMLException("role is mandatory  but not mentioned : " +
                                            "possible values - Agent / Supervisor / Customer");
            }
            else if(Attributes["role"] != null && !VALID_ROLE_VALUES.Contains(Attributes["role"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["role"] + " for role");
            }

            if(!Attributes.ContainsKey("maxDuration"))
            {
                Attributes["maxDuration"] = "14400";
            }
            else if (Attributes["maxDuration"] != null && (Convert.ToUInt32(Attributes["maxDuration"]) < 300 ||
                                                           Convert.ToUInt32(Attributes["maxDuration"]) > 28800))
            { 
                throw new PlivoXMLException("Invalid attribute value " + Attributes["maxDuration"] +
                                          " for maxDuration");
            }
            
            if(!Attributes.ContainsKey("maxParticipants"))
            {
                Attributes["maxParticipants"] = "10";
            }
            else if (Attributes["maxParticipants"] != null && (Convert.ToUInt32(Attributes["maxParticipants"]) < 2 ||
                                                               Convert.ToUInt32(Attributes["maxParticipants"]) > 10))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["maxParticipants"] +
                                            " for maxParticipants");
            }
            
            if(!Attributes.ContainsKey("recordMinMemberCount"))
            {
                Attributes["recordMinMemberCount"] = "1";
            }
            else if (Attributes["recordMinMemberCount"] != null && (Convert.ToUInt32(Attributes["recordMinMemberCount"]) < 1 ||
                                                               Convert.ToUInt32(Attributes["recordMinMemberCount"]) > 2))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["recordMinMemberCount"] +
                                            " for recordMinMemberCount");
            }

            if (!Attributes.ContainsKey("waitMusicMethod"))
            {
                Attributes["waitMusicMethod"] = "GET";
            }
            else if(Attributes["waitMusicMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["waitMusicMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["waitMusicMethod"] + " for waitMusicMethod"); 
            }

            if (!Attributes.ContainsKey("agentHoldMusicMethod"))
            {
                Attributes["agentHoldMusicMethod"] = "GET";
            }
            else if(Attributes["agentHoldMusicMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["agentHoldMusicMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["agentHoldMusicMethod"] + " for agentHoldMusicMethod"); 
            }
            
            if (!Attributes.ContainsKey("customerHoldMusicMethod"))
            {
                Attributes["customerHoldMusicMethod"] = "GET";
            }
            else if(Attributes["customerHoldMusicMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["customerHoldMusicMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["customerHoldMusicMethod"] + " for customerHoldMusicMethod"); 
            }
            
            if (!Attributes.ContainsKey("record"))
            {
                Attributes["record"] = "false";
            }
            else if(Attributes["record"] != null && !VALID_BOOL_VALUES.Contains(Attributes["record"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["record"] + " for record"); 
            }
            
            if (!Attributes.ContainsKey("recordFileFormat"))
            {
                Attributes["recordFileFormat"] = "mp3";
            }
            else if (Attributes["recordFileFormat"] != null && !VALID_RECORD_FILE_FORMAT_VALUES.Contains(Attributes["recordFileFormat"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["recordFileFormat"] + " for recordFileFormat");
            }
            
            if (!Attributes.ContainsKey("recordingCallbackMethod"))
            {
                Attributes["recordingCallbackMethod"] = "GET";
            }
            else if (Attributes["recordingCallbackMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["recordingCallbackMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["recordingCallbackMethod"] + " for recordingCallbackMethod");
            }
            
            if (!Attributes.ContainsKey("statusCallbackEvents"))
            {
                Attributes["statusCallbackEvents"] = "mpc-state-changes,participant-state-changes";
            }
            else if (Attributes["statusCallbackEvents"] != null && !MpcUtils.MultiValidParam("statusCallbackEvents", 
                Attributes["statusCallbackEvents"].ToLower(),
                false, true, new list()
                {
                    "mpc-state-changes", 
                    "participant-state-changes",
                    "participant-speak-events",
                    "participant-digit-input-events",
                    "add-participant-api-events"
                }, ','))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["statusCallbackEvents"] + " for statusCallbackEvents");
            }
            
            if (!Attributes.ContainsKey("statusCallbackMethod"))
            {
                Attributes["statusCallbackMethod"] = "POST";
            }
            else if (Attributes["statusCallbackMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["statusCallbackMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["statusCallbackMethod"] + " for statusCallbackMethod");
            }
            
            if (!Attributes.ContainsKey("stayAlone"))
            {
                Attributes["stayAlone"] = "false";
            }
            else if (Attributes["stayAlone"] != null && !VALID_BOOL_VALUES.Contains(Attributes["stayAlone"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["stayAlone"] + " for stayAlone");
            }
            
            if (!Attributes.ContainsKey("coachMode"))
            {
                Attributes["coachMode"] = "true";
            }
            else if (Attributes["coachMode"] != null && !VALID_BOOL_VALUES.Contains(Attributes["coachMode"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["coachMode"] + " for coachMode");
            }
            
            if (!Attributes.ContainsKey("mute"))
            {
                Attributes["mute"] = "false";
            }
            else if (Attributes["mute"] != null && !VALID_BOOL_VALUES.Contains(Attributes["mute"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["mute"] + " for mute");
            }

            if (!Attributes.ContainsKey("hold"))
            {
                Attributes["hold"] = "false";
            }
            else if (Attributes["hold"] != null && !VALID_BOOL_VALUES.Contains(Attributes["hold"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["hold"] + " for hold");
            }
            
            if (!Attributes.ContainsKey("startMpcOnEnter"))
            {
                Attributes["startMpcOnEnter"] = "true";
            }
            else if (Attributes["startMpcOnEnter"] != null && !VALID_BOOL_VALUES.Contains(Attributes["startMpcOnEnter"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["startMpcOnEnter"] + " for startMpcOnEnter");
            }
            
            if (!Attributes.ContainsKey("endMpcOnExit"))
            {
                Attributes["endMpcOnExit"] = "false";
            }
            else if (Attributes["endMpcOnExit"] != null && !VALID_BOOL_VALUES.Contains(Attributes["endMpcOnExit"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["endMpcOnExit"] + " for endMpcOnExit");
            }
            
            if (!Attributes.ContainsKey("enterSound"))
            {
                Attributes["enterSound"] = "beep:1";
            }
            else if (Attributes["enterSound"] != null && !MpcUtils.IsOneAmongStringUrl("enterSound", Attributes["enterSound"], false,
                new list() {"beep:1", "beep:2", "none"}))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["enterSound"] + " for enterSound");
            }
            
            if (!Attributes.ContainsKey("enterSoundMethod"))
            {
                Attributes["enterSoundMethod"] = "GET";
            }
            else if (Attributes["enterSoundMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["enterSoundMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["enterSoundMethod"] + " for enterSoundMethod");
            }
            
            if (!Attributes.ContainsKey("exitSound"))
            {
                Attributes["exitSound"] = "beep:2";
            }
            else if (Attributes["exitSound"] != null && !MpcUtils.IsOneAmongStringUrl("exitSound", Attributes["exitSound"], false,
                new list() {"beep:1", "beep:2", "none"}))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["exitSound"] + " for exitSound");
            }
            
            if (!Attributes.ContainsKey("exitSoundMethod"))
            {
                Attributes["exitSoundMethod"] = "GET";
            }
            else if (Attributes["exitSoundMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["exitSoundMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["exitSoundMethod"] + " for exitSoundMethod");
            }
            
            if (!Attributes.ContainsKey("onExitActionMethod"))
            {
                Attributes["onExitActionMethod"] = "POST";
            }
            else if (Attributes["onExitActionMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["onExitActionMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["onExitActionMethod"] + " for onExitActionMethod");
            }

            if (!Attributes.ContainsKey("relayDTMFInputs"))
            {
                Attributes["relayDTMFInputs"] = "false";
            }
            else if (Attributes["relayDTMFInputs"] != null && !VALID_BOOL_VALUES.Contains(Attributes["relayDTMFInputs"].ToLower()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["relayDTMFInputs"] + " for relayDTMFInputs");
            }

            if (Attributes.ContainsKey("waitMusicUrl") &&
                !MpcUtils.ValidUrl("waitMusicUrl", Attributes["waitMusicUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["waitMusicUrl"] + " for waitMusicUrl");
            }
            
            if (Attributes.ContainsKey("agentHoldMusicUrl") &&
                !MpcUtils.ValidUrl("agentHoldMusicUrl", Attributes["agentHoldMusicUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["agentHoldMusicUrl"] + " for agentHoldMusicUrl");
            }
            
            if (Attributes.ContainsKey("customerHoldMusicUrl") &&
                !MpcUtils.ValidUrl("customerHoldMusicUrl", Attributes["customerHoldMusicUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["customerHoldMusicUrl"] + " for customerHoldMusicUrl");
            }
            
            if (Attributes.ContainsKey("recordingCallbackUrl") &&
                !MpcUtils.ValidUrl("recordingCallbackUrl", Attributes["recordingCallbackUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["recordingCallbackUrl"] + " for recordingCallbackUrl");
            }
            
            if (Attributes.ContainsKey("statusCallbackUrl") &&
                !MpcUtils.ValidUrl("statusCallbackUrl", Attributes["statusCallbackUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["statusCallbackUrl"] + " for statusCallbackUrl");
            }
            
            if (Attributes.ContainsKey("onExitActionUrl") &&
                !MpcUtils.ValidUrl("onExitActionUrl", Attributes["onExitActionUrl"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["onExitActionUrl"] + " for onExitActionUrl");
            }
            
            if (Attributes.ContainsKey("startRecordingAudio") &&
                !MpcUtils.ValidUrl("startRecordingAudio", Attributes["startRecordingAudio"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["startRecordingAudio"] + " for startRecordingAudio");
            }
            
            if (!Attributes.ContainsKey("startRecordingAudioMethod"))
            {
                Attributes["startRecordingAudioMethod"] = "GET";
            }
            else if (Attributes["startRecordingAudioMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["startRecordingAudioMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["startRecordingAudioMethod"] + " for startRecordingAudioMethod");
            }
            
            if (Attributes.ContainsKey("stopRecordingAudio") &&
                !MpcUtils.ValidUrl("stopRecordingAudio", Attributes["stopRecordingAudio"], false))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["stopRecordingAudio"] + " for stopRecordingAudio");
            }
            
            if (!Attributes.ContainsKey("stopRecordingAudioMethod"))
            {
                Attributes["stopRecordingAudioMethod"] = "GET";
            }
            else if (Attributes["stopRecordingAudioMethod"] != null && !VALID_METHOD_VALUES.Contains(Attributes["stopRecordingAudioMethod"].ToUpper()))
            {
                throw new PlivoXMLException("Invalid attribute value " + Attributes["stopRecordingAudioMethod"] + " for stopRecordingAudioMethod");
            }
            addAttributes();
        }
    }
}