namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     The properties of a signature.
    /// </summary>
    [DataContract(Name = "signature")]
    public class Signature
    {
        /// <summary>
        ///     The byte array of the signature in the format specified by Format.
        /// </summary>
        [DataMember(Name = "data")]
        [XmlElement("data")]
        public byte[] SignatureData { get; set; }

        /// <summary>
        ///     The format of the signature
        /// </summary>
        [DataMember(Name = "format")]
        [XmlElement("format")]
        public string SignatureFormat { get; set; }

        /// <summary>
        ///     Indicates why a signature is or is not present
        /// </summary>
        [DataMember(Name = "statusCode")]
        [XmlElement("statusCode")]
        public string SignatureStatusCode { get; set; }
    }
}