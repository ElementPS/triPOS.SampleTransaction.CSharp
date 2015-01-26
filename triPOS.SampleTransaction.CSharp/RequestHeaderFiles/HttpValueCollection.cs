namespace triPOS.SampleTransaction.CSharp.RequestHeaderFiles
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HttpValueCollection : List<HttpValue>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        ///     Public constructor.
        /// </summary>
        public HttpValueCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        ///     Public constructor that accepts a query to parse into
        ///     a new HttpValueCollection and sets the URL encoded value to true.
        /// </summary>
        /// <param name="query">
        /// The query to parse into a new HttpValueCollection.
        /// </param>
        public HttpValueCollection(string query)
            : this(query, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValueCollection"/> class. 
        ///     Public constructor that accepts a query to parse into
        ///     a new HttpValueCollection and sets the URL encoded
        ///     value to the given boolean value.
        /// </summary>
        /// <param name="query">
        /// The query to parse into a new HttpValueCollection.
        /// </param>
        /// <param name="urlEncoded">
        /// True if the HttpValueCollection is URL encoded.
        /// </param>
        public HttpValueCollection(string query, bool urlEncoded)
        {
            if (!string.IsNullOrEmpty(query))
            {
                this.FillFromString(query, urlEncoded);
            }
        }

        #endregion

        #region Parameters

        #region Public Properties

        /// <summary>
        ///     Gets all of the keys in the collection.
        /// </summary>
        public string[] AllKeys
        {
            get
            {
                return this.Select(item => item.Key).ToArray();
            }
        }

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets or sets the value at the given key.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <returns>
        ///     The value.
        /// </returns>
        public string this[string key]
        {
            get
            {
                return this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value;
            }

            set
            {
                this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value = value;
            }
        }

        #endregion

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds an HttpValue with the given key and value to the collection.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <param name="value">
        ///     The value.
        /// </param>
        public void Add(string key, string value)
        {
            this.Add(new HttpValue(key, value));
        }

        /// <summary>
        ///     Returns true if the collection contains an HttpValue with the given key.
        /// </summary>
        /// <param name="key">
        ///     The key to search for in the collection.
        /// </param>
        /// <returns>
        ///     True if the collection contains an HttpValue with the given key.
        /// </returns>
        public bool ContainsKey(string key)
        {
            return this.Any(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     Returns an array of values that correspond to the given key.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <returns>
        ///     An array of values that correspond go the given key.
        /// </returns>
        public string[] GetValues(string key)
        {
            return this.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToArray();
        }

        /// <summary>
        ///     Removes from the collection all of the HttpValue objects with the given key.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        public void Remove(string key)
        {
            this.RemoveAll(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     Formats the collection with a URL encoded boolean value of true.
        /// </summary>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        public override string ToString()
        {
            return this.ToString(true);
        }

        /// <summary>
        ///     Formats the collection with the given URL encoded boolean value and null
        ///     for any excluded keys.
        /// </summary>
        /// <param name="urlEncoded">
        ///     True if the collection is URL encoded.
        /// </param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        public virtual string ToString(bool urlEncoded)
        {
            return this.ToString(urlEncoded, null);
        }

        /// <summary>
        ///     Formats the collection into a string with the given URL encoded boolean value
        ///     and a dictionary of excluded keys.
        /// </summary>
        /// <param name="urlEncoded">
        ///     True if the collection is URL encoded.
        /// </param>
        /// <param name="excludeKeys">
        ///     Keys to be excluded.
        /// </param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        public virtual string ToString(bool urlEncoded, IDictionary excludeKeys)
        {
            if (this.Count == 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            foreach (HttpValue item in this)
            {
                string key = item.Key;

                if ((excludeKeys == null) || !excludeKeys.Contains(key))
                {
                    string value = item.Value;

                    if (urlEncoded)
                    {
                        key = Uri.EscapeDataString(key);
                    }

                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append('&');
                    }

                    stringBuilder.Append((key != null) ? (key + "=") : string.Empty);

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        if (urlEncoded)
                        {
                            value = Uri.EscapeDataString(value);
                        }

                        stringBuilder.Append(value);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Fills the collection with HttpValues from the given query.
        /// </summary>
        /// <param name="query">
        ///     The query to parse.
        /// </param>
        /// <param name="urlEncoded">
        ///     True if the collection is URL encoded.
        /// </param>
        private void FillFromString(string query, bool urlEncoded)
        {
            int num = (query != null) ? query.Length : 0;
            for (int i = 0; i < num; i++)
            {
                int startIndex = i;
                int num4 = -1;
                while (i < num)
                {
                    char ch = query[i];
                    if (ch == '=')
                    {
                        if (num4 < 0)
                        {
                            num4 = i;
                        }
                    }
                    else if (ch == '&')
                    {
                        break;
                    }

                    i++;
                }

                string str = null;
                string str2 = null;
                if (num4 >= 0)
                {
                    str = query.Substring(startIndex, num4 - startIndex);
                    str2 = query.Substring(num4 + 1, (i - num4) - 1);
                }
                else
                {
                    str2 = query.Substring(startIndex, i - startIndex);
                }

                if (urlEncoded)
                {
                    this.Add(Uri.UnescapeDataString(str), Uri.UnescapeDataString(str2));
                }
                else
                {
                    this.Add(str, str2);
                }

                if ((i == (num - 1)) && (query[i] == '&'))
                {
                    this.Add(null, string.Empty);
                }
            }
        }

        #endregion
    }
}