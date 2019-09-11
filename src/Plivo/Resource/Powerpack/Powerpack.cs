namespace Plivo.Resource.Powerpack
{
    /// <summary>
    /// Powerpack.
    /// </summary>
    public class Powerpack : Resource
    {
        public new string Id => UUID;

        /// <summary>
        /// Applicatio ID
        /// </summary>
        /// <value>The application_id .</value>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets application type.
        /// </summary>
        /// <value>Application_type.</value>
        public string ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets the created_on.
        /// </summary>
        /// <value>The created_on.</value>
        public string CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets  the LocalConnect.
        /// </summary>
        /// <value>The LocalConnect.</value>
        public bool LocalConnect { get; set; }

        /// <summary>
        /// Gets or sets the sticky_sender.
        /// </summary>
        /// <value>The sticky_sender.</value>
        public bool StickySender { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        /// <value>The powerpack name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets  UUID.
        /// </summary>
        /// <value>The uuid.</value>
        public string UUID { get; set; }

        /// <summary>
        /// Gets or sets the number_pool.
        /// </summary>
        /// <value>The number_pool.</value>
        public string number_pool { get; set; }

        public override string ToString()
        {
            return "\n" +
                    "UUID: " + UUID +"\n" +
                    "Name: " + Name + "\n" + 
                   "StickySender: " + StickySender + "\n" +
                   "LocalConnect: " + LocalConnect + "\n" +
                   "ApplicationType: " + ApplicationType + "\n" +
                   "ApplicationId: " + ApplicationId + "\n" +
                   "NumberPool: " + number_pool + "\n" +
                   "CreatedOn: " + CreatedOn + "\n" ;
        }
    }
}