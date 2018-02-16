using System;

namespace Plivo.Resource.Identity
{
    public class IdentityDocumentDetail
    {
        /// <summary>
        /// Gets or sets Salutation
        /// </summary>
        /// <value>Salutation</value>
        public string Salutation { get; set; }

        /// <summary>
        /// Gets or sets First Name
        /// </summary>
        /// <value>First Name</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name
        /// </summary>
        /// <value>Last Name</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Nationality
        /// </summary>
        /// <value>Nationality</value>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets Id Type
        /// </summary>
        /// <value>The type of ID</value>
        public string IdType { get; set; }

        /// <summary>
        /// Gets or sets Id Number
        /// </summary>
        /// <value>The unique number on the identifier</value>
        public string IdNumber { get; set; }
    }
}