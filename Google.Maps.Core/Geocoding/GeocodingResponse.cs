using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core.Geocoding
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class GeocodeResponse
    {
        [JsonProperty("status")]
        public ServiceResponseStatus Status { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }
}
