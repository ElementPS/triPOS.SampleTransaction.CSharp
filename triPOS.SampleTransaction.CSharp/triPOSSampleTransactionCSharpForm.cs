// --------------------------------------------------------------------------------------------------------------------
// <copyright file="triPOSSampleTransactionCSharpForm.cs" company="Element Payment Services, Inc., A Vantiv Company">
//   Copyright © 2014 Element Payment Services, Inc., A Vantiv Company. All Rights Reserved.
// </copyright>
// <summary>
//   Defines the triPOSCSharpForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace triPOS.SampleTransaction.CSharp
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using triPOS.SampleTransaction.CSharp.Properties;
    using triPOS.SampleTransaction.CSharp.RequestHeaderFiles;
    using triPOS.SampleTransaction.CSharp.RequestModels;
    using triPOS.SampleTransaction.CSharp.ResponseModels;

    using Formatting = Newtonsoft.Json.Formatting;
    
    public partial class triPOSSampleTransactionCSharpForm : Form
    {
        #region Constants

        /// <summary>
        ///     Message to display when configuration values are empty
        /// </summary>
        private const string EmptyConfig = "Values on config page cannot be empty";

        /// <summary>
        ///     Message to display when the post body is empty
        /// </summary>
        private const string InvalidPostBody = "POST Body must be valid XML or JSON";

        /// <summary>
        ///     String constant for "application/json"
        /// </summary>
        private const string Json = "application/json";

        /// <summary>
        ///     String constant for indicating that a receipt value is null when it is expected to be populated
        /// </summary>
        private const string NullReceiptValue = "A value in the response is null, but it is expected to be populated";

        /// <summary>
        ///     Message to display when triPOS is processing the request
        /// </summary>
        private const string PleaseWait = "Please wait...";

        /// <summary>
        ///     Message to display when the signature status code falls outside of expected values
        /// </summary>
        private const string SignatureStatusCodeNotExpectedValue = "The value returned for SignatureStatusCode is not an expected value";

        /// <summary>
        ///     The file path to the triPOS config
        /// </summary>
        private const string TriPosConfigFilePath = @"C:\Program Files (x86)\Vantiv\TriPOS Service\TriPOS.config";

        /// <summary>
        ///     Message to display when response is unrecognized
        /// </summary>
        private const string UnrecognizedResponse = "Could not recognize the response returned";

        /// <summary>
        ///     Message to display when it is likely that the port number does not match the port number in triPOS.config
        /// </summary>
        private const string VerifyPortNumber = "Verify that the port number above matches the port number in triPOS.config";

        /// <summary>
        ///     String constant for "application/xml"
        /// </summary>
        private const string Xml = "application/xml";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="triPOSCSharpForm" /> class.
        ///     Initialize component
        /// </summary>
        public triPOSSampleTransactionCSharpForm()
        {
            this.InitializeComponent();

            // Set picturebox image to the blank signature line by default
            this.pictureBoxSignature.Image = Resources.SignatureLine;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Clears all of the fields for a blank slate.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void ButtonClearFormClick(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
            }
            catch (Exception ex)
            {
                this.labelException.Text = ex.Message;
            }
        }

        /// <summary>
        ///     Clears the sample data from the input fields.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void ButtonClearTestDataClick(object sender, EventArgs e)
        {
            try
            {
                this.textBoxPostBody.Clear();
            }
            catch (Exception ex)
            {
                this.labelException.Text = ex.Message;
            }
        }

        /// <summary>
        ///     Handler for SendRequest button. Obtains input values, sends request, displays response.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void ButtonSendRequestClick(object sender, EventArgs e)
        {
            // Clear the form from the last request
            this.ClearForm();
            this.labelException.Text = PleaseWait;

            // Get url and post body used for sending requests
            string url = string.Format("http://localhost:{0}/api/v1/sale", this.textBoxPort.Text);
            string postBody = this.textBoxPostBody.Text;
            string contentType = this.DetermineContentType(postBody);

            if (string.IsNullOrEmpty(contentType))
            {
                this.labelException.Text = InvalidPostBody;
                return;
            }

            string actualResponse = string.Empty;
            try
            {
                // Send the request and obtain the response
                HttpResponseMessage response = this.SendRequest(url, postBody, contentType);
                Task<string> readAsync = response.Content.ReadAsStringAsync();
                readAsync.Wait();
                actualResponse = readAsync.Result;
            }
            catch (ObjectDisposedException ex)
            {
                this.labelException.Text = ex.Message;
                return;
            }
            catch (AggregateException)
            {
                this.labelException.Text = VerifyPortNumber;
                return;
            }

            // Deserialize response to response object
            var respObj = new SaleResponse();
            switch (contentType)
            {
                case Xml:
                    try
                    {
                        var ser = new XmlSerializer(typeof(SaleResponse));
                        var reader = new StringReader(actualResponse);
                        respObj = (SaleResponse)ser.Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // This indicates that the repsonse is an error respone that is not the form of a saleResponse. 
                        // If the error occurred within header validation, the response will be in JSON because triPOS has not yet inspected the content type of the request.
                        if (!string.IsNullOrWhiteSpace(actualResponse))
                        {
                            string errorResponseContentType = this.DetermineContentType(actualResponse);

                            if (string.IsNullOrEmpty(errorResponseContentType))
                            {
                                this.labelException.Text = UnrecognizedResponse;
                                this.textBoxResponse.Text = actualResponse;
                                return;
                            }

                            this.textBoxResponse.Text = this.BeautifyResponse(actualResponse, errorResponseContentType);
                            this.labelException.Text = string.Empty;
                            return;
                        }
                    }

                    break;

                case Json:
                    respObj = JsonConvert.DeserializeObject<SaleResponse>(actualResponse);
                    if (respObj.Type.Equals("Unknown"))
                    {
                        if (!string.IsNullOrWhiteSpace(actualResponse))
                        {
                            this.textBoxResponse.Text = JObject.Parse(actualResponse).ToString();
                            this.labelException.Text = string.Empty;
                            return;
                        }
                    }

                    break;
            }

            // Pass the response object along for receipt building
            try
            {
                if (respObj.Errors != null)
                {
                    this.DisplayReceipt(respObj);
                }
            }
            catch (NullReferenceException)
            {
                this.labelException.Text = NullReceiptValue;
                this.labelException.Text = string.Empty;
            }
                
            // Display the response
            try
            {
                this.textBoxResponse.Text = this.BeautifyResponse(actualResponse, contentType);
            }
            catch (InvalidOperationException)
            {
                this.textBoxResponse.Text = actualResponse;
                this.labelException.Text = string.Empty;
                return;
            }
            catch (JsonException)
            {
                this.textBoxResponse.Text = actualResponse;
                this.labelException.Text = string.Empty;
                return;
            }

            // No longer display "Please wait..."
            this.labelException.ResetText();
        }

        /// <summary>
        ///     Based on the content type of the response, this method formats it nicely for being displayed in the response box
        /// </summary>
        /// <param name="actualResponse">
        ///     The actual response returned from triPOS
        /// </param>
        /// <param name="contentType">
        ///     The content type of the response (XML or JSON)
        /// </param>
        /// <returns>
        ///     A nicely formatted string that can be displayed in the response box
        /// </returns>
        private string BeautifyResponse(string actualResponse, string contentType)
        {
            string response = string.Empty;

            switch (contentType)
            {
                case Xml:
                    var stringBuilder = new StringBuilder();
                    var settings = new XmlWriterSettings { Indent = true, IndentChars = "  ", NewLineChars = "\r\n", NewLineHandling = NewLineHandling.Replace };
                    using (var writer = XmlWriter.Create(stringBuilder, settings))
                    {
                        var doc = new XmlDocument();
                        doc.LoadXml(actualResponse);
                        doc.Save(writer);
                    }

                    response = stringBuilder.ToString();
                    break;

                case Json:
                    response = JObject.Parse(actualResponse).ToString();
                    break;
            }

            return response;
        }

        /// <summary>
        ///     Sets the content type based on the first char of the post body.
        /// </summary>
        /// <param name="postBody">
        ///     The request post body
        /// </param>
        /// <returns>
        ///     The content type
        /// </returns>
        private string DetermineContentType(string postBody)
        {
            string contentType = string.Empty;

            if (!string.IsNullOrEmpty(postBody))
            {
                char firstChar = postBody[0];
                switch (firstChar)
                {
                    case '<':
                        contentType = Xml;
                        break;

                    case '{':
                        contentType = Json;
                        break;
                }
            }

            return contentType;
        }

        /// <summary>
        ///     Populates the post body with a sample XML request
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void ButtonTestXmlClick(object sender, EventArgs e)
        {
            try
            {
                // Obtain sample request object
                var request = this.GetSaleRequest();

                // Set UI post body with sample request
                var stringBuilderXml = new StringBuilder();
                var xmlSerializer = new XmlSerializer(typeof(SaleRequest));
                var xmlWriter = XmlWriter.Create(stringBuilderXml, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true });
                xmlSerializer.Serialize(xmlWriter, request);
                this.textBoxPostBody.Text = stringBuilderXml.ToString();
            }
            catch (Exception ex)
            {
                this.labelException.Text = ex.Message;
            }
        }

        /// <summary>
        ///     Populates the post body with a sample JSON request
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void ButtonTestJsonClick(object sender, EventArgs e)
        {
            try
            {
                // Obtain sample request object
                SaleRequest request = this.GetSaleRequest();

                // Set UI post body with sample request
                this.textBoxPostBody.Text = JsonConvert.SerializeObject(request, Formatting.Indented);
            }
            catch (Exception ex)
            {
                this.labelException.Text = ex.Message;
            }
        }

        /// <summary>
        ///     Returns a sample sale request 
        /// </summary>
        /// <returns>
        ///     A sample sale request
        /// </returns>
        private SaleRequest GetSaleRequest()
        {
            var request = new SaleRequest();
            request.Configuration = new Configuration();
            request.Address = new Address();

            request.Address.BillingAddress1 = "123 Sample Street";
            request.Address.BillingAddress2 = "Suite 101";
            request.Address.BillingCity = "Chandler";
            request.Address.BillingState = "AZ";
            request.Address.BillingPostalCode = "85224";

            request.ClerkNumber = "Clerk101";
            request.Configuration.CurrencyCode = "Usd";
            request.EmvFallbackReason = "None";
            request.LaneId = 9999;
            request.Configuration.MarketCode = "Retail";
            request.Configuration.AllowPartialApprovals = false;
            request.Configuration.CheckForDuplicateTransactions = true;
            request.ReferenceNumber = "Ref000001";
            request.ShiftId = "ShiftA";
            request.TicketNumber = "T0000001";
            request.TransactionAmount = 3.25M;

            return request;
        }

        /// <summary>
        ///     Clears the response, request header, and receipt data.
        /// </summary>
        private void ClearForm()
        {
            this.textBoxResponse.Clear();
            this.textBoxRequestHeader.Clear();

            this.labelException.ResetText();
            this.labelReceiptDateTime.ResetText();
            this.labelReceiptTransactionID.ResetText();
            this.labelReceiptTerminalId.ResetText();
            this.labelReceiptStatus.ResetText();
            this.labelReceiptApprovalNumber.ResetText();
            this.labelReceiptAccountNumber.ResetText();
            this.labelReceiptEntryMode.ResetText();
            this.labelReceiptPaymentType.ResetText();
            this.labelReceiptSubtotal.ResetText();
            this.labelReceiptCashBack.ResetText();
            this.labelReceiptTip.ResetText();
            this.labelReceiptTotalAmount.ResetText();
            this.labelReceiptApprovedAmount.ResetText();

            this.pictureBoxSignature.Show();
            this.pictureBoxSignature.Image = Resources.SignatureLine;
        }

        /// <summary>
        ///     Populates the httpClient with signed request headers and the POST body data.
        /// </summary>
        /// <param name="message">
        ///     The http request message.
        /// </param>
        /// <param name="postBody">
        ///     The post body data of the request.
        /// </param>
        /// <param name="contentType">
        ///     Either JSON or XML.
        /// </param>
        /// <param name="developerKey">
        ///     The developer key used to create the signed header.
        /// </param>
        /// <param name="developerSecret">
        ///     The developer secret used to create the signed header.
        /// </param>
        private void CreateRequestHeaders(HttpRequestMessage message, string postBody, string contentType, string developerKey, string developerSecret)
        {
            AuthorizationHeader authorizationHeader = AuthorizationHeader.Create(message.Headers, message.RequestUri, postBody, message.Method.Method, "1.0", "TP-HMAC-SHA1", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("O"), developerKey, developerSecret);

            message.Headers.Add("tp-authorization", authorizationHeader.ToString());
            message.Headers.Add("tp-application-id", "1234");
            message.Headers.Add("tp-application-name", "triPOS.CSharp");
            message.Headers.Add("tp-application-version", "1.0.0");
            message.Headers.Add("tp-return-logs", "false");
            message.Headers.Add("accept", contentType);
            message.Content = new StringContent(postBody, Encoding.UTF8, contentType);
        }

        /// <summary>
        ///     Determines whether or not to display signature, display a blank
        ///     signature line, or display nothing at all.
        /// </summary>
        /// <param name="response">
        ///     The response object
        /// </param>
        private void DetermineSignature(SaleResponse response)
        {
            string signatureStatusCode = response.Signature.SignatureStatusCode;
            
            if (!string.IsNullOrEmpty(signatureStatusCode))
            {
                switch (signatureStatusCode)
                {
                    // Signature required, check for signature data
                    case "SignatureRequired":
                        if (response.Signature.SignatureData != null)
                        {
                            this.DisplaySignature(response);
                        }
                        else
                        {
                            // Signature is required but the response contains no signature data, include blank signature line on receipt 
                            this.DisplaySignatureLine();
                        }

                        break;

                    // Signature present, display it
                    case "SignaturePresent":
                        this.DisplaySignature(response);
                        break;

                    // Signature required, cancelled by cardholder, display signature line
                    case "SignatureRequiredCancelledByCardholder":

                    // Signature required, not supported by PIN pad, display signature line
                    case "SignatureRequiredNotSupportedByPinPad":

                    // Signature required, PIN pad error, display signature line
                    case "SignatureRequiredPinPadError":
                        this.DisplaySignatureLine();
                        break;

                    // Unknown/error, do not display signature or signature line
                    case "Unknown":

                    // Signature not required by threshold amount, do not display signature or signature line
                    case "SignatureNotRequiredByThresholdAmount":

                    // Signature not required by payment type, do not display signature or signature line
                    case "SignatureNotRequiredByPaymentType":

                    // Signature not required by transaction type, do not display signature or signature line
                    case "SignatureNotRequiredByTransactionType":
                        this.pictureBoxSignature.Hide();
                        break;
                    default:
                        this.labelException.Text = SignatureStatusCodeNotExpectedValue;
                        break;
                }
            }
            else
            {
                // No signature came back
                this.pictureBoxSignature.Hide();
            }
        }

        /// <summary>
        ///     Displays the formatted receipt using the receipt data from the response.
        /// </summary>
        /// <param name="response">
        ///     The response object
        /// </param>
        private void DisplayReceipt(SaleResponse response)
        {
            // Set Receipt date time
            string dateTime = response.TransactionDateTime;
            try
            {
                DateTime dt = Convert.ToDateTime(dateTime);
                this.labelReceiptDateTime.Text = dt.ToString("MM/dd/yy hh:mm:ss");
            }
            catch (FormatException)
            {
                this.labelReceiptDateTime.Text = string.Empty;
            }

            // Set Receipt transaction data
            this.labelReceiptTransactionID.Text = response.TransactionId;
            this.labelReceiptTerminalId.Text = response.TerminalId;
            this.labelReceiptStatus.Text = response.StatusCode;
            this.labelReceiptApprovalNumber.Text = response.ApprovalNumber;
            this.labelReceiptAccountNumber.Text = response.AccountNumber;
            this.labelReceiptEntryMode.Text = response.EntryMode;
            this.labelReceiptPaymentType.Text = response.PaymentType;
            this.labelReceiptSubtotal.Text = string.Format("{0:C}", response.SubTotalAmount);
            this.labelReceiptCashBack.Text = string.Format("{0:C}", response.CashbackAmount);
            this.labelReceiptTip.Text = string.Format("{0:C}", response.TipAmount);
            this.labelReceiptTotalAmount.Text = string.Format("{0:C}", response.TotalAmount);
            this.labelReceiptApprovedAmount.Text = string.Format("{0:C}", response.ApprovedAmount);

            // Determine what to display on receipt regarding signature
            this.DetermineSignature(response);
        }

        /// <summary>
        ///     Displays signature image on receipt.
        /// </summary>
        /// <param name="response">
        ///     The response object
        /// </param>
        private void DisplaySignature(SaleResponse response)
        {
            var signature = new SignatureFiles.Signature();
            signature.SetFormat(response.Signature.SignatureFormat);
            byte[] bytes = response.Signature.SignatureData;
            signature.SetData(bytes);

            Bitmap signatureImage = signature.GetSignatureBitmap(10);
            this.pictureBoxSignature.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxSignature.Image = signatureImage;
            this.pictureBoxSignature.Show();
        }

        /// <summary>
        ///     Displays blank signature line on receipt.
        /// </summary>
        private void DisplaySignatureLine()
        {
            this.pictureBoxSignature.Image = Resources.SignatureLine;
        }

        /// <summary>
        ///     Sends the request.
        /// </summary>
        /// <param name="url">
        ///     The url to which to send the request.
        /// </param>
        /// <param name="postBody">
        ///     The post body data processed by endpoint.
        /// </param>
        /// <param name="contentType">
        ///     Either JSON or XML.
        /// </param>
        /// <returns>
        ///     The response message from the endpoint.
        /// </returns>
        private HttpResponseMessage SendRequest(string url, string postBody, string contentType)
        {
            // Obtain developer key and secret from triPOS.config
            var triPosConfig = new XmlDocument();
            triPosConfig.Load(TriPosConfigFilePath);
            
            var developerKeys = triPosConfig.GetElementsByTagName("developerKey");
            string developerKey = developerKeys[0].InnerXml;
            
            var developerSecrets = triPosConfig.GetElementsByTagName("developerSecret");
            string developerSecret = developerSecrets[0].InnerXml;
            
            // Verify that necessary fields are not null
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(developerKey) || string.IsNullOrEmpty(developerSecret))
            {
                throw new Exception(EmptyConfig);
            }

            // Send request
            HttpResponseMessage respMessage = null;
            using (var httpClient = new HttpClient())
            {
                var message = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                this.CreateRequestHeaders(message, postBody, contentType, developerKey, developerSecret);
                this.textBoxRequestHeader.Text = message.Headers.ToString();

                Task<HttpResponseMessage> response = httpClient.SendAsync(message);
                response.Wait();
                respMessage = response.Result;
            }

            return respMessage;
        }

        #endregion
    }
}