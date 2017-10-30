using System.Threading;

namespace Plivo.Resource
{
    /// <summary>
    /// Meta.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public uint Limit { get; set; }
        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        public string Next { get; set; }
        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public uint Offset { get; set; }
        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        public string Previous { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        public uint TotalCount { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Meta"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:plivo.Resource.Meta"/>.</returns>
        public override string ToString()
        {
            return
                "Limit: " + Limit + "\n" +
                "Next: " + Next + "\n" +
                "Offset: " + Offset + "\n" +
                "Previous: " + Previous + "\n" +
                "TotalCount: " + TotalCount + "\n";
        }
    }
}
