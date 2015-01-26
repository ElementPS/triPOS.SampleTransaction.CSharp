namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     Warnings that occurred during the request.
    /// </summary>
    [DataContract(Name = "warning")]
    public class ApiWarning
    {
        #region Public Properties

        /// <summary>
        ///     A developerMessage of the error
        /// </summary>
        [DataMember(Name = "developerMessage")]
        [XmlElement("developerMessage")]
        public string DeveloperMessage { get; set; }

        /// <summary>
        ///     A developerMessage of the error
        /// </summary>
        [DataMember(Name = "userMessage")]
        [XmlElement("userMessage")]
        public string UserMessage { get; set; }

        #endregion
    }
}