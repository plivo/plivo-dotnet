using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Plivo.API
{
    // JSON Response
    public class PlivoResponse
    {
        public override string ToString()
        {
            string s = JsonConvert.SerializeObject(this, Formatting.Indented);
            return s;
        }
    }
    // Generic Models
    public class GenericResponse : PlivoResponse
    {
        public string message { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }

    public class Record : PlivoResponse
    {
        public string url { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }

    //Recording Models

    public class RecordingMeta : PlivoResponse
    {
        public object previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }
    public class RecordingList : PlivoResponse
    {
        public RecordingMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Recording> objects { get; set; }
    }
    public class Recording : PlivoResponse
    {
        public string add_time { get; set; }
        public string call_uuid { get; set; }
        public string conference_name { get; set; }
        public string recording_duration_ms { get; set; }
        public string recording_end_ms { get; set; }
        public string recording_format { get; set; }
        public string recording_id { get; set; }
        public string recording_start_ms { get; set; }
        public string recording_type { get; set; }
        public string recording_url { get; set; }
        public string resource_uri { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }

    // Account Models
    public class Account : PlivoResponse
    {
        public string account_type { get; set; }
        public string address { get; set; }
        public string api_id { get; set; }
        public string auth_id { get; set; }
        public string auto_recharge { get; set; }
        public string billing_mode { get; set; }
        public string cash_credits { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string resource_uri { get; set; }
        public string state { get; set; }
        public string timezone { get; set; }
    }

    public class ResourceListMeta : PlivoResponse
    {
        public object previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }
    public class SubAccountMeta : PlivoResponse
    {
        public object previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class SubAccountResponse : PlivoResponse
	{
		public string api_id { get; set; }
		public string auth_id { get; set; }
		public string auth_token { get; set; }
		public string message { get; set; }
	}

    public class SubAccount : PlivoResponse
    {
        public string account { get; set; }
        public string name { get; set; }
        public string created { get; set; }
        public bool enabled { get; set; }
        public string modified { get; set; }
        public string auth_id { get; set; }
        public string resource_uri { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public string auth_token { get; set; }
        public string old_auth_token { get; set; }
    }

    public class SubAccountList : PlivoResponse
    {
        public SubAccountMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<SubAccount> objects { get; set; }
    }

    // Application Models
    public class ApplicationMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class Application : PlivoResponse
    {
        public string fallback_method { get; set; }
        public bool default_app { get; set; }
        public string app_name { get; set; }
        public string sub_account { get; set; }
        public bool production_app { get; set; }
        public bool enabled { get; set; }
        public string app_id { get; set; }
        public bool public_uri { get; set; }
        public string hangup_url { get; set; }
        public string sip_uri { get; set; }
        public string answer_url { get; set; }
        public string message_url { get; set; }
        public string resource_uri { get; set; }
        public string hangup_method { get; set; }
        public string message_method { get; set; }
        public string fallback_answer_url { get; set; }
        public string answer_method { get; set; }
    }

    public class ApplicationList : PlivoResponse
    {
        public ApplicationMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Application> objects { get; set; }
    }

    // Number Models
    public class NumberMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class Number : PlivoResponse
    {
        public string region { get; set; }
        public bool voice_enabled { get; set; }
        public bool sms_enabled { get; set; }
        public bool fax_enabled { get; set; }
        public string number { get; set; }
        public string api_id { get; set; }
        public string voice_rate { get; set; }
        public string application { get; set; }
        public string sms_rate { get; set; }
        public string number_type { get; set; }
        public string sub_account { get; set; }
        public string added_on { get; set; }
        public string resource_uri { get; set; }
        public string group_id { get; set; }
        public string prefix { get; set; }
        public string rental_rate { get; set; }
        public string setup_rate { get; set; }
        public int stock { get; set; }
        [ObsoleteAttribute]
        public string country { get; set; }
        [ObsoleteAttribute]
        public int lata { get; set; }
        [ObsoleteAttribute("Use the attribute rental_rate instead")]
        public string monthly_rental_rate { get; set; }
    }

    public class NumberList : PlivoResponse
    {
        public NumberMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<Number> objects { get; set; }
    }

    public class NumberStatus : PlivoResponse
    {
        public string number { get; set; }
        public string status { get; set; }
    }

    public class NumberResponse : PlivoResponse
    {
        public List<NumberStatus> numbers { get; set; }
        public string status { get; set; }
    }

    public class PhoneNumberStatus : PlivoResponse
    {
        public string number { get; set; }
        public string status { get; set; }
    }

    public class PhoneNumberResponse : PlivoResponse
    {
        public List<PhoneNumberStatus> numbers { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }

    public class PhoneNumberMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class PhoneNumber : PlivoResponse
    {
        public string country { get; set; }
        public int lata { get; set; }
        public string monthly_rental_rate { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public string prefix { get; set; }
        public string rate_center { get; set; }
        public string region { get; set; }
        public string resource_uri { get; set; }
        public string restriction_text { get; set; }
        public string restriction { get; set; }
        public string setup_rate { get; set; }
        public bool sms_enabled { get; set; }
        public string sms_rate { get; set; }
        public bool voice_enabled { get; set; }
        public string voice_rate { get; set; }
    }


    public class PhoneNumberList : PlivoResponse
    {
        public PhoneNumberMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<PhoneNumber> objects { get; set; }
    }

    // Call Models
    public class Call : PlivoResponse
    {
        public string message { get; set; }
        public string request_uuid { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public string invalid_numbers { get; set; }
    }

    public class LiveCall : PlivoResponse
    {
        public string direction { get; set; }
        public string from { get; set; }
        public string call_status { get; set; }
        public string api_id { get; set; }
        public string to { get; set; }
        public string caller_name { get; set; }
        public string call_uuid { get; set; }
        public string session_start { get; set; }
        public string error { get; set; }
    }

    public class LiveCallList : PlivoResponse
    {
        public string api_id { get; set; }
        public List<string> calls { get; set; }
        public string error { get; set; }
    }

    public class CDRMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class CDR : PlivoResponse
    {
        public int bill_duration { get; set; }
        public int call_duration { get; set; }
        public int billed_duration { get; set; }
        public string total_amount { get; set; }
        public string parent_call_uuid { get; set; }
        public string call_direction { get; set; }
        public string to_number { get; set; }
        public string total_rate { get; set; }
        public string from_number { get; set; }
        public string end_time { get; set; }
        public string answer_time { get; set; }
        public string initiation_time { get; set; }
        public string call_uuid { get; set; }
        public string resource_uri { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }

    public class CDRList : PlivoResponse
    {
        public CDRMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<CDR> objects { get; set; }
    }

    // Conference Models
    public class LiveConferenceList : PlivoResponse
    {
        public string error { get; set; }
        public string api_id { get; set; }
        public List<string> conferences { get; set; }
    }

    public class ConferenceMember : PlivoResponse
    {
        public string call_uuid { get; set; }
        public string caller_name { get; set; }
        public bool deaf { get; set; }
        public string direction { get; set; }
        public string from { get; set; }
        public string join_time { get; set; }
        public string member_id { get; set; }
        public bool muted { get; set; }
        public string to { get; set; }
    }

    public class Conference : PlivoResponse
    {
        public string error { get; set; }
        public string api_id { get; set; }
        public string conference_member_count { get; set; }
        public string conference_name { get; set; }
        public string conference_run_time { get; set; }
        public List<ConferenceMember> members { get; set; }
    }

    // Endpoint Models
    public class EndpointMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class Endpoint : PlivoResponse
    {
        public string username { get; set; }
        public string sip_uri { get; set; }
        public string alias { get; set; }
        public string endpoint_id { get; set; }
        public string password { get; set; }
        public string resource_uri { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
    }

    public class EndpointList : PlivoResponse
    {
        public EndpointMeta meta { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
        public List<Endpoint> objects { get; set; }
    }

    // Message Models
    public class MessageResponse : PlivoResponse
    {
        public string message { get; set; }
        public List<string> message_uuid { get; set; }
        public string error { get; set; }
        public string api_id { get; set; }
    }

    public class MessageMeta : PlivoResponse
    {
        public string previous { get; set; }
        public int total_count { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
    }

    public class Message : PlivoResponse
    {
        public string cloud_rate { get; set; }
        public string carrier_rate { get; set; }
        public string message_direction { get; set; }
        public string to_number { get; set; }
        public string message_state { get; set; }
        public string total_amount { get; set; }
        public string from_number { get; set; }
        public string message_uuid { get; set; }
        public string message_time { get; set; }
        public string resource_uri { get; set; }
        public string message_type { get; set; }
        public string total_rate { get; set; }
        public int units { get; set; }
    }

    public class MessageList : PlivoResponse
    {
        public MessageMeta meta { get; set; }
        public string api_id { get; set; }
        public List<Message> objects { get; set; }
    }

    // Incoming Carrier Models
    public class IncomingCarrierMeta : PlivoResponse
    {
        public string previous { get; set; }
        public string total_count { get; set; }
        public string offset { get; set; }
        public string limit { get; set; }
        public string next { get; set; }
    }

    public class IncomingCarrier : PlivoResponse
    {
        public string carrier_id { get; set; }
        public string ip_set { get; set; }
        public string name { get; set; }
        public string resource_uri { get; set; }
        public string sms { get; set; }
        public string voice { get; set; }
    }

    public class IncomingCarrierList : PlivoResponse
    {
        public IncomingCarrierMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<IncomingCarrier> objects { get; set; }
    }

    public class OutgoingCarrierMeta : PlivoResponse
    {
        public string previous { get; set; }
        public string total_count { get; set; }
        public string offset { get; set; }
        public string limit { get; set; }
        public string next { get; set; }
    }
    public class OutgoingCarrier : PlivoResponse
    {
        public string carrier_id { get; set; }
        public string ips { get; set; }
        public string prefix { get; set; }
        public string failover_prefix { get; set; }
        public string address { get; set; }
        public string failover_address { get; set; }
        public string enabled { get; set; }
        public string retries { get; set; }
        public string resource_uri { get; set; }
    }

    public class OutgoingCarrierList : PlivoResponse
    {
        public OutgoingCarrierMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<OutgoingCarrier> objects { get; set; }
    }

    public class OutgoingCarrierRouting : PlivoResponse
    {
        public string routing_id { get; set; }
        public string digits { get; set; }
        public int priority { get; set; }
        public string outgoing_carrier { get; set; }
        public string resource_uri { get; set; }
    }

    public class OutgoingCarrierRoutingList : PlivoResponse
    {
        public ResourceListMeta meta { get; set; }
        public string api_id { get; set; }
        public string error { get; set; }
        public List<OutgoingCarrierRouting> objects { get; set; }
    }

    // Pricing
    public class LocalNumberRental : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class TollfreeNumberRental : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class PhoneNumbers : PlivoResponse
    {
        public LocalNumberRental local { get; set; }
        public TollfreeNumberRental tollfree { get; set; }
    }

    public class SipInboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class LocalInboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class TollfreeInboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class InboundVoicePricing : PlivoResponse
    {
        public SipInboundPricing ip { get; set; }
        public LocalInboundPricing local { get; set; }
        public TollfreeInboundPricing tollfree { get; set; }
    }

    public class SipOutboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class LocalOutboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class TollfreeOutboundPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class RatesPrefixes : PlivoResponse
    {
        public string rate { get; set; }
        public List<string> prefix { get; set; }
    }

    public class OutboundVoicePricing : PlivoResponse
    {
        public SipOutboundPricing ip { get; set; }
        public LocalOutboundPricing local { get; set; }
        public TollfreeOutboundPricing tollfree { get; set; }
        public List<RatesPrefixes> rates { get; set; }
    }

    public class VoiceRates : PlivoResponse
    {
        public InboundVoicePricing inbound { get; set; }
        public OutboundVoicePricing outbound { get; set; }
    }

    public class InboundSmsPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class OutboundSmsPricing : PlivoResponse
    {
        public string rate { get; set; }
    }

    public class SmsRates : PlivoResponse
    {
        public InboundSmsPricing inbound { get; set; }
        public OutboundSmsPricing outbound { get; set; }
    }

    public class PlivoPricing:PlivoResponse
    {
        public string country_code { get; set; }
        public string country_iso { get; set; }
        public string country { get; set; }
        public PhoneNumbers phone_numbers { get; set; }
        public VoiceRates voice { get; set; }
        public SmsRates message { get; set; }
        public string api_id { get; set; }
    }
}
