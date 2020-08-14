using System;
using System.Threading.Tasks;
using Plivo.Resource.PhoneNumber;
namespace Plivo.Resource.Powerpack {
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class Tollfree : Resource {
        private string numberpooluuid = "";
        public Tollfree (string number_pool_id) {
            numberpooluuid = number_pool_id;
        }
        public Tollfree () {

        }
        public new string Id => NumberPoolUuid;

        /// <summary>
        /// tollfree
        /// </summary>
        /// <value>The tollfree .</value>
        public string number { get; set; }

        /// <summary>
        /// Gets or sets AddedOn.
        /// </summary>
        /// <value>AddedOn.</value>
        public string AddedOn { get; set; }

        /// <summary>
        /// Gets or sets the created_on.
        /// </summary>
        /// <value>The created_on.</value>
        public string CountryIso2 { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        /// <value>The Type</value>
        public string Type { get; set; }

        /// <summary>
        /// account_phone_number_resource
        /// </summary>
        /// <value>The account_phone_number_resource .</value>
        public string AccountPhoneNumberResource { get; set; }

        /// <summary>
        /// Gets or sets the NumberPoolUUID.
        /// </summary>
        /// <value>The NumberPoolUUID.</value>
        public string NumberPoolUuid { get; set; }

        // public Tollfree Get(string memberId)
        // {
        //     var member = new Tollfree();
        //     return member;
        // }
        // public Tollfree(){

        // }

        public Lazy<PowerpackInterface> _powerpackInterface;

        private PowerpackInterface PowerpackI => _powerpackInterface.Value;
        public ListResponse<Tollfree> List (uint? limit = null, uint? offset = null) {
            return PowerpackI
                .ListTollfree (numberpooluuid, limit, offset);
        }
        public async Task<ListResponse<Tollfree>> ListAsync (uint? limit = null, uint? offset = null) {
            return await PowerpackI
                .List_TollfreeAsync (numberpooluuid, limit, offset);
        }

        public Tollfree Find (string tollfree) {
            return PowerpackI
                .Find_Tollfree (tollfree, numberpooluuid);
        }
        public async Task<Tollfree> FindAsync (
            string tollfree) {
            return await PowerpackI
                .Find_TollfreeAsync (tollfree, numberpooluuid);
        }
        public Tollfree Add (string tollfree) {
            return PowerpackI
                .Add_Tollfree (numberpooluuid, tollfree);
        }
        public async Task<Tollfree> AddAsync (string tollfree) {
            return await PowerpackI
                .Add_TollfreeAsync (numberpooluuid, tollfree);
        }

        public DeleteResponse<Tollfree> Remove (string tollfree, bool? unrent = null) {
            return PowerpackI
                .Remove_Tollfree (numberpooluuid, tollfree, unrent);
        }
        public async Task<DeleteResponse<Tollfree>> RemoveAsync (
            string tollfree, bool? unrent = null) {
            return await PowerpackI
                .Remove_TollfreeAsync (numberpooluuid, tollfree, unrent);
        }

        public override string ToString () {
            return "\n" +
                "NumberPoolUUID: " + NumberPoolUuid + "\n" +
                "Tollfree: " + number + "\n" +
                "CountryISO2: " + CountryIso2 + "\n" +
                "AddedOn: " + AddedOn + "\n" +
                "AccountPhoneNumberResource: " + AccountPhoneNumberResource + "\n" +
                "Type: " + Type + "\n" ;
        }
    }
}
