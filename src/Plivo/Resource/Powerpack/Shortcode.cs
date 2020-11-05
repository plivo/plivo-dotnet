using System;
using System.Threading.Tasks;
using Plivo.Resource.PhoneNumber;
namespace Plivo.Resource.Powerpack {
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class Shortcode : Resource {
        private string numberpooluuid = "";
        public Shortcode (string number_pool_id) {
            numberpooluuid = number_pool_id;
        }
        public Shortcode () {

        }
        public new string Id => NumberPoolUuid;

        /// <summary>
        /// shortcode
        /// </summary>
        /// <value>The shortcode .</value>
        public string shortcode { get; set; }

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
        /// Gets or sets the NumberPoolUUID.
        /// </summary>
        /// <value>The NumberPoolUUID.</value>
        public string NumberPoolUuid { get; set; }

        // public Shortcode Get(string memberId)
        // {
        //     var member = new Shortcode();
        //     return member;
        // }
        // public Shortcode(){

        // }

        public Lazy<PowerpackInterface> _powerpackInterface;

        private PowerpackInterface PowerpackI => _powerpackInterface.Value;
        public ListResponse<Shortcode> List (uint? limit = null, uint? offset = null) {
            return PowerpackI
                .ListShortcode (numberpooluuid, limit, offset);
        }
        public async Task<ListResponse<Shortcode>> ListAsync (uint? limit = null, uint? offset = null) {
            return await PowerpackI
                .List_ShortcodeAsync (numberpooluuid, limit, offset);
        }

        public Shortcode Find (string shortcode) {
            return PowerpackI
                .Find_Shortcode (shortcode, numberpooluuid);
        }
        public async Task<Shortcode> FindAsync (
            string shortcode) {
            return await PowerpackI
                .Find_ShortcodeAsync (shortcode, numberpooluuid);
        }

        public DeleteResponse<Shortcode> Remove (string shortcode, bool? unrent = null) {
            return PowerpackI
                .Remove_Shortcode (numberpooluuid, shortcode, unrent);
        }
        public async Task<DeleteResponse<Shortcode>> RemoveAsync (
            string shortcode, bool? unrent = null) {
            return await PowerpackI
                .Remove_ShortcodeAsync (numberpooluuid, shortcode, unrent);
        }

        public override string ToString () {
            return "\n" +
                "NumberPoolUUID: " + NumberPoolUuid + "\n" +
                "Shortcode: " + shortcode + "\n" +
                "CountryISO2: " + CountryIso2 + "\n" +
                "AddedOn: " + AddedOn + "\n";
        }
    }
}
