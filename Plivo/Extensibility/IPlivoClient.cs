using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plivo.Models;
using RestSharp;

namespace Plivo.Extensibility
{
    public interface IPlivoClient
    {
        IPlivoResponse<Account> GetAccount();
        Task<IPlivoResponse<Account>> GetAccountAsync();

        IPlivoResponse<GenericResponse> ModifyAccount(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifyAccountAsync(Dictionary<string, string> parameters);
        
        IPlivoResponse<SubAccountList> GetSubaccounts();
        Task<IPlivoResponse<SubAccountList>> GetSubaccountsAsync();

        IPlivoResponse<SubAccount> GetSubAccount(Dictionary<string, string> parameters);
        Task<IPlivoResponse<SubAccount>> GetSubAccountAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> CreateSubAccount(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> CreateSubAccountAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> ModifySubAccount(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifySubAccountAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteSubAccount(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteSubAccountAsync(Dictionary<string, string> parameters);

        IPlivoResponse<ApplicationList> GetApplications();
        Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync();

        IPlivoResponse<ApplicationList> GetApplications(Dictionary<string, string> parameters);
        Task<IPlivoResponse<ApplicationList>> GetApplicationsAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Application> GetApplication(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Application>> GetApplicationAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> CreateApplication(Dictionary<string, string> parameters);
        Task< IPlivoResponse<GenericResponse>> CreateApplicationAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> ModifyApplication(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifyApplicationAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteApplication(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteApplicationAsync(Dictionary<string, string> parameters);

        IPlivoResponse<NumberList> GetNumbers();
        Task<IPlivoResponse<NumberList>> GetNumbersAsync();

        [Obsolete("Use SearchNumberGroup() instead")]
        IPlivoResponse<NumberList> SearchNumbers(Dictionary<string, string> parameters);
        [Obsolete("Use SearchNumberGroupAsync() instead")]
        Task<IPlivoResponse<NumberList>> SearchNumbersAsync(Dictionary<string, string> parameters);

        IPlivoResponse<NumberList> SearchNumberGroup(Dictionary<string, string> parameters);
        Task<IPlivoResponse<NumberList>> SearchNumberGroupAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Number> GetNumber(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Number>> GetNumberAsync(Dictionary<string, string> parameters);

        [Obsolete("Use RentFromNumberGroup() instead")]
        IPlivoResponse<GenericResponse> RentNumber(Dictionary<string, string> parameters);
        [Obsolete("Use RentFromNumberGroupAsync() instead")]
        Task<IPlivoResponse<GenericResponse>> RentNumberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<NumberResponse> RentFromNumberGroup(Dictionary<string, string> parameters);
        Task<IPlivoResponse<NumberResponse>> RentFromNumberGroupAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> UnrentNumber(Dictionary<string, string> parameters);
       Task<IPlivoResponse<GenericResponse>> UnrentNumberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> LinkApplicationNumber(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> LinkApplicationNumberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> UnlinkApplicationNumber(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> UnlinkApplicationNumberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<CdrList> GetCdrs();
        Task<IPlivoResponse<CdrList>> GetCdrsAsync();

        IPlivoResponse<CdrList> GetCdrs(Dictionary<string, string> parameters);
        Task<IPlivoResponse<CdrList>> GetCdrsAsync(Dictionary<string, string> parameters);

        IPlivoResponse<CDR> GetCdr(Dictionary<string, string> parameters);
        Task<IPlivoResponse<CDR>> GetCdrAsync(Dictionary<string, string> parameters);

        IPlivoResponse<LiveCallList> GetLiveCalls();
        Task<IPlivoResponse<LiveCallList>> GetLiveCallsAsync();

        IPlivoResponse<LiveCall> GetLiveCall(Dictionary<string, string> parameters);
        Task<IPlivoResponse<LiveCall>> GetLiveCallAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Call> MakeCall(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Call>> MakeCallAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Call> MakeBulkCall(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders);
        Task<IPlivoResponse<Call>> MakeBulkCallAsync(Dictionary<string, string> parameters, Dictionary<string, string> destNumberSipHeaders);
        
        IPlivoResponse<GenericResponse> HangupAllCalls();
        Task<IPlivoResponse<GenericResponse>> HangupAllCallsAsync();

        IPlivoResponse<GenericResponse> HangupCall(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> HangupCallAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> TransferCall(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> TransferCallAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Record> Record(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Record>> RecordAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> StopRecord(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> StopRecordAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> Play(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> PlayAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> StopPlay(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> StopPlayAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> Speak(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> SpeakAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> StopSpeak(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> StopSpeakAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> SendDigits(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> SendDigitsAsync(Dictionary<string, string> parameters);

        IPlivoResponse<LiveConferenceList> GetLiveConferences();
        Task<IPlivoResponse<LiveConferenceList>> GetLiveConferencesAsync();

        IPlivoResponse<GenericResponse> HangupAllConferences();
        Task<IPlivoResponse<GenericResponse>> HangupAllConferencesAsync();

        IPlivoResponse<Conference> GetLiveConference(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Conference>> GetLiveConferenceAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> HangupConference(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> HangupConferenceAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> HangupMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> HangupMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> PlayMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> PlayMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> StopPlayMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> StopPlayMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> SpeakMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> SpeakMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeafMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeafMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> UndeadMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> UndeadMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> MuteMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> MuteMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> UnmuteMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> UnmuteMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> KickMember(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> KickMemberAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Record> RecordConference(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Record>> RecordConferenceAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> StopRecordConference(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> StopRecordConferenceAsync(Dictionary<string, string> parameters);

        IPlivoResponse<EndpointList> GetEndpoints();
        Task<IPlivoResponse<EndpointList>> GetEndpointsAsync();

        IPlivoResponse<EndpointList> GetEndpoints(Dictionary<string, string> parameters);
        Task<IPlivoResponse<EndpointList>> GetEndpointsAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Endpoint> CreateEndpoint(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Endpoint>> CreateEndpointAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Endpoint> GetEndpoint(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Endpoint>> GetEndpointAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> ModifyEndpoint(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifyEndpointAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteEndpoint(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteEndpointAsync(Dictionary<string, string> parameters);

        IPlivoResponse<MessageResponse> SendMessage(Dictionary<string, string> parameters);
        Task<IPlivoResponse<MessageResponse>> SendMessageAsync(Dictionary<string, string> parameters);

        IPlivoResponse<Message> GetMessage(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Message>> GetMessageAsync(Dictionary<string, string> parameters);

        IPlivoResponse<MessageList> GetMessages();
        Task<IPlivoResponse<MessageList>> GetMessagesAsync();

        IPlivoResponse<MessageList> GetMessages(Dictionary<string, string> parameters);
        Task<IPlivoResponse<MessageList>> GetMessagesAsync(Dictionary<string, string> parameters);

        IPlivoResponse<IncomingCarrierList> GetIncomingCarriers(Dictionary<string, string> parameters);
        Task<IPlivoResponse<IncomingCarrierList>> GetIncomingCarriersAsync(Dictionary<string, string> parameters);

        IPlivoResponse<IncomingCarrier> GetIncomingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<IncomingCarrier>> GetIncomingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> CreateIncomingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> CreateIncomingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<IncomingCarrier> ModifyIncomingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<IncomingCarrier>> ModifyIncomingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteIncomingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteIncomingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<PlivoPricing> Pricing(Dictionary<string, string> parameters);
        Task<IPlivoResponse<PlivoPricing>> PricingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<OutgoingCarrierList> GetOutgoingCarriers();
        Task<IPlivoResponse<OutgoingCarrierList>> GetOutgoingCarriersAsync();

        IPlivoResponse<OutgoingCarrier> GetOutgoingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<OutgoingCarrier>> GetOutgoingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> CreateOutgoingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> ModifyOutgoingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteOutgoingCarrier(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierAsync(Dictionary<string, string> parameters);

        IPlivoResponse<OutgoingCarrierRoutingList> GetOutgoingCarrierRoutings();
        Task<IPlivoResponse<OutgoingCarrierRoutingList>> GetOutgoingCarrierRoutingsAsync();

        IPlivoResponse<OutgoingCarrierRouting> GetOutgoingCarrierRouting(Dictionary<string, string> parameters);
        Task<IPlivoResponse<OutgoingCarrierRouting>> GetOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> CreateOutgoingCarrierRouting(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> CreateOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> ModifyOutgoingCarrierRouting(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> ModifyOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteOutgoingCarrierRouting(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteOutgoingCarrierRoutingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<RecordingList> GetRecordings();
        Task<IPlivoResponse<RecordingList>> GetRecordingsAsync();

        IPlivoResponse<Recording> GetRecording(Dictionary<string, string> parameters);
        Task<IPlivoResponse<Recording>> GetRecordingAsync(Dictionary<string, string> parameters);

        IPlivoResponse<RecordingList> GetRecordingByCallUuid(Dictionary<string, string> parameters);
        Task<IPlivoResponse<RecordingList>> GetRecordingByCallUuidAsync(Dictionary<string, string> parameters);

        IPlivoResponse<GenericResponse> DeleteRecording(Dictionary<string, string> parameters);
        Task<IPlivoResponse<GenericResponse>> DeleteRecordingAsync(Dictionary<string, string> parameters);
    }
}