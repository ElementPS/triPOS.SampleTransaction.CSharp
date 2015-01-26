namespace triPOS.SampleTransaction.CSharp.RequestModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     The set of properties that override values in the triPOS.config file
    /// </summary>
    [DataContract(Name = "Configuration")]
    public class Configuration
    {
        /// <summary>
        ///     If set to true, partial approvals are allowed.
        /// </summary>
        [DataMember(Name = "allowPartialApprovals", IsRequired = true)]
        [XmlElement("allowPartialApprovals")]
        public bool? AllowPartialApprovals { get; set; }

        /// <summary>
        ///     If set to true, disables duplicate checking for the transactions.
        /// </summary>
        [DataMember(Name = "checkForDuplicateTransactions", IsRequired = true)]
        [XmlElement("checkForDuplicateTransactions")]
        public bool? CheckForDuplicateTransactions { get; set; }

        /// <summary>
        ///     The currency code of the transaction
        /// </summary>
        [DataMember(Name = "currencyCode")]
        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     The market code of the transaction. Default, AutoRental, DirectMarketing, ECommerce, FoodRestaurant, HotelLodging, Petroleum, Retail, Qsr
        /// </summary>
        [DataMember(Name = "marketCode")]
        [XmlElement("marketCode")]
        public string MarketCode { get; set; }
    }
}