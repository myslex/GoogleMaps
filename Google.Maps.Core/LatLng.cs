﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class LatLng : Location, IEquatable<LatLng>
    {
        public LatLng()
        {
        }
        /// <summary>
        /// Create a new latlng instance with the given latitude and longitude coordinates.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public LatLng(decimal latitude, decimal longitude)
        {
            this._latitude = Convert.ToDouble(latitude);
            this._longitude = Convert.ToDouble(longitude);
        }

        /// <summary>
        /// Create a new latlng instance with the given latitude and longitude coordinates.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public LatLng(double latitude, double longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }
        /// <summary>
        /// Create a new latlng instance with the given latitude and longitude coordinates.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public LatLng(float latitude, float longitude)
        {
            this._latitude = Convert.ToDouble(latitude);
            this._longitude = Convert.ToDouble(longitude);
        }

        private double _latitude;
        private double _longitude;

        /// <summary>
        /// Gets or sets the latitude coordinate
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude
        {
            get { return _latitude; }
        }

        /// <summary>
        /// Gets or sets the longitude coordinate
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude
        {
            get { return _longitude; }
        }

        /// <summary>
        /// Gets the string representation of the latitude and longitude coordinates.  Default format is "N6" for 6 decimal precision.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString("N6");
        }

        /// <summary>
        /// Gets the string representation of the latitude and longitude coordinates.  The format is applies to a System.Double, so any format applicable for System.Double will work.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(50); //default to 50 in the internal array.
            sb.Append(this.Latitude.ToString(format, System.Globalization.CultureInfo.InvariantCulture));
            sb.Append(",");
            sb.Append(this.Longitude.ToString(format, System.Globalization.CultureInfo.InvariantCulture));

            return sb.ToString();
        }

        /// <summary>
        /// Gets the current instance as a URL encoded value.
        /// </summary>
        /// <returns></returns>
        public override string GetAsUrlParameter()
        {
            //we're not returning crazy characters so just return the string.  
            //prevents the comma from being converted to %2c, expanding the single character to three characters.
            return this.ToString("R");
        }

        #region Parse

        /// <summary>
        /// Parses a LatLng from a set of latitude/longitude coordinates
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static LatLng Parse(string value)
        {
            if (value == null) throw new ArgumentNullException("value");

            try
            {
                string[] parts = value.Split(',');

                if (parts.Length != 2) throw new FormatException("Missing data for points.");

                double latitude = double.Parse(parts[0].Trim(), CultureInfo.InvariantCulture);
                double longitude = double.Parse(parts[1].Trim(), CultureInfo.InvariantCulture);

                LatLng latlng = new LatLng(latitude, longitude);

                return latlng;
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to parse LatLng.", ex);
            }
        }
        #endregion

        public override bool Equals(object obj)
        {
            return Equals(obj as LatLng);
        }
        public bool Equals(LatLng other)
        {
            if (other == null) return false;

            if (other.Latitude == this.Latitude && other.Longitude == this.Longitude)
            {
                return true;
            }

            //else
            return false;
        }
    }
}
