using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Plivo.Resource.VerifySession
{

[JsonObject(MemberSerialization.OptIn)]
public class VerifySessionCreateResponse : Resource
{
    [JsonProperty("api_id")]
    public new string ApiId { get; set; }
    
    [JsonProperty("session_uuid")]
    public new string SessionUUID { get; set; }

    [JsonProperty("message")]
    public new string Messgae { get; set; }

    [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)] // Ignore null values for "error"
    public string Error { get; set; }

    public override string ToString()
    {
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore // Ignore null values globally
        };

        return JsonConvert.SerializeObject(this, settings);
    }
}

}