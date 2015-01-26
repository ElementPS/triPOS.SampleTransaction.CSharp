namespace triPOS.SampleTransaction.CSharp.RequestModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// The properties of a billing and shipping address.
    /// </summary>
    public class Address
    {
        /// <summary>
        ///     Gets or sets the street address used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingAddress1")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingAddress1")]
        public string BillingAddress1 { get; set; }

        /// <summary>
        ///     Gets or sets the street address used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingAddress2")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingAddress2")]
        public string BillingAddress2 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the city used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingCity")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingCity")]
        public string BillingCity { get; set; }

        /// <summary>
        ///     Gets or sets the e-mail address used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingEmail")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingEmail")]
        public string BillingEmail { get; set; }

        /// <summary>
        ///     Gets or sets the name used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingName")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingName")]
        public string BillingName { get; set; }

        /// <summary>
        ///     Gets or sets the phone number used for billing purposes. The recommended format is (800)555-1212.
        /// </summary>
        [DataMember(Name = "billingPhone")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingPhone")]
        public string BillingPhone { get; set; }

        /// <summary>
        ///     Gets or sets the postal code used for billing purposes.
        /// </summary>
        [DataMember(Name = "billingPostalCode")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingPostalCode")]
        public string BillingPostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the state used for billing purposes. This value may be any 2 character state code or the
        ///     full state name.
        /// </summary>
        [DataMember(Name = "billingState")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("billingState")]
        public string BillingState { get; set; }

        /// <summary>
        ///     Gets or sets the street address used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingAddress1")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingAddress1")]
        public string ShippingAddress1 { get; set; }

        /// <summary>
        ///     Gets or sets the street address used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingAddress2")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingAddress2")]
        public string ShippingAddress2 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the city used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingCity")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingCity")]
        public string ShippingCity { get; set; }

        /// <summary>
        ///     Gets or sets the e-mail address used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingEmail")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingEmail")]
        public string ShippingEmail { get; set; }

        /// <summary>
        ///     Gets or sets the name used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingName")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingName")]
        public string ShippingName { get; set; }

        /// <summary>
        ///     Gets or sets the phone number used for shipping purposes. The recommended format is (800)555-1212
        /// </summary>
        [DataMember(Name = "shippingPhone")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingPhone")]
        public string ShippingPhone { get; set; }

        /// <summary>
        ///     Gets or sets the postal code used for shipping purposes.
        /// </summary>
        [DataMember(Name = "shippingPostalCode")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingPostalCode")]
        public string ShippingPostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the state used for shipping purposes. This value may be any 2 character state code or the
        ///     full state name.
        /// </summary>
        [DataMember(Name = "shippingState")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shippingState")]
        public string ShippingState { get; set; }
    }
}