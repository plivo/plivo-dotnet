using System;
using System.Threading.Tasks;
using Plivo.Resource.PhoneNumber;
using System.Collections.Generic;
namespace Plivo.Resource.Powerpack {
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class Powerpack : Resource {
        public new string Id => uuid;
        public string number_pool_id { get; set; }

        public Lazy<PhoneNumberInterface> _phonenumber;
        private PhoneNumberInterface PhoneNumberI => _phonenumber.Value;

        public NumberPool numberpool;
        /// <summary>
        /// Applicatio ID
        /// </summary>
        /// <value>The application_id .</value>
        public string application_id { get; set; }

        /// <summary>
        /// Gets or sets application type.
        /// </summary>
        /// <value>Application_type.</value>
        public string application_type { get; set; }

        /// <summary>
        /// Gets or sets the created_on.
        /// </summary>
        /// <value>The created_on.</value>
        public string created_on { get; set; }

        /// <summary>
        /// Gets or sets  the LocalConnect.
        /// </summary>
        /// <value>The LocalConnect.</value>
        public bool local_connect { get; set; }

        /// <summary>
        /// Gets or sets the sticky_sender.
        /// </summary>
        /// <value>The sticky_sender.</value>
        public bool sticky_sender { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        /// <value>The powerpack name.</value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets  UUID.
        /// </summary>
        /// <value>The uuid.</value>
        public string uuid { get; set; }

        /// <summary>
        /// Number Priority
        /// </summary>
        /// <value>The number_priority .</value>
        public List<NumberPriority> number_priority { get; set; }

        /// <summary>
        /// Gets or sets the number_pool.
        /// </summary>
        /// <value>The number_pool.</value>
        public string number_pool { get; set; }
        public Powerpack () { }
        public DeleteResponse<Powerpack> Delete (bool? unrent_numbers = false) {
            return ((PowerpackInterface) Interface)
                .Delete (Id, unrent_numbers);
        }

        public async Task<DeleteResponse<Powerpack>> DeleteAsync (bool? unrent_numbers = false) {
            return await ((PowerpackInterface) Interface)
                .DeleteAsync (Id, unrent_numbers);
        }

        public UpdateResponse<Powerpack> Update (string name = null, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null) {
            return ((PowerpackInterface) Interface)
                .Update (Id, name, application_type, application_id, sticky_sender, local_connect, number_priority);
        }
        public async Task<UpdateResponse<Powerpack>> UpdateAsync (string name = null, string application_type = null, string application_id = null,
            bool? sticky_sender = null, bool? local_connect = null, List<NumberPriority> number_priority = null) {
            return await ((PowerpackInterface) Interface)
                .UpdateAsync (Id, name, application_type, application_id, sticky_sender, local_connect, number_priority);
        }
        public ListResponse<Numbers> List_Numbers (string starts_with = null, string country_iso2 = null,
            string type = null, uint? limit = null, uint? offset = null) {
            return ((PowerpackInterface) Interface)
                .List_Numbers (number_pool_id, starts_with, country_iso2, type, limit, offset);
        }
        public async Task<ListResponse<Numbers>> List_NumbersAsync (
            string starts_with = null, string country_iso2 = null,
            string type = null, uint? limit = null, uint? offset = null) {
            return await ((PowerpackInterface) Interface)
                .List_NumbersAsync (number_pool_id, starts_with, country_iso2, type, limit, offset);

        }

        public uint Count_Numbers (string starts_with = null, string country_iso2 = null,
            string type = null, uint? limit = null, uint? offset = null) {
            return ((PowerpackInterface) Interface)
                .Count_Number (number_pool_id, starts_with, country_iso2, type, limit, offset);
        }
        public async Task<uint> Count_NumbersAsync (
            string starts_with = null, string country_iso2 = null,
            string type = null, uint? limit = null, uint? offset = null) {
            return await ((PowerpackInterface) Interface)
                .Count_NumbersAsync (number_pool_id, starts_with, country_iso2, type, limit, offset);

        }
        public Numbers Add_Number (string number) {
            return ((PowerpackInterface) Interface)
                .Add_Number (number_pool_id, number);
        }
        public async Task<Numbers> Add_NumberAsync (string number) {
            return await ((PowerpackInterface) Interface)
                .Add_NumberAsync (number_pool_id, number);
        }

        public Tollfree Add_Tollfree (string tollfree) {
            return ((PowerpackInterface) Interface)
                .Add_Tollfree (number_pool_id, tollfree);
        }
        public async Task<Tollfree> Add_TollfreeAsync (string tollfree) {
            return await ((PowerpackInterface) Interface)
                .Add_TollfreeAsync (number_pool_id, tollfree);
        }

        public DeleteResponse<Numbers> Remove_Number (string number, bool? unrent = null) {
            return ((PowerpackInterface) Interface)
                .Remove_Number (number_pool_id, number, unrent);
        }
        public async Task<DeleteResponse<Numbers>> Remove_NumberAsync (
            string number, bool? unrent = null) {
            return await ((PowerpackInterface) Interface)
                .Remove_NumberAsync (number_pool_id, number, unrent);
        }

        public DeleteResponse<Tollfree> Remove_Tollfree (string tollfree, bool? unrent = null) {
            return ((PowerpackInterface) Interface)
                .Remove_Tollfree (number_pool_id, tollfree, unrent);
        }
        public async Task<DeleteResponse<Tollfree>> Remove_TollfreeAsync (
            string tollfree, bool? unrent = null) {
            return await ((PowerpackInterface) Interface)
                .Remove_TollfreeAsync (number_pool_id, tollfree, unrent);
        }

        public Numbers Find_Number (string number) {
            return ((PowerpackInterface) Interface)
                .Find_Number (number_pool_id, number);
        }
        public async Task<Numbers> Find_NumberAsync (
            string number) {
            return await ((PowerpackInterface) Interface)
                .Find_NumberAsync (number_pool_id, number);
        }
        public ListResponse<Shortcode> List_Shortcode (uint? limit = null, uint? offset = null) {
            return ((PowerpackInterface) Interface)
                .ListShortcode (number_pool_id, limit, offset);
        }
        public async Task<ListResponse<Shortcode>> List_ShortcodeAsync (uint? limit = null, uint? offset = null) {
            return await ((PowerpackInterface) Interface)
                .List_ShortcodeAsync (number_pool_id, limit, offset);
        }

        public Shortcode Find_Shortcode (string shortcode) {
            return ((PowerpackInterface) Interface)
                .Find_Shortcode (shortcode, number_pool_id);
        }
        public async Task<Shortcode> Find_ShortcodeAsync (
            string shortcode) {
            return await ((PowerpackInterface) Interface)
                .Find_ShortcodeAsync (shortcode, number_pool_id);
        }

        public DeleteResponse<Shortcode> Remove_Shortcode (string shortcode, bool? unrent = null) {
            return ((PowerpackInterface) Interface)
                .Remove_Shortcode (number_pool_id, shortcode, unrent);
        }
        public async Task<DeleteResponse<Shortcode>> Remove_ShortcodeAsync (
            string shortcode, bool? unrent = null) {
            return await ((PowerpackInterface) Interface)
                .Remove_ShortcodeAsync (number_pool_id, shortcode, unrent);
        }

        public ListResponse<Tollfree> List_Tollfree (uint? limit = null, uint? offset = null) {
            return ((PowerpackInterface) Interface)
                .ListTollfree (number_pool_id, limit, offset);
        }
        public async Task<ListResponse<Tollfree>> List_TollfreeAsync (uint? limit = null, uint? offset = null) {
            return await ((PowerpackInterface) Interface)
                .List_TollfreeAsync (number_pool_id, limit, offset);
        }

        public Tollfree Find_Tollfree (string tollfree) {
            return ((PowerpackInterface) Interface)
                .Find_Tollfree (tollfree, number_pool_id);
        }
        public async Task<Tollfree> Find_TollfreeAsync (
            string tollfree) {
            return await ((PowerpackInterface) Interface)
                .Find_TollfreeAsync (tollfree, number_pool_id);
        }

        public Numbers Buy_Add_Number (string number = null, string type = null, string country_iso2 = null, string region = null, string pattern = null) {
            if (number == null) {
                var countryIso = country_iso2;
                var numbers = PhoneNumberI.List (countryIso, type, pattern, region);
                number = numbers.Objects[0].Number;
            }
            return ((PowerpackInterface) Interface)
                .Add_Number (number_pool_id, number, true);
        }
        public async Task<Numbers> Buy_Add_NumberAsync (string number = null, string type = null, string country_iso2 = null, string region = null, string pattern = null) {
            if (number == null) {
                var countryIso = country_iso2;
                var numbers = PhoneNumberI.List (countryIso, type, pattern, region);
                number = numbers.Objects[0].Number;
            }
            return await ((PowerpackInterface) Interface)
                .Add_NumberAsync (number_pool_id, number, true);
        }

        public override string ToString () {
            return "\n" +
                "UUID: " + uuid + "\n" +
                "Name: " + name + "\n" +
                "StickySender: " + sticky_sender + "\n" +
                "LocalConnect: " + local_connect + "\n" +
                "ApplicationType: " + application_type + "\n" +
                "ApplicationId: " + application_id + "\n" +
                "NumberPool: " + number_pool + "\n" +
                "CreatedOn: " + created_on + "\n" +
                "NumberPriority: " + number_priority + "\n";
        }
    }
}
