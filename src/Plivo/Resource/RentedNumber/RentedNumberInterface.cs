using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plivo.Client;


namespace Plivo.Resource.RentedNumber
{
    /// <summary>
    /// Rented number interface.
    /// </summary>
    public class RentedNumberInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.RentedNumber.RentedNumberInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public RentedNumberInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Number/";
        }

        /// <summary>
        /// Get RentedNumber with the specified number.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="number">Number.</param>
        public RentedNumber Get(string number)
        {
            var rentedNumber = GetResource<RentedNumber>(number);
            rentedNumber.Interface = this;
            return rentedNumber;
        }

        /// <summary>
        /// List RentedNumber with the specified type, numberStartswith, subaccount, alias, services, limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="type">Type.</param>
        /// <param name="numberStartswith">Number startswith.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        /// <param name="services">Services.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<RentedNumber> List(
            string type = null, string numberStartswith = null,
            string subaccount = null, string alias = null,
            string services = null, uint? limit = null, uint? offset = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new
                {
                    type, numberStartswith, subaccount, alias, services, limit,
                    offset
                });
            var resources = ListResources<ListResponse<RentedNumber>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }

        /// <summary>
        /// Adds the number.
        /// </summary>
        /// <returns>The number.</returns>
        /// <param name="numbers">Numbers.</param>
        /// <param name="carrier">Carrier.</param>
        /// <param name="region">Region.</param>
        /// <param name="numberType">Number type.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        public UpdateResponse<RentedNumber> AddNumber(
            List<string> numbers, string carrier, string region,
            string numberType = null, string appId = null,
            string subaccount = null)
        {
            string _numbers = string.Join(",", numbers);
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new
                {
                    _numbers, carrier, region, numberType, appId, subaccount
                });
            return Client.Update<UpdateResponse<RentedNumber>>(Uri, data).Object;
        }

        /// <summary>
        /// Update RentedNumber with the specified number, appId, subaccount and alias.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="number">Number.</param>
        /// <param name="appId">App identifier.</param>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="alias">Alias.</param>
        public UpdateResponse<RentedNumber> Update(
            string number, string appId = null, string subaccount = null,
            string alias = null)
        {
            var mandatory_params = new List<string> { "" };var data = CreateData(
                mandatory_params,
                new
                {
                    appId, subaccount, alias
                });
            if (appId == "null") data["app_id"] = null;
            return 
                Client.Update<UpdateResponse<RentedNumber>>(
                    Uri + number + "/", 
                    data
                ).Object;
        }

        /// <summary>
        /// Unrent RentedNumber with the specified number.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="number">Number.</param>
        public void Delete(string number)
        {
            DeleteResource<object>(number);
        }
    }
}
