using System;
using System.Collections.Generic;
using System.Reflection;
using Plivo.Client;

namespace Plivo.Resource.Call
{
    /// <summary>
    /// Call.
    /// </summary>
    public class Call : Resource
    {
        public new string Id => CallUuid;
        public string AnswerTime { get; set; }
        public uint? BillDuration { get; set; }
        public uint? BilledDuration { get; set; }
        public string CallDirection { get; set; }
        public uint? CallDuration { get; set; }
        public string CallStatus { get; set; }
        public string CallUuid { get; set; }
        public string EndTime { get; set; }
        public string FromNumber { get; set; }
        public string InitiationTime { get; set; }
        public string ParentCallUuid { get; set; }
        public uint? PlivoHangupCauseCode { get; set; }
        public string PlivoHangupCauseName { get; set; }
        public string PlivoHangupSource { get; set; }
        public string ResourceUri { get; set; }
        public string ToNumber { get; set; }
        public string TotalAmount { get; set; }
        public string TotalRate { get; set; }

//        public Call(string answerTime, string apiId, uint? billDuration, uint? billedDuration, string callDirection,
//            uint? callDuration, string callUuid, string endTime, string fromNumber, string initiationTime,
//            string parentCallUuid, string resourceUri, string toNumber, string totalAmount, string totalRate)
//        {
//            AnswerTime = answerTime ?? throw new ArgumentNullException(nameof(answerTime));
//            ApiId = apiId ?? throw new ArgumentNullException(nameof(apiId));
//            BillDuration = billDuration ?? throw new ArgumentNullException(nameof(billDuration));
//            BilledDuration = billedDuration ?? throw new ArgumentNullException(nameof(billedDuration));
//            CallDirection = callDirection ?? throw new ArgumentNullException(nameof(callDirection));
//            CallDuration = callDuration ?? throw new ArgumentNullException(nameof(callDuration));
//            CallUuid = callUuid ?? throw new ArgumentNullException(nameof(callUuid));
//            EndTime = endTime ?? throw new ArgumentNullException(nameof(endTime));
//            FromNumber = fromNumber ?? throw new ArgumentNullException(nameof(fromNumber));
//            InitiationTime = initiationTime ?? throw new ArgumentNullException(nameof(initiationTime));
//            ParentCallUuid = parentCallUuid ?? throw new ArgumentNullException(nameof(parentCallUuid));
//            PlivoHangupCauseCode = plivoHangupCauseCode ?? throw new ArgumentNullException(nameof(plivoHangupCauseCode));
//            PlivoHangupCauseName = PlivoHangupCauseName ?? throw new ArgumentNullException(nameof(PlivoHangupCauseName));
//            PlivoHangupSource = PlivoHangupSource ?? throw new ArgumentNullException(nameof(PlivoHangupSource));
//            ResourceUri = resourceUri ?? throw new ArgumentNullException(nameof(resourceUri));
//            ToNumber = toNumber ?? throw new ArgumentNullException(nameof(toNumber));
//            TotalAmount = totalAmount ?? throw new ArgumentNullException(nameof(totalAmount));
//            TotalRate = totalRate ?? throw new ArgumentNullException(nameof(totalRate));
//        }

        /// <summary>
        /// Delete Call with the specified callUuid.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Call> Delete()
        {
            return ((CallInterface) Interface)
                .Delete(Id);
        }

        /// <summary>
        /// Transfer Call with the specified callUuid, legs, alegUrl, alegMethod, blegUrl and blegMethod.
        /// </summary>
        /// <returns>The transfer.</returns>
        /// <param name="legs">Legs.</param>
        /// <param name="alegUrl">Aleg URL.</param>
        /// <param name="alegMethod">Aleg method.</param>
        /// <param name="blegUrl">Bleg URL.</param>
        /// <param name="blegMethod">Bleg method.</param>
        public UpdateResponse<Call> Transfer(
            string legs = null, string alegUrl = null,
            string alegMethod = null, string blegUrl = null,
            string blegMethod = null)
        {
            return ((CallInterface) Interface)
                .Transfer(Id, legs, alegUrl, alegMethod, blegUrl, blegMethod);
        }

