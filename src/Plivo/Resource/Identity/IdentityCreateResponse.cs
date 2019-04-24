using System;

namespace Plivo.Resource.Identity
{
    public class IdentityCreateResponse : CreateResponse
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public ErrorMessage Error { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}