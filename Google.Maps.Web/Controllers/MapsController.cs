using Google.Maps.Core;
using Google.Maps.Core.Geocoding;
using Google.Maps.Core.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;

namespace Google.Maps.Web.Controllers
{
    public class MapsController : ApiController
    {
        // GET: api/Maps
        public IEnumerable<Result> Get(int count = 10)
        {
            var request = new GeocodingRequest();
            request.Address = new Location("avenue");
            var url = request.Address.GetAsUrlParameter();
            request.Sensor = false;
            var response = new GeocodingService().GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok)
                return response.Results.Take(count);

            return null;
        }

        // GET: api/Maps/streetaddress
        [Route("api/maps/{address}")]
        public IEnumerable<Result> Get(string address, int count = 10)
        {
            var request = new GeocodingRequest();
            request.Address = new Location(address);
            var url = request.Address.GetAsUrlParameter();
            request.Sensor = false;
            var response = new GeocodingService().GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok)
                return response.Results.Take(count);

            return null;
        }
    }
}
