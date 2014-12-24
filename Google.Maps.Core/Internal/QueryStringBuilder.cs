using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Core.Internal
{
    internal class QueryStringBuilder
    {
        StringBuilder StringBuilder { get { return this._sb; } }
        StringBuilder _sb = new StringBuilder();

        public override string ToString()
        {
            return _sb.ToString();
        }

        /// <summary>
        /// Appends a key/value pair when the value isn't null.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryStringBuilder Append(string key, string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                if (_sb.Length > 0) _sb.Append("&");
                _sb.Append(key).Append("=").Append(value);
            }
            return this;
        }

        /// <summary>
        /// Appends a value when the string isn't null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryStringBuilder Append(string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                if (_sb.Length > 0) _sb.Append("&");
                _sb.Append(value);
            }
            return this;
        }
    }
}
