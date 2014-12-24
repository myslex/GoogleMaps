using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core
{
    public enum ServiceResponseStatus
    {
        Unknown = 0,

        /// <summary>
        /// Indicates that no errors occurred; the address was successfully 
        /// parsed and at least one geocode was returned.
        /// </summary>
        Ok = -1,

        /// <summary>
        /// Indicating the service request was malformed.
        /// </summary>
        InvalidRequest = 1,

        /// <summary>
        /// Indicates that the geocode was successful but returned no results.
        /// This may occur if the geocode was passed a non-existent address or
        /// a latlng in a remote location.
        /// </summary>
        ZeroResults = 2,

        /// <summary>
        /// Indicates that you are over your quota.
        /// </summary>
        OverQueryLimit = 3,

        /// <summary>
        /// Indicates that your request was denied, generally because of lack
        /// of a sensor parameter.
        /// </summary>
        RequestDenied = 4
    }
}
