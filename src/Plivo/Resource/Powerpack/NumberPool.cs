using Plivo.Client;
using Plivo.Resource.PhoneNumber;
using System;
namespace Plivo.Resource.Powerpack
{
    /// <summary>
    /// Numberpool.
    /// </summary>
    public class NumberPool : Resource
    {
        public  string number_pool_id { get; set; }
        public Numbers numbers ;
        public Shortcode shortcodes;
        public NumberPool(string number_pool_id, HttpClient Client){
            numbers = new Numbers(number_pool_id);
            numbers._phonenumber = new Lazy<PhoneNumberInterface>(() => new PhoneNumberInterface(Client));
            numbers._powerpackInterface = new Lazy<PowerpackInterface>(() => new PowerpackInterface(Client));
            shortcodes  = new Shortcode(number_pool_id);
            shortcodes._powerpackInterface = new Lazy<PowerpackInterface>(() => new PowerpackInterface(Client));
       
        }
        
        
    }

}