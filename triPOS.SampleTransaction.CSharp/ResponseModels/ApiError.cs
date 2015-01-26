namespace triPOS.SampleTransaction.CSharp.ResponseModels
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    ///     Errors that occurred during the request.
    /// </summary>
    [DataContract(Name = "error")]
    public class ApiError
    {
        #region Public Properties

        /// <summary>
        ///     A developerMessage of the error
        /// </summary>
        [DataMember(Name = "userMessage")]
        [XmlElement("userMessage")]
        public string UserMessage { get; set; }

        /// <summary>
        ///     A developerMessage of the error
        /// </summary>
        [DataMember(Name = "developerMessage")]
        [XmlElement("developerMessage")]
        public string DeveloperMessage { get; set; }
     
        /// <summary>
        ///     Code associated with the error if it exists
        /// </summary>
        [DataMember(Name = "errorType")]
        [XmlElement("errorType")]
        public string ErrorType { get; set; }

        /// <summary>
        ///     The body of the exception message.
        /// </summary>
        [DataMember(Name = "exceptionMessage")]
        [XmlElement("exceptionMessage")]
        public string ExceptionMessage { get; set; }

        /// <summary>
        ///     The full name of the exception
        /// </summary>
        [DataMember(Name = "exceptionTypeFullName")]
        [XmlElement("exceptionTypeFullName")]
        public string ExceptionTypeFullName { get; set; }

        /// <summary>
        ///     The short name of the exception
        /// </summary>
        [DataMember(Name = "exceptionTypeShortName")]
        [XmlElement("exceptionTypeShortName")]
        public string ExceptionTypeShortName { get; set; }

        #endregion
    }
}