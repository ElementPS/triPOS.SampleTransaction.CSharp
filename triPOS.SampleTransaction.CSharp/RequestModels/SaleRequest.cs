namespace triPOS.SampleTransaction.CSharp.RequestModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     The request passed in for a card sale
    /// </summary>
    [DataContract(Name = "saleRequest")]
    [XmlRoot("saleRequest", Namespace = "http://tripos.vantiv.com/2014/09/TriPos.Api")]
    public class SaleRequest
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        [DataMember(Name = "address")]
        [XmlElement("address")]
        public Address Address { get; set; }

        /// <summary>
        ///     The default amount of cashback. This amount is added to the TotalAmount before the cardholder is charged.
        /// </summary>
        [DataMember(Name = "cashbackAmount")]
        [XmlElement("cashbackAmount")]
        public decimal CashbackAmount { get; set; }

        /// <summary>
        ///     The convenience fee amount of the transaction. This amount is added to the TotalAmount before the cardholder is
        ///     charged.
        /// </summary>
        [DataMember(Name = "convenienceFeeAmount")]
        [XmlElement("convenienceFeeAmount")]
        public decimal ConvenienceFeeAmount { get; set; }

        /// <summary>
        ///     The EMV fallback reason of the transaction.
        /// </summary>
        [DataMember(Name = "emvFallbackReason")]
        [XmlElement("emvFallbackReason")]
        public string EmvFallbackReason { get; set; }

        /// <summary>
        ///     The tip amount of the transaction. This amount is added to the TotalAmount before the cardholder is charged.
        /// </summary>
        [DataMember(Name = "tipAmount")]
        [XmlElement("tipAmount")]
        public decimal TipAmount { get; set; }

        /// <summary>
        ///     The amount of the transaction
        /// </summary>
        [DataMember(Name = "transactionAmount")]
        [XmlElement("transactionAmount")]
        public decimal TransactionAmount { get; set; }

        /// <summary>
        ///     The clerk number
        /// </summary>
        [DataMember(Name = "clerkNumber")]
        [XmlElement("clerkNumber")]
        public string ClerkNumber { get; set; }

        /// <summary>
        ///     The configuration section
        /// </summary>
        [DataMember(Name = "configuration", IsRequired = false)]
        [XmlElement("configuration")]
        public Configuration Configuration { get; set; }

        /// <summary>
        ///     Required. Specifies which lane to use for the card sale.
        /// </summary>
        [DataMember(Name = "laneId")]
        [XmlElement("laneId")]
        public int LaneId { get; set; }

        /// <summary>
        ///     The reference number for the transaction
        /// </summary>
        [DataMember(Name = "referenceNumber")]
        [XmlElement("referenceNumber")]
        public string ReferenceNumber { get; set; }

        /// <summary>
        ///     The shift id
        /// </summary>
        [DataMember(Name = "shiftId")]
        [XmlElement("shiftId")]
        public string ShiftId { get; set; }

        /// <summary>
        ///     The ticket number.
        /// </summary>
        [DataMember(Name = "ticketNumber")]
        [XmlElement("ticketNumber")]
        public string TicketNumber { get; set; }

        #endregion
    }
}