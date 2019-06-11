using System;
using System.Collections.Generic;
using System.Text;

namespace Plivo.Resource.Identity
{
    public class IdentityGetResponse : Identity
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public ErrorMessage Error { get; set; }
    }
}
