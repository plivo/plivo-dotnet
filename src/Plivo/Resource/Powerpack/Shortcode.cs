
namespace Plivo.Resource.Shortcode
{
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class Shortcode : Resource
    {
        public new string Id => NumberPoolUUID;

        /// <summary>
        /// shortcode
        /// </summary>
        /// <value>The shortcode .</value>
        public string Shortcode { get; set; }

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
        /// Gets or sets the NumberPoolUUID.
        /// </summary>
        /// <value>The NumberPoolUUID.</value>
        public bool NumberPoolUUID { get; set; }

        

        public override string ToString()
        {
            return "\n" +
                   "NumberPoolUUID: " + NumberPoolUUID + "\n" + 
                   "Shortcode: " + Shortcode + "\n" +
                   "CountryISO2: " + CountryISO2 + "\n" +
                   "AddedOn: " + AddedOn + "\n" ;
        }
    }
}