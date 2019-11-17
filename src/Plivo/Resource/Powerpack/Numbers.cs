using System;
using System.Threading.Tasks;
using Plivo.Resource.PhoneNumber;
namespace Plivo.Resource.Powerpack
{
    /// <summary>
    /// Numberpool.
    /// </summary>
    public class Numbers : Resource
    {
        private string numberpooluuid = "";
        public Numbers(string number_pool_id)
        {
            numberpooluuid = number_pool_id;
        }
        public Numbers(){

        }
        public Lazy<PhoneNumberInterface> _phonenumber;

        public Lazy<PowerpackInterface> _powerpackInterface;

        private PowerpackInterface PowerpackI =>_powerpackInterface.Value;
        private PhoneNumberInterface PhoneNumberI => _phonenumber.Value;
        public new string Id => NumberPoolUuid;

        /// <summary>
        /// account_phone_number_resource
        /// </summary>
        /// <value>The account_phone_number_resource .</value>
        public string AccountPhoneNumberResource { get; set; }

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
        /// Gets or sets  the Number.
        /// </summary>
        /// <value>The Number.</value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the NumberPoolUUID.
        /// </summary>
        /// <value>The NumberPoolUUID.</value>
        public string NumberPoolUuid { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        /// <value>The Type</value>
        public string Type { get; set; }

        public Numbers Get(string memberId)
        {
            var member = new Numbers();
            return member;
        }
        public ListResponse<Numbers> List(string starts_with = null, string country_iso2 = null,
        string type = null, uint? limit = null, uint? offset = null)
        {
            return PowerpackI.List_Numbers(numberpooluuid, starts_with, country_iso2, type, limit, offset);
        }
        public async Task<ListResponse<Numbers>> ListAsync(
          string starts_with = null, string country_iso2 = null,
          string type = null, uint? limit = null, uint? offset = null)
        {
            return await PowerpackI
                .List_NumbersAsync(numberpooluuid, starts_with, country_iso2, type, limit, offset);

        }

        public uint Count(string starts_with = null, string country_iso2 = null,
        string type = null, uint? limit = null, uint? offset = null)
        {
            
            return PowerpackI
                               .Count_Number(numberpooluuid, starts_with, country_iso2, type, limit, offset);
        }
        public async Task<uint> CountAsync(
          string starts_with = null, string country_iso2 = null,
          string type = null, uint? limit = null, uint? offset = null)
        {
            return await PowerpackI
                .Count_NumbersAsync(numberpooluuid, starts_with, country_iso2, type, limit, offset);

        }
        public Numbers Add(string number)
        {
            return PowerpackI
                               .Add_Number(numberpooluuid, number);
        }
        public async Task<Numbers> AddAsync(string number)
        {
            return await PowerpackI
                .Add_NumberAsync(numberpooluuid, number);
        }

        public DeleteResponse<Numbers> Remove(string number, bool? unrent = null)
        {
            return PowerpackI
                               .Remove_Number(numberpooluuid, number, unrent);
        }
        public async Task<DeleteResponse<Numbers>> RemoveAsync(
            string number, bool? unrent = null)
        {
            return await PowerpackI
                .Remove_NumberAsync(numberpooluuid, number, unrent);
        }

        public Numbers Find(string number)
        {
            return PowerpackI
                               .Find_Number(numberpooluuid, number);
        }
        public async Task<Numbers> FindAsync(
            string number)
        {
            return await PowerpackI
                .Find_NumberAsync(numberpooluuid, number);
        }
        

        public Numbers Buy_Add_Number(string number = null, string type = null, string country_iso2 = null, string region = null, string pattern = null)
        {
            if (number == null)
            {
                var countryIso = country_iso2;
                var numbers = PhoneNumberI.List(countryIso, type, pattern, region);
                number = numbers.Objects[0].Number;
            }
            return PowerpackI
                               .Add_Number(numberpooluuid, number, true);
        }
        public async Task<Numbers> Buy_Add_NumberAsync(string number = null, string type = null, string country_iso2 = null, string region = null, string pattern = null)
        {
            if (number == null)
            {
                var countryIso = country_iso2;
                var numbers = PhoneNumberI.List(countryIso, type, pattern, region);
                number = numbers.Objects[0].Number;
            }
            return await PowerpackI
                .Add_NumberAsync(numberpooluuid, number, true);
        }

        public override string ToString()
        {
            return "\n" +
                    "Type: " + Type + "\n" +
                    "NumberPoolUUID: " + NumberPoolUuid + "\n" +
                   "Number: " + Number + "\n" +
                   "CountryISO2: " + CountryIso2 + "\n" +
                   "AddedOn: " + AddedOn + "\n" +
                   "AccountPhoneNumberResource: " + AccountPhoneNumberResource + "\n";
        }
    }

}