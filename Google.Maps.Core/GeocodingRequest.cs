using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Google.Maps.Core
{
    /// <summary>
    /// Provides a request for the Google Maps Geocoding web service.
    /// </summary>
    public class GeocodingRequest
    {
        /// <summary>
        /// The address that you want to geocode.  Use LatLng to perform a reverse geocoding request.
        /// </summary>
        /// <see cref="http://code.google.com/apis/maps/documentation/geocoding/#ReverseGeocoding"/>
        /// <remarks>Required if latlng not present.</remarks>
        public Location Address { get; set; }

        /// <summary>
        /// Undocumented address component filters.
        /// Only geocoding results matching the component filters will be returned.
        /// </summary>
        /// <remarks>IE: country:uk|locality:stathern</remarks>
        public string Components { get; set; }

        /// <summary>
        /// The region code, specified as a ccTLD ("top-level domain")
        /// two-character value.
        /// </summary>
        /// <remarks>
        /// Optional. This parameter will only influence, not fully restrict, results
        /// from the geocoder.
        /// </remarks>
        /// <see cref="http://code.google.com/apis/maps/documentation/geocoding/#RegionCodes"/>
        public string Region { get; set; }

        /// <summary>
        /// The language in which to return results. If language is not
        /// supplied, the geocoder will attempt to use the native language of
        /// the domain from which the request is sent wherever possible.
        /// </summary>
        /// <remarks>Optional.</remarks>
        /// <see cref="http://code.google.com/apis/maps/faq.html#languagesupport"/>
        public string Language { get; set; }

        /// <summary>
        /// Indicates whether or not the geocoding request comes from a device
        /// with a location sensor. This value must be either true or false.
        /// </summary>
        /// <remarks>Required.</remarks>
        public bool? Sensor { get; set; }

        internal Uri ToUri()
        {
            EnsureSensor();
            if (Address == null) throw new InvalidOperationException("Address property is not set.");

            var qsb = new Internal.QueryStringBuilder();

            //if (this.Address.GetType() == typeof(LatLng))
            //{
            //    qsb.Append("latlng", Address.GetAsUrlParameter());
            //}
            //else
            //{
            qsb.Append("address", Address.GetAsUrlParameter());
            //}

            qsb.Append("components", HttpUtility.UrlEncode(Components))
                .Append("region", Region)
                .Append("language", Language)
                .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

            var url = "json?" + qsb.ToString();

            return new Uri(url, UriKind.Relative);
        }

        private void EnsureSensor()
        {
            if (this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");
        }
    }
}
