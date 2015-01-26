namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     Contains all of the processor response items
    /// </summary>
    [DataContract(Name = "_processor")]
    public class Processor
    {
        /// <summary>
        ///     A list of messages from the processor
        /// </summary>
        [DataMember(Name = "processorLogs")]
        [XmlArray(ElementName = "processorLogs")]
        [XmlArrayItem(ElementName = "log")]
        public List<string> ProcessorLogs { get; set; }

        /// <summary>
        ///     The processor response. In the case of Express, this is the raw XML returned by the Express platform.
        /// </summary>
        [DataMember(Name = "processorRawResponse")]
        [XmlElement("processorRawResponse")]
        public string ProcessorRawResponse { get; set; }

        /// <summary>
        ///     Reference number of the transaction
        /// </summary>
        [DataMember(Name = "processorReferenceNumber")]
        [XmlElement("processorReferenceNumber")]
        public string ProcessorReferenceNumber { get; set; }

        /// <summary>
        ///     Set to true if the request to the processor has failed
        /// </summary>
        [DataMember(Name = "processorRequestFailed")]
        [XmlElement("processorRequestFailed")]
        public bool ProcessorRequestFailed { get; set; }

        /// <summary>
        ///     Set to true if the sale was approved by the processor
        /// </summary>
        [DataMember(Name = "processorRequestWasApproved")]
        [XmlElement("processorRequestWasApproved")]
        public bool ProcessorRequestWasApproved { get; set; }

        /// <summary>
        ///     The response code received from the processor
        /// </summary>
        [DataMember(Name = "processorResponseCode")]
        [XmlElement("processorResponseCode")]
        public ProcessorResponseCode ProcessorResponseCode { get; set; }

        /// <summary>
        ///     A message sent from the processor
        /// </summary>
        [DataMember(Name = "processorResponseMessage")]
        [XmlElement("processorResponseMessage")]
        public string ProcessorResponseMessage { get; set; }
    }
}