using System;
// using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace Plivo.Resource.Subaccount
{
    public class Subaccount : Resource
    {
        public new string Id => AuthId;
        public string Account { get; set; }
        public string AuthId { get; set; }
        public string AuthToken { get; set; }
        public string NewAuthToken { get; set; }
        public string Created { get; set; }
        public bool? Enabled { get; set; }
        public string Modified { get; set; }
        public string Name { get; set; }
        public string ResourceUri { get; set; }

        #region Delete
        /// <summary>
        /// Delete Subaccount.
        /// </summary>
        /// <returns>The delete.</returns>
        public DeleteResponse<Subaccount> Delete()
        {
            return
                ((SubaccountInterface) Interface)
                .Delete(Id);
        }
        /// <summary>
        /// Asynchronously delete Subaccount.
        /// </summary>
        /// <returns>The delete.</returns>
        public async Task<DeleteResponse<Subaccount>> DeleteAsync()
        {
            return await
                ((SubaccountInterface)Interface)
                .DeleteAsync(Id);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Subaccount with the specified name and enabled.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public UpdateResponse<Subaccount> Update(string name, bool? enabled = null)
        {
            var updateResponse =
                ((SubaccountInterface) Interface)
                .Update(Id, name, enabled);

            if (enabled != null) Enabled = enabled;

            return updateResponse;
        }
        /// <summary>
        /// Asynchronously update Subaccount with the specified name and enabled.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="enabled">Enabled.</param>
        public async Task<UpdateResponse<Subaccount>> UpdateAsync(string name, bool? enabled = null)
        {
            var updateResponse = await
                ((SubaccountInterface)Interface)
                .UpdateAsync(Id, name, enabled);

            if (enabled != null) Enabled = enabled;

            return updateResponse;
        }
        #endregion

        public override string ToString()
        {
            return
                "Account: " + Account + "\n" +
                "AuthId: " + AuthId + "\n" +
                "AuthToken: " + AuthToken + "\n" +
                "NewAuthToken: " + NewAuthToken + "\n" +
                "Created: " + Created + "\n" +
                "Enabled: " + Enabled + "\n" +
                "Modified: " + Modified + "\n" +
                "Name: " + Name + "\n" +
                "ResourceUri: " + ResourceUri + "\n";
        }
    }
}