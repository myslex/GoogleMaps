using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Geometry
    {
        /// <summary>
        /// Contains the geocoded latitude,longitude value. For normal address
        /// lookups, this field is typically the most important.
        /// </summary>
        [JsonProperty("location")]
        public LatLng Location { get; set; }

        ///// <summary>
        ///// Contains the recommended viewport for displaying the returned
        ///// result, specified as two latitude,longitude values defining the
        ///// southwest and northeast corner of the viewport bounding box.
        ///// Generally the viewport is used to frame a result when displaying
        ///// it to a user.
        ///// </summary>
        //[JsonProperty("viewport")]
        //public Viewport Viewport { get; set; }

        ///// <summary>
        ///// The precise bounds of the geocoding result, if applicable. Null if not.
        ///// </summary>
        //[JsonProperty("bounds")]
        //public Viewport Bounds { get; set; }
    }
}
