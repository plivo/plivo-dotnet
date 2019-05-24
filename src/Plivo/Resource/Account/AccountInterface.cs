using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
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
		#region Get
		/// <summary>
		/// Get the specified id.
		/// </summary>
		/// <returns>The get.</returns>
		public Account Get()
		{
			return ExecuteWithExceptionUnwrap(() =>
				{
					var account = Task.Run(async () => await GetResource<Account>("").ConfigureAwait(false)).Result;
					account.Interface = this;
					return account;
				});
		}
		/// <summary>
		/// Asynchronously get the specified id.
		/// </summary>
		/// <returns>The get.</returns>
		public async Task<Account> GetAsync()
		{
			var account = await GetResource<Account>("");
			account.Interface = this;
			return account;
		}
		#endregion

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
			var mandatoryParams = new List<string> { "name" };
			var data = CreateData(mandatoryParams, new { name, city, address });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Account>>(Uri, data).ConfigureAwait(false)).Result;
				return result.Object;
			});
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
			var mandatoryParams = new List<string> { "name" };
			var data = CreateData(
				mandatoryParams, new { name, city, address });
			var result = await Client.Update<UpdateResponse<Account>>(Uri, data);
			return result.Object;
		}
		#endregion
	}
}