using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;
using Plivo.Resource.PhoneNumber ;


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
        /// <param name="number_priority">NumberPriority</param>
        public Powerpack Create(
            string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null)
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
                local_connect,
                number_priority
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
        /// <param name="number_priority">NumberPriority.<param>
		public async Task<Powerpack> CreateAsync(
			string name, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null)
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
                local_connect,
                number_priority
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
                powerpack.number_pool_id = powerpack.number_pool.Split('/')[5];
                powerpack._phonenumber = new Lazy<PhoneNumberInterface>(() => new PhoneNumberInterface(Client));
                powerpack.numberpool = new NumberPool(powerpack.number_pool_id, Client);
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
            powerpack.number_pool_id = powerpack.number_pool.Split('/')[5];
            return powerpack;
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete Powerpack with the specified uuid.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="uuid">powerpack identifier.</param>
        public DeleteResponse<Powerpack> Delete(string uuid,  bool? unrent_numbers = false )
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
        public async Task<DeleteResponse<Powerpack>> DeleteAsync(string uuid, bool? unrent_numbers = false)
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
                resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
                resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;

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
            resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
            resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
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
        /// <param name="number_priority">NumberPriority.</param>
        public UpdateResponse<Powerpack> Update(string uuid, string name=null, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null)
		{
			var mandatoryParams = new List<string> { "uuid" };
			var data = CreateData(mandatoryParams, new { name,
                application_type,
                application_id,
                sticky_sender,
                local_connect,
                number_priority
            });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var result = Task.Run(async () => await Client.Update<UpdateResponse<Powerpack>>(Uri +"Powerpack/"+uuid+"/", data).ConfigureAwait(false)).Result;
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
        /// <param name="number_priority">NumberPriority.</param>

        public async Task<UpdateResponse<Powerpack>> UpdateAsync(string uuid, string name=null, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null)
		{
			var mandatoryParams = new List<string> { "uuid" };
			var data = CreateData(
				mandatoryParams, new { name,
                application_type,
                application_id,
                sticky_sender,
                local_connect,
                number_priority
            });
			var result = await Client.Update<UpdateResponse<Powerpack>>(Uri +"Powerpack/"+uuid, data);

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
        public ListResponse<Numbers> List_Numbers(string uuid, string starts_with =null, string country_iso2 =null,
        string type=null, uint? limit = null, uint? offset = null, string service = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset,
                    service
                });

			return ExecuteWithExceptionUnwrap(() =>
			{
				var resources = Task.Run(async () => await ListResources<ListResponse<Numbers>>("NumberPool/"+uuid+"/Number", data).ConfigureAwait(false)).Result;
				resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
                resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
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
         public async Task<ListResponse<Numbers>> List_NumbersAsync(
          string uuid, string starts_with =null, string country_iso2 =null,
          string type=null, uint? limit = null, uint? offset = null, string service = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset,
                    service
                });
            var resources = await ListResources<ListResponse<Numbers>>("NumberPool/"+uuid+"/Number", data);
            resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
            resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );
            return resources;
        }
      
       public string Hello(){
           return "Hi";
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
        public uint  Count_Number(string uuid, string starts_with =null, string country_iso2 =null,
        string type=null, uint? limit = null, uint? offset = null, string service = null)
        {
            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset,
                    service
                });

			// return ExecuteWithExceptionUnwrap(() =>
			// {
				var resources = Task.Run(async () => await ListResources<ListResponse<Numbers>>("NumberPool/"+uuid+"/Number", data).ConfigureAwait(false)).Result;
				resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);
                // return zero when no meta
                if (resources.Meta is null) {
                    return 0;
                }
                return resources.Meta.TotalCount; // Need to check
			// });

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
         public async Task<uint> Count_NumbersAsync(
          string uuid, string starts_with =null, string country_iso2 =null,
          string type=null, uint? limit = null, uint? offset = null, string service = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    starts_with,
                    country_iso2,
                    type,
                    limit,
                    offset,
                    service
                });
            var resources = await ListResources<ListResponse<Numbers>>("NumberPool/"+uuid+"/Number", data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            if (resources.Meta is null) {
                    return 0;
            }

            return resources.Meta.TotalCount;


        }
       #endregion
       #region ADDNUMBER
       /// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>

        public Numbers Add_Number( string uuid, string number, string service = null, bool rent=false)
        { 
        var mandatoryParams = new List<string>{""};
           var data= CreateData(
            mandatoryParams,
            new
            {
                rent,
                service
            }); 
        
    
        
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<Numbers>(Uri + "NumberPool/"+uuid.ToString()+"/Number/"+number.ToString()+"/", data).ConfigureAwait(false)).Result;
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
		public async Task<Numbers> Add_NumberAsync(
			 string uuid, string number, string service = null, bool rent=false)
		{
        var mandatoryParams = new List<string>{""};
                var data = CreateData(
                mandatoryParams,
                new
                {
                    rent,
                    service
                });
           
		var result = await Client.Update<Numbers>(Uri + "NumberPool/"+uuid+"/Number/"+number+"/", data);
        result.Object.StatusCode = result.StatusCode;
		return result.Object;
		}
       #endregion
        
        #region ADDTOLLFREE
       /// <summary>
        /// Add a tollfree
        /// </summary>
        /// <returns>The Tollfree resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="tollfree">Tollfree.</param>

        public Tollfree Add_Tollfree( string uuid, string tollfree, bool rent=false )
        { 
        var mandatoryParams = new List<string>{""};
           var data= CreateData(
            mandatoryParams,
            new
            {
                rent
            }); 
        
    
        
		return ExecuteWithExceptionUnwrap(() =>
		{
				var result = Task.Run(async () => await Client.Update<Tollfree>(Uri + "NumberPool/"+uuid.ToString()+"/Tollfree/"+tollfree.ToString()+"/", data).ConfigureAwait(false)).Result;
				result.Object.StatusCode = result.StatusCode;
                return result.Object;
		});
        }

		/// <summary>
        /// Add a tollfree
        /// </summary>
        /// <returns>The Tollfree resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="tollfree">Tollfree.</param>
		public async Task<Tollfree> Add_TollfreeAsync(
			 string uuid, string tollfree, bool rent=false)
		{
        var mandatoryParams = new List<string>{""};
                var data = CreateData(
                mandatoryParams,
                new
                {
                    rent
                });
           
		var result = await Client.Update<Tollfree>(Uri + "NumberPool/"+uuid+"/Tollfree/"+tollfree+"/", data);
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
        public DeleteResponse<Numbers> Remove_Number(string uuid, string number, bool? unrent=null)
        { 
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Numbers>>("NumberPool/"+uuid+"/Number/"+number, data).ConfigureAwait(false)).Result;
		});
        }

		/// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
		public async Task<DeleteResponse<Numbers>> Remove_NumberAsync(
            string uuid, string number,  bool? unrent=null)
		{
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return await DeleteResource<DeleteResponse<Numbers>>("NumberPool/"+uuid+"/Number/"+number, data);
		}
       #endregion
       #region REMOVETOLLFREE
       /// <summary>
        /// Remove a tollfree
        /// </summary>
        /// <returns>The Tollfree resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="tollfree">Tollfree.</param>
        public DeleteResponse<Tollfree> Remove_Tollfree(string uuid, string tollfree, bool? unrent=null)
        { 
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Tollfree>>("NumberPool/"+uuid+"/Tollfree/"+tollfree, data).ConfigureAwait(false)).Result;
		});
        }

		/// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="tollfree">Tollfree.</param>
		public async Task<DeleteResponse<Tollfree>> Remove_TollfreeAsync(
            string uuid, string tollfree,  bool? unrent=null)
		{
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return await DeleteResource<DeleteResponse<Tollfree>>("NumberPool/"+uuid+"/Tollfree/"+tollfree, data);
		}
       #endregion
       #region FINDNUMBER

       /// <summary>
        /// Find a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="number">Number.</param>
        /// <param name="service">Service.</param>
        public Numbers Find_Number(string uuid,string number, string service = null)
        { 
            var mandatoryParams = new List<string>{""};
            var data= CreateData(
            mandatoryParams,
            new
            {
                service
            }); 

            return ExecuteWithExceptionUnwrap(() =>
			{
				var numberpoolResponse = Task.Run(async () => await GetResource<Numbers>("NumberPool/"+uuid+"/Number/"+number, data).ConfigureAwait(false)).Result;
				numberpoolResponse.Interface = this;
				return numberpoolResponse;
			});
        }
        public async Task<Numbers> Find_NumberAsync(string uuid,
			string number, string service = null)
		{
        var mandatoryParams = new List<string>{""};
        var data= CreateData(
        mandatoryParams,
        new
        {
            service
        }); 
        var numberpoolresp = await GetResource<Numbers>("NumberPool/"+uuid+"/Number/"+number, data);
        numberpoolresp.Interface = this;
        return numberpoolresp;

        }
    #endregion
       #region LISTSHORTCODE
       /// <summary>
        /// Find a number
        /// </summary>
        /// <returns>The Number resource.</returns>
         public ListResponse<Shortcode> ListShortcode(string uuid, uint? limit = null, uint? offset = null)
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
				var resources = Task.Run(async () => await ListResources<ListResponse<Shortcode>>("NumberPool/"+uuid+"/Shortcode", data).ConfigureAwait(false)).Result;
				resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
                resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
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
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Shortcode>>("NumberPool/"+uuid+"/Shortcode", data);
            resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
            resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
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
            return ExecuteWithExceptionUnwrap(() =>
			{
				var powerpackresp = Task.Run(async () => await GetResource<Shortcode>("NumberPool/"+uuid+"/Shortcode/"+shortcode).ConfigureAwait(false)).Result;
				powerpackresp.Interface = this;
				return powerpackresp;
			});
        }
        public async Task<Shortcode> Find_ShortcodeAsync(
			string shortcode, string uuid)
		{
        var shortcodeResponse = await GetResource<Shortcode>("NumberPool/"+uuid+"/Shortcode/"+shortcode);
        shortcodeResponse.Interface = this;
        return shortcodeResponse;

        }

       #endregion
        
        #region REMOVESHORTCODE
       /// <summary>
        /// Remove a shortcode
        /// </summary>
        /// <returns>The Shortcode resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="shortcode">Shortcode.</param>
        public DeleteResponse<Shortcode> Remove_Shortcode(string uuid, string shortcode, bool? unrent=null)
        { 
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return ExecuteWithExceptionUnwrap(() =>
		{
				return Task.Run(async () => await DeleteResource<DeleteResponse<Shortcode>>("NumberPool/"+uuid+"/Shortcode/"+shortcode, data).ConfigureAwait(false)).Result;
		});
        }

		/// <summary>
        /// Add a number
        /// </summary>
        /// <returns>The Number resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="shortcode">Shortcode.</param>
		public async Task<DeleteResponse<Shortcode>> Remove_ShortcodeAsync(
            string uuid, string shortcode,  bool? unrent=null)
		{
        var mandatoryParams = new List<string>{""};
        var data = CreateData(
            mandatoryParams,
            new
            {
                unrent,
            });
		return await DeleteResource<DeleteResponse<Shortcode>>("NumberPool/"+uuid+"/Shortcode/"+shortcode, data);
		}
       #endregion

       #region LISTTOLLFREE
       /// <summary>
        /// Find a number
        /// </summary>
        /// <returns>The Number resource.</returns>
         public ListResponse<Tollfree> ListTollfree(string uuid, uint? limit = null, uint? offset = null)
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
				var resources = Task.Run(async () => await ListResources<ListResponse<Tollfree>>("NumberPool/"+uuid+"/Tollfree", data).ConfigureAwait(false)).Result;
				resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
                resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
                resources.Objects.ForEach(
					(obj) => obj.Interface = this
				);

				return resources;
			});

        }

        /// <summary>
        /// List Powerpack Tollfree limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param uuid="uuid">UUID</param>
        /// <param name="offset">Offset.</param>
         public async Task<ListResponse<Tollfree>> List_TollfreeAsync(
          string uuid,  uint? limit = null, uint? offset = null)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Tollfree>>("NumberPool/"+uuid+"/Tollfree", data);
            resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
            resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;


        }

        #endregion

        #region FINDTOLLFREE

       /// <summary>
        /// Find a tollfree
        /// </summary>
        /// <returns>The Tikkfree resource.</returns>
        /// <param name="uuid">UUID.</param>
        /// <param name="tollfree">Tollfree.</param>
        public Tollfree Find_Tollfree(string tollfree, string uuid)
        { 
            return ExecuteWithExceptionUnwrap(() =>
			{
				var powerpackresp = Task.Run(async () => await GetResource<Tollfree>("NumberPool/"+uuid+"/Tollfree/"+tollfree).ConfigureAwait(false)).Result;
				powerpackresp.Interface = this;
				return powerpackresp;
			});
        }
        public async Task<Tollfree> Find_TollfreeAsync(
			string tollfree, string uuid)
		{
        var tollfreeResponse = await GetResource<Tollfree>("NumberPool/"+uuid+"/Tollfree/"+tollfree);
        tollfreeResponse.Interface = this;
        return tollfreeResponse;

        }

       #endregion
 }

}
