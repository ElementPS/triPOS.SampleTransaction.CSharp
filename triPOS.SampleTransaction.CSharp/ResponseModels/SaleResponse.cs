namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     The response returned from a card sale request
    /// </summary>
    [Serializable]
    [XmlRoot("saleResponse", Namespace = "http://tripos.vantiv.com/2014/09/TriPos.Api")]
    [DataContract(Name = "saleResponse")]
    public class SaleResponse
    {
        #region Public Properties

        /// <summary>
        ///     The cashback amount the card holder wants
        /// </summary>
        [DataMember(Name = "cashbackAmount")]
        [XmlElement("cashbackAmount")]
        public decimal CashbackAmount { get; set; }

        /// <summary>
        ///     The surcharge amount that was added to the transaction
        /// </summary>
        [DataMember(Name = "debitSurchargeAmount")]
        [XmlElement("debitSurchargeAmount")]
        public decimal DebitSurchargeAmount { get; set; }

        /// <summary>
        ///     The amount approved by the processor. This is the actual amount that will be charged or credited.
        /// </summary>
        [DataMember(Name = "approvedAmount")]
        [XmlElement("approvedAmount")]
        public decimal ApprovedAmount { get; set; }

        /// <summary>
        ///     The convenience fee added to the transaction
        /// </summary>
        [DataMember(Name = "convenienceFeeAmount")]
        [XmlElement("convenienceFeeAmount")]
        public decimal ConvenienceFeeAmount { get; set; }

        /// <summary>
        ///     The original amount sent for the transaction
        /// </summary>
        [DataMember(Name = "subTotalAmount")]
        [XmlElement("subTotalAmount")]
        public decimal SubTotalAmount { get; set; }

        /// <summary>
        ///     The tip amount added to the transaction
        /// </summary>
        [DataMember(Name = "tipAmount")]
        [XmlElement("tipAmount")]
        public decimal TipAmount { get; set; }

        /// <summary>
        ///     The card account number
        /// </summary>
        [DataMember(Name = "accountNumber")]
        [XmlElement("accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        ///     The BIN entry that matched the account number
        /// </summary>
        [DataMember(Name = "binValue")]
        [XmlElement("binValue")]
        public string BinValue { get; set; }

        /// <summary>
        ///     The card holder name
        /// </summary>
        [DataMember(Name = "cardHolderName")]
        [XmlElement("cardHolderName")]
        public string CardHolderName { get; set; }

        /// <summary>
        ///     The card logo (e.g. Visa, Mastercard, etc)
        /// </summary>
        [DataMember(Name = "cardLogo")]
        [XmlElement("cardLogo")]
        public string CardLogo { get; set; }

        /// <summary>
        ///     The currency code used in the transaction
        /// </summary>
        [DataMember(Name = "currencyCode")]
        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     Description of how card was entered: Keyed, Swiped, Chip
        /// </summary>
        [DataMember(Name = "entryMode")]
        [XmlElement("entryMode")]
        public string EntryMode { get; set; }

        /// <summary>
        ///     Description of how card payment type: None, Credit, Debit
        /// </summary>
        [DataMember(Name = "paymentType")]
        [XmlElement("paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        ///     The signature data
        /// </summary>
        [DataMember(Name = "signature")]
        [XmlElement("signature")]
        public Signature Signature { get; set; }

        /// <summary>
        ///     The ID of the terminal used during the transaction
        /// </summary>
        [DataMember(Name = "terminalId")]
        [XmlElement("terminalId")]
        public string TerminalId { get; set; }

        /// <summary>
        ///     The total amount of the transaction
        /// </summary>
        [DataMember(Name = "totalAmount")]
        [XmlElement("totalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///     Approval number from the processor
        /// </summary>
        [DataMember(Name = "approvalNumber")]
        [XmlElement("approvalNumber")]
        public string ApprovalNumber { get; set; }

        /// <summary>
        ///     Set to true if the overall sale was approved (not declined by the card)
        /// </summary>
        [DataMember(Name = "isApproved")]
        [XmlElement("isApproved")]
        public bool IsApproved { get; set; }

        /// <summary>
        ///     Response information from the processor
        /// </summary>
        [DataMember(Name = "_processor")]
        [XmlElement("_processor")]
        public Processor ProcessorResponse { get; set; }

        /// <summary>
        ///     The status code for the transaction
        /// </summary>
        [DataMember(Name = "statusCode")]
        [XmlElement("statusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        ///     Transaction date/time in ISO8601 format
        /// </summary>
        [DataMember(Name = "transactionDateTime")]
        [XmlElement("transactionDateTime")]
        public string TransactionDateTime { get; set; }

        /// <summary>
        ///     The transaction ID from the processor
        /// </summary>
        [DataMember(Name = "transactionId")]
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        ///     A list of errors that occurred
        /// </summary>
        [DataMember(Name = "_errors")]
        [XmlArray(ElementName = "_errors")]
        [XmlArrayItem(ElementName = "error")]
        public List<ApiError> Errors { get; set; }

        /// <summary>
        ///     Indicates if there are errors
        /// </summary>
        [DataMember(Name = "_hasErrors")]
        [XmlElement("_hasErrors")]
        public bool HasErrors
        {
            get
            {
                return this.Errors != null && this.Errors.Count > 0;
            }

            set
            {
                // Do nothing, but needed for DataContract
            }
        }

        /// <summary>
        ///     Gets or sets the links.
        /// </summary>
        [DataMember(Name = "_links")]
        [XmlArray(ElementName = "_links")]
        [XmlArrayItem(ElementName = "link")]
        public List<ApiLink> Links { get; set; }

        /// <summary>
        ///     A list of log entries detailing what happened during the request. Ideally only used during development or
        ///     troubleshooting as this can be quite verbose.
        /// </summary>
        [DataMember(Name = "_logs")]
        [XmlArray(ElementName = "_logs")]
        [XmlArrayItem(ElementName = "log")]
        public List<string> Logs { get; set; }

        /// <summary>
        ///     The type of object held in the result, if any
        /// </summary>
        [DataMember(Name = "_type")]
        [XmlElement("_type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the warnings.
        /// </summary>
        [DataMember(Name = "_warnings")]
        [XmlArray(ElementName = "_warnings")]
        [XmlArrayItem(ElementName = "warning")]
        public List<ApiWarning> Warnings { get; set; }
        
        #endregion
    }
}