using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;


namespace Plivo.Resource.Powerpack
{

     /// <summary>
    /// Powerpack interface.
    /// </summary>
    public class PowerpackInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Powerpack.PowerpackInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public PowerpackInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/";
        }
        #region Create
        /// <summary>
        /// Create Message with the specified src, dst, text, type, url, method and log.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="sticky_sender">StickySender.</param>
        /// <param name="local_connect">LocalConnect.</param>
        /// <param name="application_type">ApplicationType.</param>
        /// <param name="application_id">ApplicationID.</param>
        public Powerpack Create(
            string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null)
        {
        var mandatoryParams = new List<string>{"name"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                name,
                application_type,
                application_id,
                sticky_sender,
                local_connect
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<Powerpack>(Uri + "Powerpack/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		 /// <summary>
        /// Create Message with the specified src, dst, text, type, url, method and log.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="sticky_sender">StickySender.</param>
        /// <param name="local_connect">LocalConnect.</param>
        /// <param name="application_type">ApplicationType.</param>
        /// <param name="application_id">ApplicationID.</param>
		public async Task<Powerpack> CreateAsync(
			string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null)
		{

			var mandatoryParams = new List<string>{"name"};
        var data = CreateData(
            mandatoryParams,
            new
            {
                name,
                application_type,
                application_id,
                sticky_sender,
                local_connect
            });

			var result = await Client.Update<Powerpack>(Uri + "Powerpack/", data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion
        #region GET
         /// <summary>
        /// Get Powerpack with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="uuid">Powerpack  UUID.</param>
        public Powerpack Get(string uuid)
        {
			return ExecuteWithExceptionUnwrap(() =>
			{
				var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
				powerpack.Interface = this;
				return powerpack;
			});
        }
        /// <summary>
        /// Asynchronously get Powerpack with the specified uuid.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="uuid"> UUID.</param>
        public async Task<Powerpack> GetAsync(string uuid)
        {
            var powerpack = await GetResource<Powerpack>("Powerpack/"+uuid);
            powerpack.Interface = this;
            return powerpack;
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete Powerpack with the specified uuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">powerpack identifier.</param>
        public DeleteResponse<Powerpack> Delete(string uuid,  bool? unrent_numbers = null )
        {
            var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent_numbers,
            });

			return ExecuteWithExceptionUnwrap(() =>
			{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Powerpack>>("Powerpack/"+uuid, data).ConfigureAwait(false)).Result;
			});
        }

        /// <summary>
        /// Asynchronously delete Powerpack with the specified uuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">Powerpack identifier.</param>
        public async Task<DeleteResponse<Powerpack>> DeleteAsync(string uuid, bool? unrent_numbers = null)
        {
            var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent_numbers,
            });
            return await DeleteResource<DeleteResponse<Powerpack>>("Powerpack/"+uuid, data);
        }
        #endregion
       #region List
        /// <summary>
        /// <summary>
        /// List Powerpack list limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Powerpack> List(
            uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Powerpack>>("Powerpack",data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});
        }
        /// <summary>
        /// List Powerpack list limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Powerpack>> ListAsync(
           uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Powerpack>>("Powerpack", data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
       #region Update
        /// <summary>
        /// Update the specified name, city, address and state.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="name">Name.</param>
        /// <param name="sticky_sender">StickySender.</param>
        /// <param name="local_connect">LocalConnect.</param>
        /// <param name="application_type">ApplicationType.</param>
        /// <param name="application_id">ApplicationID.</param>
        ///<param name="uuid">UUID.</param>
        public UpdateResponse<Account> Update(string uuid, string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null)
		{
			var mandatoryParams = new List<string> { "uuid" };
			var data = CreateData(mandatoryParams, new { name,
                application_type,
                application_id,
                sticky_sender,
                local_connect });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Account>>(Uri, data).ConfigureAwait(false)).Result;
                result.Object.StatusCode = result.StatusCode;
				return result.Object;
			});
		}
          /// <summary>
        /// Update the specified name, sticky_sender, localconnect.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="name">Name.</param>
        /// <param name="sticky_sender">StickySender.</param>
        /// <param name="local_connect">LocalConnect.</param>
        /// <param name="application_type">ApplicationType.</param>
        /// <param name="application_id">ApplicationID.</param>
        ///<param name="uuid">UUID.</param>

        public async Task<UpdateResponse<Account>> UpdateAsync(string uuid, string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null)
		{
			var mandatoryParams = new List<string> { "uuid" };
			var data = CreateData(
				mandatoryParams, new { name,
                application_type,
                application_id,
                sticky_sender,
                local_connect });
			var result = await Client.Update<UpdateResponse<Account>>(Uri +"Powerpack/"+uuid, data);
            result.Object.StatusCode = result.StatusCode;
			return result.Object;
		}
		#endregion
       #region ListNumber
        /// <summary>
        /// List Powerpack Number limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="starts_with">StartWith.</param>
        /// <param name="country_iso2">Countryiso2.</param>
        /// <param name="type">Type.</param>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<NumberPool> List_Number(string uuid, string starts_with =null, string country_iso2 =null,
        string type=null, uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<NumberPool>>("NumberPool/"+numberpool_uuid, data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});

        }

        /// <summary>
        /// List Powerpack Number limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="starts_with">StartWith.</param>
        /// <param name="country_iso2">Countryiso2.</param>
        /// <param name="type">Type.</param>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
         public async Task<ListResponse<NumberPool>> List_NumberAsync(
          string uuid, string starts_with =null, string country_iso2 =null,
          string type=null, uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<NumberPool>>("NumberPool/"+numberpool_uuid, data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;


        }
      
       
       
       #endregion
       #region GETNUMBERCOUNT
       /// <summary>
        /// List Powerpack Number limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="starts_with">StartWith.</param>
        /// <param name="country_iso2">Countryiso2.</param>
        /// <param name="type">Type.</param>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
        public Int64 Count_Number(string uuid, string starts_with =null, string country_iso2 =null,
        string type=null, uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<NumberPool>>("NumberPool/"+numberpool_uuid, data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources.Meta.total_count; // Need to check
			});

        }

        /// <summary>
        /// List Powerpack Number limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="starts_with">StartWith.</param>
        /// <param name="country_iso2">Countryiso2.</param>
        /// <param name="type">Type.</param>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
         public async Task<Int64> Count_NumberAsync(
          string uuid, string starts_with =null, string country_iso2 =null,
          string type=null, uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<NumberPool>>("NumberPool/"+numberpool_uuid, data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources.Meta.total_count;


        }
       #endregion
       #region ADDNUMBER
       /// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>

        public NumberPool Add_Number(string number, string uuid )
        { 
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<NumberPool>(Uri + "NumberPool/"+numberpool_uuid+"/Number/"+number, "").ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		/// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
		public async Task<NumberPool> Add_NumberAsync(
			string number, string uuid)
		{

        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
		var result = await Client.Update<NumberPool>(Uri + "NumberPool/"+numberpool_uuid+"/Number/"+number, data);
        result.Object.StatusCode = result.StatusCode;
		return result.Object;
		}
       #endregion
       #region REMOVENUMBER
       /// <summary>
        /// Remove a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
        public NumberPool Remove_Number(string number, string uuid, bool? unrent=null)
        { 
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
       
		return ExecuteWithExceptionUnwrap(() =>
		{
				return Task.Run(async () => await DeleteResource<DeleteResponse<NumberPool>>("NumberPool/"+numberpool_uuid+"/Number/"+number, data).ConfigureAwait(false)).Result;
		});
        }

		/// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
		public async Task<NUmberPool> Remove_NumberAsync(
			string number, string uuid, bool? unrent=null)
		{
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });

        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
		return await DeleteResource<DeleteResponse<NumberPool>>("NumberPool/"+numberpool_uuid+"/Number/"+number, data);
		}
       #endregion
       #region FINDNUMBER

       /// <summary>
        /// Find a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
        public NumberPool Find_Number(string number, string uuid)
        { 
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
            return ExecuteWithExceptionUnwrap(() =>
			{
				var powerpack = Task.Run(async () => await GetResource<NumberPool>("NumberPool/"+numberpool_uuid+"/Number/"+number).ConfigureAwait(false)).Result;
				powerpack.Interface = this;
				return powerpack;
			});
        }
        public async Task<NumberPool> Find_NumberAsync(
			string number, string uuid)
		{
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
        var numberpool = await GetResource<NumberPool>("NumberPool/"+numberpool_uuid+"/Number/"+number);
        numberpool.Interface = this;
        return numberpool;

        }
    #endregion
       #region LISTSHORTCODE
       /// <summary>
        /// Find a number
        /// </summary>
        /// <returns>The Number resource.</returns>
         public ListResponse<Shortcode> List_Shortcode(string uuid, uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Shortcode>>("NumberPool/"+numberpool_uuid+"/Shortcode", data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});

        }

        /// <summary>
        /// List Powerpack Shortcode limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
         public async Task<ListResponse<Shortcode>> List_ShortcodeAsync(
          string uuid,  uint? limit = null, uint? offset = null)
        {
            var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
			powerpack.Interface = this;
			string[] numberpool = powerpack.NumberPool.Split("/");
            numberpool_uuid = numberpool[5];
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Shortcode>>("NumberPool/"+numberpool_uuid+"/Shortcode", data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;


        }

        #endregion
       #region FINDSHORTCODE

       /// <summary>
        /// Find a shortcode
        /// </summary>
        /// <returns>The Shortcode resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="shortcode">Shortcode.</param>
        public Shortcode Find_Shortcode(string shortcode, string uuid)
        { 
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
            return ExecuteWithExceptionUnwrap(() =>
			{
				var powerpack = Task.Run(async () => await GetResource<Shortcode>("NumberPool/"+numberpool_uuid+"/Shortcode/"+shortcode).ConfigureAwait(false)).Result;
				powerpack.Interface = this;
				return powerpack;
			});
        }
        public async Task<Shortcode> Find_ShortcodeAsync(
			string shortcode, string uuid)
		{
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
        var numberpool = await GetResource<Shortcode>("NumberPool/"+numberpool_uuid+"/Shortcode/"+shortcode);
        numberpool.Interface = this;
        return numberpool;

        }

       #endregion
       #region BUYANDADDNUMBER
       /// <summary>
        /// search and buy number
        /// </summary>
        /// <returns>The add number to powerpack.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
         /// <param name="Country_iso2">Country_iso2.</param>
            /// <param name="Type">Type.</param>
            /// <param name="Region">Region.</param>

            /// <param name="Pattern">Pattern.</param>
public NumberPool Buy_Add_Number(string number=null, string uuid, string type=null, string country_iso2=null, string region=null, string pattern=null)
        { 
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
        if (number == null){

            phonenumber = PhoneNumber.List(countryIso=country_iso2, type=type,pattern=pattern, region= region);
            number = phonenumber[0].Number;

        }
        return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<NumberPool>(Uri + "NumberPool/"+numberpool_uuid+"/Number/"+number, "").ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
			});
        }
        public async Task<NumberPool> Buy_Add_NumberAsync(
			string number=null, string uuid, string type=null, string country_iso2=null, string region=null, string pattern=null)
		{
        var powerpack = Task.Run(async () => await GetResource<Powerpack>("Powerpack/"+uuid).ConfigureAwait(false)).Result;
		powerpack.Interface = this;
		string[] numberpool = powerpack.NumberPool.Split("/");
        numberpool_uuid = numberpool[5];
        if (number == null){

            phonenumber = PhoneNumber.List(countryIso=country_iso2, type=type,pattern=pattern, region= region);
            number = phonenumber[0].Number;

        }
        var result = await Client.Update<NumberPool>(Uri + "NumberPool/"+numberpool_uuid+"/Number/"+number, data);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
    //   return Client.Update<NumberPool>(Uri + "NumberPool/"+numberpool_uuid+"/Number/"+number, "").ConfigureAwait(false)).Result;
        }
       #endregion
    }

}