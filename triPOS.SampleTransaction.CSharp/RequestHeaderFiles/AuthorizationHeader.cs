namespace triPOS.SampleTransaction.CSharp.RequestHeaderFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Security.Authentication;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    ///     Used to create and recreate signed headers for API requests
    /// </summary>
    public class AuthorizationHeader
    {
        #region Constants

        /// <summary>
        ///     The set of accepted and valid URL characters per RFC3986.
        ///     Characters outside of this set will be encoded.
        /// </summary>
        internal const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        /// <summary>
        ///     The set of accepted and valid URL characters per RFC1738.
        ///     Characters outside of this set will be encoded.
        /// </summary>
        internal const string ValidUrlCharactersRFC1738 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.";

        #endregion

        #region Static Fields

        /// <summary>
        ///     The valid RFC encoding schemes. Used when URL encoding a string.
        /// </summary>
        internal static Dictionary<int, string> RFCEncodingSchemes = new Dictionary<int, string> { { 3986, ValidUrlCharacters }, { 1738, ValidUrlCharactersRFC1738 } };

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthorizationHeader" /> class.
        ///     Splits-up the authorization value and sets the properties
        ///     of this class to their corresponding values from the header.
        /// </summary>
        /// <param name="xauthorization">
        ///     The authorization value.
        /// </param>
        public AuthorizationHeader(string xauthorization)
        {
            string[] authParts = xauthorization.Split(',');
            var authDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (string authPart in authParts)
            {
                string[] keyValue = authPart.Split('=');
                authDictionary.Add(keyValue[0].Trim(), keyValue[1].Trim());
            }

            if (authDictionary.ContainsKey("version"))
            {
                this.Version = authDictionary["version"];
            }

            if (authDictionary.ContainsKey("algorithm"))
            {
                this.Algorithm = authDictionary["algorithm"];
            }

            if (authDictionary.ContainsKey("credential"))
            {
                this.Credential = authDictionary["credential"];
            }

            if (authDictionary.ContainsKey("signedheaders"))
            {
                this.SignedHeaders = authDictionary["signedheaders"];
            }

            if (authDictionary.ContainsKey("nonce"))
            {
                this.Nonce = authDictionary["nonce"];
            }

            if (authDictionary.ContainsKey("signature"))
            {
                this.Signature = authDictionary["signature"];
            }

            if (authDictionary.ContainsKey("requestdate"))
            {
                this.RequestDate = authDictionary["requestdate"];
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthorizationHeader" /> class.
        ///     Sets the properties of this class to the corresponding argument value.
        /// </summary>
        /// <param name="version">
        ///     The version of the authorization header.
        /// </param>
        /// <param name="algorithm">
        ///     The algorithm that the client has chosen to use.
        /// </param>
        /// <param name="credential">
        ///     The user's credential.
        /// </param>
        /// <param name="signedHeaders">
        ///     The signed headers that the client sent up.
        /// </param>
        /// <param name="nonce">
        ///     The nonce being used for this request.
        /// </param>
        /// <param name="requestDate">
        ///     The request datetime string.
        /// </param>
        /// <param name="signature">
        ///     The computed signature.
        /// </param>
        public AuthorizationHeader(string version, string algorithm, string credential, string signedHeaders, string nonce, string requestDate, string signature)
        {
            this.Version = version;
            this.Algorithm = algorithm;
            this.Credential = credential;
            this.SignedHeaders = signedHeaders;
            this.Nonce = nonce;
            this.RequestDate = requestDate;
            this.Signature = signature;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the algorithm that the client is using to compute the header signature value.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        ///     Gets or sets the client credential which is the same as the developer key.
        /// </summary>
        public string Credential { get; set; }

        /// <summary>
        ///     Gets or sets the nonce, a one-time-use value being used for this request.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        ///     Gets or sets the date and time that the request is being sent.
        /// </summary>
        public string RequestDate { get; set; }

        /// <summary>
        ///     Gets or sets the computed signature
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        ///     Gets or sets the signed headers that the client sent up, if any.
        /// </summary>
        public string SignedHeaders { get; set; }

        /// <summary>
        ///     The version of the authorization header.
        /// </summary>
        public string Version { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Creates the authorized signed header
        /// </summary>
        /// <param name="headers">
        ///     The request headers sent up by the client.
        /// </param>
        /// <param name="target">
        ///     The URL the request is being sent to.
        /// </param>
        /// <param name="data">
        ///     The request data from the request.
        /// </param>
        /// <param name="method">
        ///     The request method (i.e. POST).
        /// </param>
        /// <param name="version">
        ///     The version of the authorization header.
        /// </param>
        /// <param name="algorithm">
        ///     The algorithm used by the client.
        /// </param>
        /// <param name="nonce">
        ///     The one-time-use value used for this request.
        /// </param>
        /// <param name="requestDate">
        ///     The date and time of the request.
        /// </param>
        /// <param name="developerKey">
        ///     The developer key used in creating the signature.
        /// </param>
        /// <param name="developerSecret">
        ///     The developer secret used in creating the signature.
        /// </param>
        /// <returns>
        ///     The signed authorization header.
        /// </returns>
        public static AuthorizationHeader Create(HttpRequestHeaders headers, Uri target, string data, string method, string version, string algorithm, string nonce, string requestDate, string developerKey, string developerSecret)
        {
            // Hash the request data
            string payloadHash = string.Empty;

            if (!string.IsNullOrEmpty(data))
            {
                payloadHash = HexEncodeHash(data, algorithm);
            }

            string canonicalSignedHeaders = GetCanonicalSignedHeaders(headers);

            string canonicalHeaders = GetCanonicalHeaders(canonicalSignedHeaders, headers);

            string canonicalQueryString = GetCanonicalQueryString(target);

            string canonicalUri = GetCanonicalUri(target);

            string canonicalRequest = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", method, canonicalUri, canonicalQueryString, canonicalHeaders, canonicalSignedHeaders, payloadHash);

            string hashedCanonicalRequest = HexEncodeHash(canonicalRequest, algorithm);

            string keySignature = CreateHmacSignature(CreateUtf8(nonce + developerSecret), CreateUtf8(requestDate), algorithm);

            string stringToSign = string.Format("{0}\n{1}\n{2}\n{3}", algorithm, requestDate, developerKey, hashedCanonicalRequest);

            string finalSignature = CreateHmacSignature(CreateUtf8(stringToSign), CreateUtf8(keySignature), algorithm);

            return new AuthorizationHeader(version, algorithm, developerKey, canonicalSignedHeaders, nonce, requestDate, finalSignature);
        }

        /// <summary>
        ///     Returns a comma separated string of each header key and its value.
        /// </summary>
        /// <returns>
        ///     A formatted string of the header keys and values.
        /// </returns>
        public override string ToString()
        {
            string output = string.Format("Version={0}, Algorithm={1}, Credential={2}, SignedHeaders={3}, Nonce={4}, RequestDate={5}, Signature={6}", this.Version, this.Algorithm, this.Credential, this.SignedHeaders, this.Nonce, this.RequestDate, this.Signature);
            return output;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the HMAC signature of the given data.
        /// </summary>
        /// <param name="data">
        ///     The data that gets hashed.
        /// </param>
        /// <param name="key">
        ///     The key used by the hasher.
        /// </param>
        /// <param name="algorithm">
        ///     The hashing algorithm that is used to compute the hash.
        /// </param>
        /// <returns>
        ///     The hashed data.
        /// </returns>
        private static string CreateHmacSignature(string data, string key, string algorithm)
        {
            KeyedHashAlgorithm hasher = null;
            algorithm = algorithm.ToLower();
            switch (algorithm)
            {
                case "tp-hmac-md5":
                    hasher = KeyedHashAlgorithm.Create("HMACMD5");
                    break;
                case "tp-hmac-sha1":
                    hasher = KeyedHashAlgorithm.Create("HMACSHA1");
                    break;
                case "tp-hmac-sha256":
                    hasher = KeyedHashAlgorithm.Create("HMACSHA256");
                    break;
                case "tp-hmac-sha384":
                    hasher = KeyedHashAlgorithm.Create("HMACSHA384");
                    break;
                case "tp-hmac-sha512":
                    hasher = KeyedHashAlgorithm.Create("HMACSHA512");
                    break;
                default:
                    throw new AuthenticationException("Invalid signature algorithm: " + algorithm);
            }

            hasher.Key = Encoding.UTF8.GetBytes(key);

            byte[] output = hasher.ComputeHash(Encoding.UTF8.GetBytes(data));

            return ToHex(output, true);
        }

        /// <summary>
        ///     Converts the given string to UTF8.
        /// </summary>
        /// <param name="input">
        ///     The string to be converted to UTF8.
        /// </param>
        /// <returns>
        ///     The UTF8 formatted string.
        /// </returns>
        private static string CreateUtf8(string input)
        {
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(input);

            // Convert utf-8 bytes to a string.
            string output = Encoding.UTF8.GetString(utf8Bytes);

            return output;
        }

        /// <summary>
        ///     Creates a canonical list of the given headers.
        /// </summary>
        /// <param name="canonicalSignedHeaders">
        ///     The list of signed headers that should be sorted.
        /// </param>
        /// <param name="headers">
        ///     All request headers.
        /// </param>
        /// <returns>
        ///     A string of canonical headers.
        /// </returns>
        private static string GetCanonicalHeaders(string canonicalSignedHeaders, HttpRequestHeaders headers)
        {
            var sbHeader = new StringBuilder();
            var headersToSort = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (KeyValuePair<string, IEnumerable<string>> httpRequestHeader in headers)
            {
                string key = httpRequestHeader.Key.ToLower().Trim();
                if (!key.StartsWith("tp-"))
                {
                    foreach (string value in httpRequestHeader.Value)
                    {
                        string newValue = value.Replace(Environment.NewLine, " ");

                        if (headersToSort.ContainsKey(key))
                        {
                            // headers put a space in duplicate key values
                            headersToSort[key] = headersToSort[key] + ", " + newValue;
                        }
                        else
                        {
                            headersToSort.Add(key, newValue);
                        }
                    }
                }
            }

            string[] signedHeaderList = canonicalSignedHeaders.Split(';');
            foreach (string signedHeader in signedHeaderList)
            {
                if (headersToSort.ContainsKey(signedHeader))
                {
                    sbHeader.Append(string.Format("{0}:{1}\n", signedHeader, headersToSort[signedHeader]));
                }
            }

            string output = sbHeader.ToString();
            if (output.EndsWith("\n"))
            {
                output = output.Substring(0, output.Length - 1);
            }

            return output;
        }

        /// <summary>
        ///     Orders the query portion of a Uri by key.
        /// </summary>
        /// <param name="target">
        ///     The Uri.
        /// </param>
        /// <returns>
        ///     An ordered, formatted Uri string with the query values.
        /// </returns>
        private static string GetCanonicalQueryString(Uri target)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(target.Query))
            {
                HttpValueCollection nvc = HttpUtility.ParseQueryString(target.Query);
                if (nvc.Count > 0)
                {
                    IOrderedEnumerable<HttpValue> orderedKeyValue = nvc.OrderBy(c => c.Key);
                    var data = new StringBuilder(512);
                    foreach (HttpValue keyValue in orderedKeyValue)
                    {
                        if (keyValue.Value != null)
                        {
                            data.Append(keyValue.Key);
                            data.Append('=');
                            data.Append(UrlEncode(keyValue.Value, false));
                            data.Append('&');
                        }
                    }

                    result = data.ToString();
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Sorts all of the given headers into a canonical string.
        /// </summary>
        /// <param name="headers">
        ///     The headers to sort.
        /// </param>
        /// <returns>
        ///     The canonical string of headers.
        /// </returns>
        private static string GetCanonicalSignedHeaders(HttpRequestHeaders headers)
        {
            var sbHeader = new StringBuilder();
            var headersToSort = new List<string>();

            // For all of the request headers, if the key does not start with tp- then
            // add the request header to the list of headers that will be sorted
            foreach (KeyValuePair<string, IEnumerable<string>> httpRequestHeader in headers)
            {
                string key = httpRequestHeader.Key.ToLower().Trim();
                if (!key.StartsWith("tp-"))
                {
                    if (!headersToSort.Contains(key))
                    {
                        headersToSort.Add(key);
                    }
                }
            }

            // Sort the headers and create a string of semicolon separated headers, the last
            // header value shall not end with a semicolon
            headersToSort.Sort();
            foreach (string sortedHeader in headersToSort)
            {
                if (sbHeader.Length > 0)
                {
                    sbHeader.Append(string.Format(";{0}", sortedHeader));
                }
                else
                {
                    sbHeader.Append(string.Format("{0}", sortedHeader));
                }
            }

            string result = sbHeader.ToString();

            return result;
        }

        /// <summary>
        ///     Extracts the portion of the Uri that is between /api/ and the query string.
        /// </summary>
        /// <param name="target">
        ///     The target from which to extract the substring.
        /// </param>
        /// <returns>
        ///     The substring of the Uri that is between /api/ and the query string.
        /// </returns>
        private static string GetCanonicalUri(Uri target)
        {
            var result = new StringBuilder();
            string url = target.AbsolutePath;
            string bucket = url.Substring(url.IndexOf("/api/", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(bucket))
            {
                if (!bucket.StartsWith("/"))
                {
                    bucket = string.Format("/{0}", bucket);
                }

                if (bucket.EndsWith("/"))
                {
                    bucket = bucket.TrimEnd('/');
                }

                result.Append(bucket);
            }

            return result.ToString();
        }

        /// <summary>
        ///     Hashes the given data using the given algorithm, and returns it
        ///     as a hexadecimal string.
        /// </summary>
        /// <param name="data">
        ///     The data to hash.
        /// </param>
        /// <param name="algorithm">
        ///     The hashing algorithm to use.
        /// </param>
        /// <returns>
        ///     A hexadecimal hashed string.
        /// </returns>
        private static string HexEncodeHash(string data, string algorithm)
        {
            HashAlgorithm hashAlgorithm = null;

            algorithm = algorithm.ToLower();
            switch (algorithm)
            {
                case "tp-hmac-md5":
                    hashAlgorithm = HashAlgorithm.Create("MD5");
                    break;
                case "tp-hmac-sha1":
                    hashAlgorithm = HashAlgorithm.Create("SHA1");
                    break;
                case "tp-hmac-sha256":
                    hashAlgorithm = HashAlgorithm.Create("SHA256");
                    break;
                case "tp-hmac-sha384":
                    hashAlgorithm = HashAlgorithm.Create("SHA384");
                    break;
                case "tp-hmac-sha512":
                    hashAlgorithm = HashAlgorithm.Create("SHA512");
                    break;
                default:
                    throw new AuthenticationException("Invalid signature algorithm: " + algorithm);
            }

            return ToHex(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(data)), true);
        }

        /// <summary>
        ///     Converts the given byte data to a hexadecimal string.
        /// </summary>
        /// <param name="data">
        ///     The byte data to convert.
        /// </param>
        /// <param name="lowercase">
        ///     True if the hexadecimal string should be lowercase.
        /// </param>
        /// <returns>
        ///     The hexadecimal string.
        /// </returns>
        private static string ToHex(byte[] data, bool lowercase)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString(lowercase ? "x2" : "X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        ///     URL encodes a string per RFC3986. If the path property is specified,
        ///     the accepted path characters {/+:} are not encoded.
        /// </summary>
        /// <param name="data">
        ///     The string to encode.
        /// </param>
        /// <param name="path">
        ///     Whether the string is a URL path or not.
        /// </param>
        /// <returns>
        ///     The encoded string.
        /// </returns>
        private static string UrlEncode(string data, bool path)
        {
            return UrlEncode(3986, data, path);
        }

        /// <summary>
        ///     URL encodes a string per the specified RFC. If the path property is specified,
        ///     the accepted path characters {/+:} are not encoded.
        /// </summary>
        /// <param name="rfcNumber">
        ///     RFC number determing safe characters.
        /// </param>
        /// <param name="data">
        ///     The string to encode.
        /// </param>
        /// <param name="path">
        ///     Whether the string is a URL path or not.
        /// </param>
        /// <returns>
        ///     The encoded string.
        /// </returns>
        /// <remarks>
        ///     Currently recognised RFC versions are 1738 (Dec '94) and 3986 (Jan '05).
        ///     If the specified RFC is not recognised, 3986 is used by default.
        /// </remarks>
        private static string UrlEncode(int rfcNumber, string data, bool path)
        {
            var encoded = new StringBuilder(data.Length * 2);
            string validUrlCharacters;
            if (!RFCEncodingSchemes.TryGetValue(rfcNumber, out validUrlCharacters))
            {
                validUrlCharacters = ValidUrlCharacters;
            }

            string unreservedChars = string.Concat(validUrlCharacters, path ? "/:" : string.Empty);

            foreach (char symbol in Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%").Append(string.Format("{0:X2}", (int)symbol));
                }
            }

            return encoded.ToString();
        }

        #endregion
    }
}