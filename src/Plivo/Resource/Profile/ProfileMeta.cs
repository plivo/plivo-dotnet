using System.Threading;
using Newtonsoft.Json;

namespace Plivo.Resource
{
    /// <summary>
    /// Profile Meta.
    /// </summary>
    public class ProfileMeta
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
        [JsonProperty("next")]
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        [JsonProperty("offset")]
        public uint Offset { get; set; }

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        [JsonProperty("previous")]
        public string Previous { get; set; }

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
                "Previous: " + Previous + "\n";
        }
    }
}