        /// <summary>
        /// Starts the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        /// <param name="urls">Urls.</param>
        /// <param name="length">Length.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public UpdateResponse<Call> StartPlaying(
            List<string> urls, uint? length = null,
            string legs = null, bool? loop = null, bool? mix = null)
        {
            return ((CallInterface) Interface)
                .StartPlaying(Id, urls, length, legs, loop, mix);
        }

        /// <summary>
        /// Stops the playing.
        /// </summary>
        /// <returns>The playing.</returns>
        public DeleteResponse<Call> StopPlaying()
        {
            return ((CallInterface) Interface)
                .StopPlaying(Id);
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="timeLimit">Time limit.</param>
        /// <param name="fileFormat">File format.</param>
        /// <param name="transactionType">Transaction type.</param>
        /// <param name="transactionUrl">Transaction URL.</param>
        /// <param name="transactionMethod">Transaction method.</param>
        /// <param name="callbackUrl">Callback URL.</param>
        /// <param name="callbackMethod">Callback method.</param>
        public RecordCreateResponse<Call> StartRecording(
            uint? timeLimit = null, string fileFormat = null,
            string transactionType = null, string transactionUrl = null,
            string transactionMethod = null, string callbackUrl = null,
            string callbackMethod = null)
        {
            return ((CallInterface) Interface)
                .StartRecording(
                    Id, timeLimit, fileFormat, transactionType, transactionUrl,
                    transactionMethod, callbackUrl, callbackMethod);
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        /// <returns>The recording.</returns>
        /// <param name="URL">URL.</param>
        public DeleteResponse<Call> StopRecording(string URL = null)
        {
            return ((CallInterface) Interface)
                .StopRecording(Id, URL);
        }

        /// <summary>
        /// Starts the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        /// <param name="text">Text.</param>
        /// <param name="voice">Voice.</param>
        /// <param name="language">Language.</param>
        /// <param name="legs">Legs.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="mix">Mix.</param>
        public UpdateResponse<Call> StartSpeaking(
            string text, string voice = null,
            string language = null, string legs = null, bool? loop = null,
            bool? mix = null)
        {
            return ((CallInterface) Interface)
                .StartSpeaking(
                    Id, text, voice, language, legs, loop, mix);
        }

        /// <summary>
        /// Stops the speaking.
        /// </summary>
        /// <returns>The speaking.</returns>
        public DeleteResponse<Call> StopSpeaking()
        {
            return ((CallInterface) Interface)
                .StopSpeaking(Id);
        }

        /// <summary>
        /// Sends the digits.
        /// </summary>
        /// <returns>The digits.</returns>
        /// <param name="digits">Digits.</param>
        /// <param name="leg">Leg.</param>
        public UpdateResponse<Call> SendDigits(
            string digits, string leg = null)
        {
            return ((CallInterface) Interface)
                .SendDigits(Id, digits, leg);
        }

        /// <summary>
        /// Cancels the call.
        /// </summary>
        /// <returns>The call.</returns>
        public DeleteResponse<Call> CancelCall()
        {
            return ((CallInterface) Interface)
                .CancelCall(Id);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Call.Call"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Call.Call"/>.</returns>
        public override string ToString()
        {
            return base.ToString() +
                   "AnswerTime: " + AnswerTime + "\n" +
                   "BillDuration: " + BillDuration + "\n" +
                   "BilledDuration: " + BilledDuration + "\n" +
                   "CallDirection: " + CallDirection + "\n" +
                   "CallDuration: " + CallDuration + "\n" +
                   "CallUuid: " + CallUuid + "\n" +
                   "EndTime: " + EndTime + "\n" +
                   "FromNumber: " + FromNumber + "\n" +
                   "InitiationTime: " + InitiationTime + "\n" +
                   "ParentCallUuid: " + ParentCallUuid + "\n" +
                   "PlivoHangupCauseCode: " + PlivoHangupCauseCode + "\n" +
                   "PlivoHangupCauseName: " + PlivoHangupCauseName + "\n" +
                   "PlivoHangupSource: " + PlivoHangupSource + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "ToNumber: " + ToNumber + "\n" +
                   "TotalAmount: " + TotalAmount + "\n" +
                   "TotalRate: " + TotalRate + "\n";
        }
    }
}