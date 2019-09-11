namespace Plivo.Resource.NumberPool
{
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class NumberPool : Resource
    {
        public new string Id => NumberPoolUUID;

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
        public string CountryISO2 { get; set; }

        /// <summary>
        /// Gets or sets  the Number.
        /// </summary>
        /// <value>The Number.</value>
        public bool Number { get; set; }

        /// <summary>
        /// Gets or sets the NumberPoolUUID.
        /// </summary>
        /// <value>The NumberPoolUUID.</value>
        public bool NumberPoolUUID { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        /// <value>The Type</value>
        public string Type { get; set; }

        

        public override string ToString()
        {
            return "\n" +
                    "Type: " + Type +"\n" +
                    "NumberPoolUUID: " + NumberPoolUUID + "\n" + 
                   "Number: " + Number + "\n" +
                   "CountryISO2: " + CountryISO2 + "\n" +
                   "AddedOn: " + AddedOn + "\n" +
                   "AccountPhoneNumberResource: " + AccountPhoneNumberResource + "\n" ;
        }
    }
}