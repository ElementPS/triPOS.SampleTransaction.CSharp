namespace triPOS.SampleTransaction.CSharp.RequestHeaderFiles
{
    /// <summary>
    ///     Represents an HTTP value with key and value properties.
    /// </summary>
    public sealed class HttpValue
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValue"/> class. 
        ///     Public constructor
        /// </summary>
        public HttpValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpValue"/> class. 
        ///     Public constructor to initialize the key and value properties.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public HttpValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the HttpValue key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the HttpValue value.
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}