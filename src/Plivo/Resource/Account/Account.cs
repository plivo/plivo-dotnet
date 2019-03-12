using System;
using System.Threading.Tasks;
using Plivo.Client;

namespace Plivo.Resource.Account
{
    /// <summary>
    /// Account.
    /// </summary>
    public class Account : Resource
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public new string Id => AuthId;

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>The type of the account.</value>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the auth identifier.
        /// </summary>
        /// <value>The auth identifier.</value>
        public string AuthId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:plivo.Resource.Account.Account"/> auto recharge.
        /// </summary>
        /// <value><c>true</c> if auto recharge; otherwise, <c>false</c>.</value>
        public bool AutoRecharge { get; set; }

        /// <summary>
        /// Gets or sets the billing mode.
        /// </summary>
        /// <value>The billing mode.</value>
        public string BillingMode { get; set; }

        /// <summary>
        /// Gets or sets the cash credits.
        /// </summary>
        /// <value>The cash credits.</value>
        public string CashCredits { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        /// <value>The resource URI.</value>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the timezone.
        /// </summary>
        /// <value>The timezone.</value>
        public string Timezone { get; set; }


        //        public Account(string accountType, string address, string authId, bool autoRecharge, string billingMode,
        //            string cashCredits, string city, string name, string resourceUri, string state, string timezone)
        //        {
        //            AccountType = accountType ?? throw new ArgumentNullException(nameof(accountType));
        //            Address = address ?? throw new ArgumentNullException(nameof(address));
        //            AuthId = authId ?? throw new ArgumentNullException(nameof(authId));
        //            AutoRecharge = autoRecharge;
        //            BillingMode = billingMode ?? throw new ArgumentNullException(nameof(billingMode));
        //            CashCredits = cashCredits ?? throw new ArgumentNullException(nameof(cashCredits));
        //            City = city ?? throw new ArgumentNullException(nameof(city));
        //            Name = name ?? throw new ArgumentNullException(nameof(name));
        //            ResourceUri = resourceUri ?? throw new ArgumentNullException(nameof(resourceUri));
        //            State = state ?? throw new ArgumentNullException(nameof(state));
        //            Timezone = timezone ?? throw new ArgumentNullException(nameof(timezone));
        //        }

        #region Update
        /// <summary>
        /// Update the specified name, city and address.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="city">City.</param>
        /// <param name="address">Address.</param>
        public UpdateResponse<Account> Update(string name = null, string city = null, string address = null)
        {
            var updateResponse = ((AccountInterface) Interface).Update(name, city, address);
            if (name != null) Name = name;
            if (city != null) City = city;
            if (address != null) Address = address;
            return updateResponse;
        }
        /// <summary>
        /// Asynchronously update the specified name, city and address.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="city">City.</param>
        /// <param name="address">Address.</param>
        public async Task<UpdateResponse<Account>> UpdateAsync(string name = null, string city = null, string address = null)
        {
            var updateResponse = await ((AccountInterface)Interface).UpdateAsync(name, city, address);
            if (name != null) Name = name;
            if (city != null) City = city;
            if (address != null) Address = address;
            return updateResponse;
        }
        #endregion
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Account.Account"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Account.Account"/>.</returns>
        public override string ToString()
        {
            return "Account Type: " + AccountType + "\n" +
                   "Address: " + Address + "\n" +
                   "AuthId: " + AuthId + "\n" +
                   "AutoRecharge: " + AutoRecharge + "\n" +
                   "BillingMode: " + BillingMode + "\n" +
                   "CashCredits: " + CashCredits + "\n" +
                   "City: " + City + "\n" +
                   "Name: " + Name + "\n" +
                   "ResourceUri: " + ResourceUri + "\n" +
                   "State: " + State + "\n" +
                   "Timezone: " + Timezone + "\n";
        }
    }
}