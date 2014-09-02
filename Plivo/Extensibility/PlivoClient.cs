using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plivo.Objects;
using RestSharp;

namespace Plivo.Extensibility
{
    public abstract class PlivoClient:IPlivoClient
    {
        public string Version { get; set; }
        public string AuthID { get; set; }
        public string AuthToken { get; set; }

        protected PlivoClient(string authId,string authToken,string version = "v1")
        {
            AuthID = authId;
            AuthToken = authToken;
            Version = version;
        }

        public abstract IPlivoResponse<Account> GetAccount();
        public abstract Task<IPlivoResponse<Account>> GetAccountAsync();

        public abstract IPlivoResponse<GenericResponse> ModifyAccount(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifyAccountAsync(Dictionary<string, string> parameters);

        public abstract IPlivoResponse<SubAccountList> GetSubaccounts();
        public abstract Task<IPlivoResponse<SubAccountList>> GetSubaccountsAsync();

        public abstract IPlivoResponse<SubAccount> GetSubAccount(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<SubAccount>> GetSubAccountAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> CreateSubAccount(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> CreateSubAccountAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> ModifySubAccount(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifySubAccountAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> DeleteSubAccount(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteSubAccountAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<ApplicationList> GetApplications();
        public abstract Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync();

        public abstract IPlivoResponse<ApplicationList> GetApplications(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<Application> GetApplication(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Application>> GetApplicationAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> CreateApplication(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> CreateApplicationAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> ModifyApplication(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifyApplicationAsync(Dictionary<string, string> parameters);
        
        
        public abstract IPlivoResponse<GenericResponse> DeleteApplication(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteApplicationAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<NumberList> GetNumbers();
        public abstract Task<IPlivoResponse<NumberList>> GetNumbersAsync();

        public abstract IPlivoResponse<NumberList> SearchNumbers(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<NumberList>> SearchNumbersAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<NumberList> SearchNumberGroup(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<NumberList>> SearchNumberGroupAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<Number> GetNumber(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Number>> GetNumberAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> RentNumber(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> RentNumberAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<NumberResponse> RentFromNumberGroup(Dictionary<string, string> parameters);

        public abstract Task<IPlivoResponse<NumberResponse>> RentFromNumberGroupAsync(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<NumberResponse>> RentFromNumberAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> UnrentNumber(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> UnrentNumberAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> LinkApplicationNumber(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> LinkApplicationNumberAsync(Dictionary<string, string> parameters);
        
        public abstract IPlivoResponse<GenericResponse> UnlinkApplicationNumber(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> UnlinkApplicationNumberAsync(Dictionary<string, string> parameters);

        public abstract IPlivoResponse<CdrList> GetCdrs();
        public abstract Task<IPlivoResponse<CdrList>> GetCdrsAsync();

        public abstract IPlivoResponse<CdrList> GetCdrs(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<CdrList>> GetCdrsAsync(Dictionary<string, string> parameters);

        public abstract IPlivoResponse<CDR> GetCdr(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<CDR>> GetCdrAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<LiveCallList> GetLiveCalls();
        public abstract Task<IPlivoResponse<LiveCallList>> GetLiveCallsAsync();
        public abstract IPlivoResponse<LiveCall> GetLiveCall(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<LiveCall>> GetLiveCallAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Call> MakeCall(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Call>> MakeCallAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Call> MakeBulkCall(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders);
        public abstract Task<IPlivoResponse<Call>> MakeBulkCallAsync(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders);
        public abstract IPlivoResponse<GenericResponse> HangupAllCalls();
        public abstract Task<IPlivoResponse<GenericResponse>> HangupAllCallsAsync();
        public abstract IPlivoResponse<GenericResponse> HangupCall(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> HangupCallAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> TransferCall(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> TransferCallAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Record> Record(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Record>> RecordAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> StopRecord(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> StopRecordAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> Play(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> PlayAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> StopPlay(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> StopPlayAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> Speak(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> SpeakAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> StopSpeak(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> StopSpeakAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> SendDigits(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> SendDigitsAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<LiveConferenceList> GetLiveConferences();
        public abstract Task<IPlivoResponse<LiveConferenceList>> GetLiveConferencesAsync();
        public abstract IPlivoResponse<GenericResponse> HangupAllConferences();
        public abstract Task<IPlivoResponse<GenericResponse>> HangupAllConferencesAsync();
        public abstract IPlivoResponse<Conference> GetLiveConference(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Conference>> GetLiveConferenceAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> HangupConference(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> HangupConferenceAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> HangupMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> HangupMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> PlayMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> PlayMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> StopPlayMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> StopPlayMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> SpeakMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> SpeakMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeafMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeafMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> UndeadMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> UndeadMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> MuteMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> MuteMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> UnmuteMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> UnmuteMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> KickMember(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> KickMemberAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Record> RecordConference(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Record>> RecordConferenceAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> StopRecordConference(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> StopRecordConferenceAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<EndpointList> GetEndpoints();
        public abstract Task<IPlivoResponse<EndpointList>> GetEndpointsAsync();
        public abstract IPlivoResponse<EndpointList> GetEndpoints(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<EndpointList>> GetEndpointsAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Endpoint> CreateEndpoint(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Endpoint>> CreateEndpointAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Endpoint> GetEndpoint(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Endpoint>> GetEndpointAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> ModifyEndpoint(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifyEndpointAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeleteEndpoint(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteEndpointAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<MessageResponse> SendMessage(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<MessageResponse>> SendMessageAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<Message> GetMessage(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Message>> GetMessageAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<MessageList> GetMessages();
        public abstract Task<IPlivoResponse<MessageList>> GetMessagesAsync();
        public abstract IPlivoResponse<MessageList> GetMessages(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<MessageList>> GetMessagesAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<IncomingCarrierList> GetIncomingCarriers(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<IncomingCarrierList>> GetIncomingCarriersAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<IncomingCarrier> GetIncomingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<IncomingCarrier>> GetIncomingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> CreateIncomingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> CreateIncomingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<IncomingCarrier> ModifyIncomingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<IncomingCarrier>> ModifyIncomingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeleteIncomingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteIncomingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<PlivoPricing> Pricing(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<PlivoPricing>> PricingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<OutgoingCarrierList> GetOutgoingCarriers();
        public abstract Task<IPlivoResponse<OutgoingCarrierList>> GetOutgoingCarriersAsync();
        public abstract IPlivoResponse<OutgoingCarrier> GetOutgoingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<OutgoingCarrier>> GetOutgoingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> CreateOutgoingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> ModifyOutgoingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeleteOutgoingCarrier(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<OutgoingCarrierRoutingList> GetOutgoingCarrierRoutings();
        public abstract Task<IPlivoResponse<OutgoingCarrierRoutingList>> GetOutgoingCarrierRoutingsAsync();
        public abstract IPlivoResponse<OutgoingCarrierRouting> GetOutgoingCarrierRouting(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<OutgoingCarrierRouting>> GetOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> CreateOutgoingCarrierRouting(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> ModifyOutgoingCarrierRouting(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeleteOutgoingCarrierRouting(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<RecordingList> GetRecordings();
        public abstract Task<IPlivoResponse<RecordingList>> GetRecordingsAsync();
        public abstract IPlivoResponse<Recording> GetRecording(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<Recording>> GetRecordingAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<RecordingList> GetRecordingByCallUuid(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<RecordingList>> GetRecordingByCallUuidAsync(Dictionary<string, string> parameters);
        public abstract IPlivoResponse<GenericResponse> DeleteRecording(Dictionary<string, string> parameters);
        public abstract Task<IPlivoResponse<GenericResponse>> DeleteRecordingAsync(Dictionary<string, string> parameters);
    }
}
