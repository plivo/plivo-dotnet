using System;

namespace Plivo.Resource.Identity
{
    public class IdentityDocumentDetail
    {
        /// <summary>
        /// Gets or sets Address Line 1
        /// </summary>
        /// <value>Address Line 1</value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 2
        /// </summary>
        /// <value>Address Line 2</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        /// <value>City</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Region
        /// </summary>
        /// <value>Region or State</value>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets Postal Code
        /// </summary>
        /// <value>Postal Code</value>
        public string PostalCode { get; set; }

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