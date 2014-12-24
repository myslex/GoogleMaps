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
    public class Result
    {
        /// <summary>
        /// A string containing the human-readable address of this location.
        /// Often this address is equivalent to the "postal address," which
        /// sometimes differs from country to country. (Note that some
        /// countries, such as the United Kingdom, do not allow distribution
        /// of true postal addresses due to licensing restrictions.) This
        /// address is generally composed of one or more address components.
        /// </summary>
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
