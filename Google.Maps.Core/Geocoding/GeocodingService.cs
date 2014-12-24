using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core.Geocoding
{
/// <summary>
    /// Provides a direct way to access a geocoder via an HTTP request.
    /// Additionally, the service allows you to perform the converse operation
    /// (turning coordinates into addresses); this process is known as
    /// "reverse geocoding."
    /// </summary>
    public class GeocodingService
    {
        public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/geocode/");
        public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/geocode/");

        public Uri BaseUri { get; set; }

        public GeocodingService()
            : this(HttpsUri)
        {
        }

        public GeocodingService(Uri baseUri)
        {
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Sends the specified request to the Google Maps Geocoding web
        /// service and parses the response as an GeocodingResponse
        /// object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GeocodeResponse GetResponse(GeocodingRequest request)
        {
            var url = new Uri(this.BaseUri, request.ToUri());
            return Internal.Http.Get(url).As<GeocodeResponse>();
        }
    }
}
