using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plivo.Resource.RentedNumber
{
    public class RentedNumber : Resource
    {
        public new string Id => Number;
        public bool Active { get; set; }
        public string AddedOn { get; set; }
        public object Alias { get; set; }
        public string Application { get; set; }
        public string Carrier { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool MmsEnabled { get; set; }
        public string MmsRate { get; set; }
        public string MonthlyRentalRate { get; set; }
        public string Number { get; set; }
        public string NumberType { get; set; }
        public string Region { get; set; }
        public string ResourceUri { get; set; }
        public bool SmsEnabled { get; set; }
        public string SmsRate { get; set; }
        public object SubAccount { get; set; }
        public string Type { get; set; }
        public List<VerificationInfo> VerificationInfo { get; set; }
        public bool VoiceEnabled { get; set; }
        public string VoiceRate { get; set; }

        public string ComplianceApplicationId {get; set;}
        public string ComplianceStatus {get; set;}
        public string TendlcCampaignId {get; set;}
        public string TendlcRegistrationStatus {get; set;}
        public string TollFreeSmsVerification {get; set;}
        public string RenewalDate {get; set;}
        
        public override string ToString()
        {
            if (string.Compare(Carrier, "Plivo", StringComparison.Ordinal) == 0)
            {
                return
                    "Active: " + Active + "\n" +
                    "AddedOn: " + AddedOn + "\n" +
                    "Alias: " + Alias + "\n" +
                    "Application: " + Application + "\n" +
                    "Carrier: " + Carrier + "\n" +
                    "City: " + City + "\n" +
                    "Country: " + Country + "\n" +
                    "MmsEnabled: " + MmsEnabled + "\n" +
                    "MmsRate: " + MmsRate + "\n" +
                    "MonthlyRentalRate: " + MonthlyRentalRate + "\n" +
                    "Number: " + Number + "\n" +
                    "NumberType: " + NumberType + "\n" +
                    "Region: " + Region + "\n" +
                    "RenewalDate: " + RenewalDate + "\n" +
                    "ResourceUri: " + ResourceUri + "\n" +
                    "SmsEnabled: " + SmsEnabled + "\n" +
                    "SmsRate: " + SmsRate + "\n" +
                    "SubAccount: " + SubAccount + "\n" +
                    "Type: " + Type + "\n" +
                    "VerificationInfo: " + VerificationInfo.ToString() + "\n" +
                    "VoiceEnabled: " + VoiceEnabled + "\n" +
                    "ComplianceApplicationId: " + ComplianceApplicationId + "\n" +
                    "ComplianceStatus: " + ComplianceStatus + "\n" +
                    "TendlcCampaignId: " + TendlcCampaignId + "\n" +
                    "TendlcRegistrationStatus: " + TendlcRegistrationStatus + "\n" +
                    "TollFreeSMSVerification: " + TollFreeSmsVerification + "\n" +
                    "VoiceRate: " + VoiceRate + "\n";
            }
            return
                "Active: " + Active + "\n" +
                "AddedOn: " + AddedOn + "\n" +
                "Alias: " + Alias + "\n" +
                "Application: " + Application + "\n" +
                "Carrier: " + Carrier + "\n" +
                "MonthlyRentalRate: " + MonthlyRentalRate + "\n" +
                "Number: " + Number + "\n" +
                "NumberType: " + NumberType + "\n" +
                "Region: " + Region + "\n" +
                "RenewalDate: " + RenewalDate + "\n" +
                "ResourceUri: " + ResourceUri + "\n" +
                "SmsEnabled: " + SmsEnabled + "\n" +
                "SmsRate: " + SmsRate + "\n" +
                "SubAccount: " + SubAccount + "\n" +
                "Type: " + Type + "\n" +
                "VoiceEnabled: " + VoiceEnabled + "\n" +
                "TendlcCampaignId: " + TendlcCampaignId + "\n" +
                "TendlcRegistrationStatus: " + TendlcRegistrationStatus + "\n" +
                "TollFreeSMSVerification: " + TollFreeSmsVerification + "\n" +
                "VoiceRate: " + VoiceRate + "\n";
        }

        #region Update

        /// <summary>
        /// Update RentedNumber with the specified appId, subAccount and alias.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="subAccount">SubAccount.</param>
        /// <param name="alias">Alias.</param>
        public UpdateResponse<RentedNumber> Update(
            string appId = null, string subAccount = null, string alias = null)
        {
            var updateResponse =
                ((RentedNumberInterface) Interface)
                .Update(Id, appId, subAccount, alias);

            if (appId != null)
                Application =
                    "/v1/Account/" +
                    ((RentedNumberInterface) Interface).Client.GetAuthId() +
                    "/Application/" +
                    appId +
                    "/";
            if (appId == "null") Application = null;
            if (subAccount != null) SubAccount = subAccount;
            if (alias != null) Alias = alias;

            return updateResponse;
        }

        /// <summary>
        /// Update RentedNumber with the specified appId, subAccount and alias.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="subAccount">SubAccount.</param>
        /// <param name="alias">Alias.</param>
        public async Task<UpdateResponse<RentedNumber>> UpdateAsync(
            string appId = null, string subAccount = null, string alias = null)
        {
            var updateResponse = await ((RentedNumberInterface) Interface)
                .UpdateAsync(Id, appId, subAccount, alias);

            if (appId != null)
                Application =
                    "/v1/Account/" +
                    ((RentedNumberInterface) Interface).Client.GetAuthId() +
                    "/Application/" +
                    appId +
                    "/";
            if (appId == "null") Application = null;
            if (subAccount != null) SubAccount = subAccount;
            if (alias != null) Alias = alias;

            return updateResponse;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Unrent RentedNumber.
        /// </summary>
        /// <returns>The delete.</returns>
        public void Delete()
        {
            ((RentedNumberInterface) Interface)
                .Delete(Id);
        }

        /// <summary>
        /// Asynchronously unrent RentedNumber.
        /// </summary>
        /// <returns>The delete.</returns>
        public async void DeleteAsync()
        {
            await ((RentedNumberInterface) Interface)
                .DeleteAsync(Id);
        }

        #endregion
    }
}