using System;
using System.Collections.Generic;
using System.Text;

namespace Plivo.Resource.Address
{
    public class AddressGetResponse : Address
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public ErrorMessage Error { get; set; }
    }
}
