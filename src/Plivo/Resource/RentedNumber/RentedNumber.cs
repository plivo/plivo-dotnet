using System.Collections.Generic;

namespace Plivo.Resource.RentedNumber
{
    public class RentedNumber : Resource
    {
        public new string Id => Number;
        public string AddedOn { get; set; }
        public object Alias { get; set; }
        public string Application { get; set; }
        public string Carrier { get; set; }
        public string MonthlyRentalRate { get; set; }
        public string Number { get; set; }
        public string NumberType { get; set; }
        public string Region { get; set; }
        public string ResourceUri { get; set; }
        public bool SmsEnabled { get; set; }
        public string SmsRate { get; set; }
        public object SubAccount { get; set; }
        public bool VoiceEnabled { get; set; }
        public string VoiceRate { get; set; }
        public List<Prerequisite> Prerequisites { get; set; }
        public List<VerificationInfo> VerificationInfo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

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
        /// Unrent RentedNumber.
        /// </summary>
        /// <returns>The delete.</returns>
        public void Delete()
        {
            ((RentedNumberInterface) Interface)
                .Delete(Id);
        }
    }
}