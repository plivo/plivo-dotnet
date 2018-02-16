using System;
using System.Collections.Generic;
using System.Reflection;
using Plivo.Client;
using Plivo.Exception;

namespace Plivo.Resource.Account
{
    /// <summary>
    /// Account interface.
    /// </summary>
    public class AccountInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Account.AccountInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public AccountInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/";
        }

        /// <summary>
        /// Get the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        public Account Get()
        {
            var account = GetResource<Account>("");
            account.Interface = this;
            return account;
        }

        /// <summary>
        /// Update the specified name, city and address.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="city">City.</param>
        /// <param name="address">Address.</param>
        public UpdateResponse<Account> Update(string name = null, string city = null, string address = null)
        {
            var mandatoryParams = new List<string> {"name"};
            var data = CreateData(
                mandatoryParams, new {name, city, address});
            return Client.Update<UpdateResponse<Account>>(Uri, data).Object;
        }
    }
}