namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     A hypermedia link
    /// </summary>
    [DataContract(Name = "link")]
    public class ApiLink
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the href.
        /// </summary>
        [DataMember(Name = "href")]
        [XmlElement("href")]
        public string Href { get; set; }

        /// <summary>
        ///     Gets or sets the method.
        /// </summary>
        [DataMember(Name = "method")]
        [XmlElement("method")]
        public string Method { get; set; }

        /// <summary>
        ///     Gets or sets the relation.
        /// </summary>
        [DataMember(Name = "rel")]
        [XmlElement("rel")]
        public string Relation { get; set; }

        #endregion
    }
}