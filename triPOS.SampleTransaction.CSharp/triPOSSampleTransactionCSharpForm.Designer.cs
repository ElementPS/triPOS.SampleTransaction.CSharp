namespace triPOS.SampleTransaction.CSharp
{
    partial class triPOSSampleTransactionCSharpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabPageReceiptViewer = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxRequestHeader = new System.Windows.Forms.TextBox();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.textBoxPostBody = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.buttonTestJsonButton = new System.Windows.Forms.Button();
            this.buttonClearTestData = new System.Windows.Forms.Button();
            this.buttonTestXmlButton = new System.Windows.Forms.Button();
            this.buttonClearForm = new System.Windows.Forms.Button();
            this.labelException = new System.Windows.Forms.Label();
            this.labelHeaders = new System.Windows.Forms.Label();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.labelResponse = new System.Windows.Forms.Label();
            this.labelPostBody = new System.Windows.Forms.Label();
            this.groupBoxReceipt = new System.Windows.Forms.GroupBox();
            this.labelReceiptTerminalId = new System.Windows.Forms.Label();
            this.labelReceiptTerminalIdLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxSignature = new System.Windows.Forms.PictureBox();
            this.labelReceiptApprovedAmount = new System.Windows.Forms.Label();
            this.labelReceiptApprovedAmountLabel = new System.Windows.Forms.Label();
            this.labelReceiptTotalAmount = new System.Windows.Forms.Label();
            this.labelReceiptTotalAmountLabel = new System.Windows.Forms.Label();
            this.labelReceiptTip = new System.Windows.Forms.Label();
            this.labelReceiptTipLabel = new System.Windows.Forms.Label();
            this.labelReceiptCashBack = new System.Windows.Forms.Label();
            this.labelReceiptCashBackLabel = new System.Windows.Forms.Label();
            this.labelReceiptSubtotal = new System.Windows.Forms.Label();
            this.labelReceiptSubtotalLabel = new System.Windows.Forms.Label();
            this.labelReceiptPaymentType = new System.Windows.Forms.Label();
            this.labelReceiptPaymentTypeLabel = new System.Windows.Forms.Label();
            this.labelReceiptEntryMode = new System.Windows.Forms.Label();
            this.labelReceiptEntryModeLabel = new System.Windows.Forms.Label();
            this.labelReceiptAccountNumber = new System.Windows.Forms.Label();
            this.labelReceiptAccountNumberLabel = new System.Windows.Forms.Label();
            this.labelReceiptApprovalNumber = new System.Windows.Forms.Label();
            this.labelReceiptStatus = new System.Windows.Forms.Label();
            this.labelReceiptTransactionID = new System.Windows.Forms.Label();
            this.labelReceiptTransactionIDLabel = new System.Windows.Forms.Label();
            this.labelReceiptDateTime = new System.Windows.Forms.Label();
            this.labelReceiptStoreName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageReceiptViewer.SuspendLayout();
            this.groupBoxReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSignature)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(394, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(167, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "triPOS Integration";
            // 
            // tabPageReceiptViewer
            // 
            this.tabPageReceiptViewer.Controls.Add(this.label5);
            this.tabPageReceiptViewer.Controls.Add(this.textBoxPort);
            this.tabPageReceiptViewer.Controls.Add(this.textBoxRequestHeader);
            this.tabPageReceiptViewer.Controls.Add(this.textBoxResponse);
            this.tabPageReceiptViewer.Controls.Add(this.textBoxPostBody);
            this.tabPageReceiptViewer.Controls.Add(this.labelUrl);
            this.tabPageReceiptViewer.Controls.Add(this.buttonTestJsonButton);
            this.tabPageReceiptViewer.Controls.Add(this.buttonClearTestData);
            this.tabPageReceiptViewer.Controls.Add(this.buttonTestXmlButton);
            this.tabPageReceiptViewer.Controls.Add(this.buttonClearForm);
            this.tabPageReceiptViewer.Controls.Add(this.labelException);
            this.tabPageReceiptViewer.Controls.Add(this.labelHeaders);
            this.tabPageReceiptViewer.Controls.Add(this.buttonSendRequest);
            this.tabPageReceiptViewer.Controls.Add(this.labelResponse);
            this.tabPageReceiptViewer.Controls.Add(this.labelPostBody);
            this.tabPageReceiptViewer.Controls.Add(this.groupBoxReceipt);
            this.tabPageReceiptViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageReceiptViewer.Name = "tabPageReceiptViewer";
            this.tabPageReceiptViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReceiptViewer.Size = new System.Drawing.Size(933, 669);
            this.tabPageReceiptViewer.TabIndex = 0;
            this.tabPageReceiptViewer.Text = "Request/Response Viewer";
            this.tabPageReceiptViewer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "/api/v1/sale";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(134, 30);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(46, 20);
            this.textBoxPort.TabIndex = 12;
            this.textBoxPort.Text = "8080";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxRequestHeader
            // 
            this.textBoxRequestHeader.Location = new System.Drawing.Point(528, 492);
            this.textBoxRequestHeader.Multiline = true;
            this.textBoxRequestHeader.Name = "textBoxRequestHeader";
            this.textBoxRequestHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRequestHeader.Size = new System.Drawing.Size(384, 135);
            this.textBoxRequestHeader.TabIndex = 6;
            this.textBoxRequestHeader.WordWrap = false;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(28, 390);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResponse.Size = new System.Drawing.Size(481, 237);
            this.textBoxResponse.TabIndex = 3;
            this.textBoxResponse.WordWrap = false;
            // 
            // textBoxPostBody
            // 
            this.textBoxPostBody.Location = new System.Drawing.Point(28, 69);
            this.textBoxPostBody.Multiline = true;
            this.textBoxPostBody.Name = "textBoxPostBody";
            this.textBoxPostBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPostBody.Size = new System.Drawing.Size(481, 241);
            this.textBoxPostBody.TabIndex = 1;
            this.textBoxPostBody.WordWrap = false;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUrl.Location = new System.Drawing.Point(25, 32);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(111, 13);
            this.labelUrl.TabIndex = 11;
            this.labelUrl.Text = "URL: http://localhost:";
            // 
            // buttonTestJsonButton
            // 
            this.buttonTestJsonButton.Location = new System.Drawing.Point(28, 337);
            this.buttonTestJsonButton.Name = "buttonTestJsonButton";
            this.buttonTestJsonButton.Size = new System.Drawing.Size(162, 23);
            this.buttonTestJsonButton.TabIndex = 10;
            this.buttonTestJsonButton.Text = "Populate Sample JSON Body";
            this.buttonTestJsonButton.UseVisualStyleBackColor = true;
            this.buttonTestJsonButton.Click += new System.EventHandler(this.ButtonTestJsonClick);
            // 
            // buttonClearTestData
            // 
            this.buttonClearTestData.Location = new System.Drawing.Point(201, 316);
            this.buttonClearTestData.Name = "buttonClearTestData";
            this.buttonClearTestData.Size = new System.Drawing.Size(135, 23);
            this.buttonClearTestData.TabIndex = 9;
            this.buttonClearTestData.Text = "Clear Sample Data";
            this.buttonClearTestData.UseVisualStyleBackColor = true;
            this.buttonClearTestData.Click += new System.EventHandler(this.ButtonClearTestDataClick);
            // 
            // buttonTestXmlButton
            // 
            this.buttonTestXmlButton.Location = new System.Drawing.Point(28, 316);
            this.buttonTestXmlButton.Name = "buttonTestXmlButton";
            this.buttonTestXmlButton.Size = new System.Drawing.Size(162, 23);
            this.buttonTestXmlButton.TabIndex = 3;
            this.buttonTestXmlButton.Text = "Populate Sample XML Body";
            this.buttonTestXmlButton.UseVisualStyleBackColor = true;
            this.buttonTestXmlButton.Click += new System.EventHandler(this.ButtonTestXmlClick);
            // 
            // buttonClearForm
            // 
            this.buttonClearForm.Location = new System.Drawing.Point(201, 337);
            this.buttonClearForm.Name = "buttonClearForm";
            this.buttonClearForm.Size = new System.Drawing.Size(135, 23);
            this.buttonClearForm.TabIndex = 8;
            this.buttonClearForm.Text = "Clear Response Data";
            this.buttonClearForm.UseVisualStyleBackColor = true;
            this.buttonClearForm.Click += new System.EventHandler(this.ButtonClearFormClick);
            // 
            // labelException
            // 
            this.labelException.AutoSize = true;
            this.labelException.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelException.Location = new System.Drawing.Point(28, 630);
            this.labelException.Name = "labelException";
            this.labelException.Size = new System.Drawing.Size(0, 20);
            this.labelException.TabIndex = 7;
            // 
            // labelHeaders
            // 
            this.labelHeaders.AutoSize = true;
            this.labelHeaders.Location = new System.Drawing.Point(525, 476);
            this.labelHeaders.Name = "labelHeaders";
            this.labelHeaders.Size = new System.Drawing.Size(116, 13);
            this.labelHeaders.TabIndex = 0;
            this.labelHeaders.Text = "Request Header Sent: ";
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Location = new System.Drawing.Point(380, 326);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(129, 23);
            this.buttonSendRequest.TabIndex = 4;
            this.buttonSendRequest.Text = "Send Request";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.ButtonSendRequestClick);
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(29, 374);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(61, 13);
            this.labelResponse.TabIndex = 2;
            this.labelResponse.Text = "Response: ";
            // 
            // labelPostBody
            // 
            this.labelPostBody.AutoSize = true;
            this.labelPostBody.Location = new System.Drawing.Point(25, 53);
            this.labelPostBody.Name = "labelPostBody";
            this.labelPostBody.Size = new System.Drawing.Size(140, 13);
            this.labelPostBody.TabIndex = 0;
            this.labelPostBody.Text = "POST Body (XML or JSON):";
            // 
            // groupBoxReceipt
            // 
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTerminalId);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTerminalIdLabel);
            this.groupBoxReceipt.Controls.Add(this.label6);
            this.groupBoxReceipt.Controls.Add(this.label4);
            this.groupBoxReceipt.Controls.Add(this.label3);
            this.groupBoxReceipt.Controls.Add(this.label2);
            this.groupBoxReceipt.Controls.Add(this.label1);
            this.groupBoxReceipt.Controls.Add(this.pictureBoxSignature);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptApprovedAmount);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptApprovedAmountLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTotalAmount);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTotalAmountLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTip);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTipLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptCashBack);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptCashBackLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptSubtotal);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptSubtotalLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptPaymentType);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptPaymentTypeLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptEntryMode);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptEntryModeLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptAccountNumber);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptAccountNumberLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptApprovalNumber);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptStatus);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTransactionID);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptTransactionIDLabel);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptDateTime);
            this.groupBoxReceipt.Controls.Add(this.labelReceiptStoreName);
            this.groupBoxReceipt.Location = new System.Drawing.Point(578, 15);
            this.groupBoxReceipt.Name = "groupBoxReceipt";
            this.groupBoxReceipt.Size = new System.Drawing.Size(283, 445);
            this.groupBoxReceipt.TabIndex = 0;
            this.groupBoxReceipt.TabStop = false;
            // 
            // labelReceiptTerminalId
            // 
            this.labelReceiptTerminalId.AutoSize = true;
            this.labelReceiptTerminalId.Location = new System.Drawing.Point(103, 167);
            this.labelReceiptTerminalId.Name = "labelReceiptTerminalId";
            this.labelReceiptTerminalId.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptTerminalId.TabIndex = 41;
            // 
            // labelReceiptTerminalIdLabel
            // 
            this.labelReceiptTerminalIdLabel.AutoSize = true;
            this.labelReceiptTerminalIdLabel.Location = new System.Drawing.Point(21, 167);
            this.labelReceiptTerminalIdLabel.Name = "labelReceiptTerminalIdLabel";
            this.labelReceiptTerminalIdLabel.Size = new System.Drawing.Size(64, 13);
            this.labelReceiptTerminalIdLabel.TabIndex = 40;
            this.labelReceiptTerminalIdLabel.Text = "TerminalID: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Auth.#:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "602-555-1212";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Phoenix, AZ 85201";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "123 N 4th Street";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "ElementPS Test Merchant";
            // 
            // pictureBoxSignature
            // 
            this.pictureBoxSignature.Location = new System.Drawing.Point(24, 366);
            this.pictureBoxSignature.Name = "pictureBoxSignature";
            this.pictureBoxSignature.Size = new System.Drawing.Size(233, 70);
            this.pictureBoxSignature.TabIndex = 34;
            this.pictureBoxSignature.TabStop = false;
            // 
            // labelReceiptApprovedAmount
            // 
            this.labelReceiptApprovedAmount.AutoSize = true;
            this.labelReceiptApprovedAmount.Location = new System.Drawing.Point(124, 329);
            this.labelReceiptApprovedAmount.Name = "labelReceiptApprovedAmount";
            this.labelReceiptApprovedAmount.Size = new System.Drawing.Size(13, 13);
            this.labelReceiptApprovedAmount.TabIndex = 33;
            this.labelReceiptApprovedAmount.Text = "$";
            // 
            // labelReceiptApprovedAmountLabel
            // 
            this.labelReceiptApprovedAmountLabel.AutoSize = true;
            this.labelReceiptApprovedAmountLabel.Location = new System.Drawing.Point(21, 329);
            this.labelReceiptApprovedAmountLabel.Name = "labelReceiptApprovedAmountLabel";
            this.labelReceiptApprovedAmountLabel.Size = new System.Drawing.Size(98, 13);
            this.labelReceiptApprovedAmountLabel.TabIndex = 32;
            this.labelReceiptApprovedAmountLabel.Text = "Approved Amount: ";
            // 
            // labelReceiptTotalAmount
            // 
            this.labelReceiptTotalAmount.AutoSize = true;
            this.labelReceiptTotalAmount.Location = new System.Drawing.Point(124, 312);
            this.labelReceiptTotalAmount.Name = "labelReceiptTotalAmount";
            this.labelReceiptTotalAmount.Size = new System.Drawing.Size(13, 13);
            this.labelReceiptTotalAmount.TabIndex = 31;
            this.labelReceiptTotalAmount.Text = "$";
            // 
            // labelReceiptTotalAmountLabel
            // 
            this.labelReceiptTotalAmountLabel.AutoSize = true;
            this.labelReceiptTotalAmountLabel.Location = new System.Drawing.Point(21, 312);
            this.labelReceiptTotalAmountLabel.Name = "labelReceiptTotalAmountLabel";
            this.labelReceiptTotalAmountLabel.Size = new System.Drawing.Size(76, 13);
            this.labelReceiptTotalAmountLabel.TabIndex = 30;
            this.labelReceiptTotalAmountLabel.Text = "Total Amount: ";
            // 
            // labelReceiptTip
            // 
            this.labelReceiptTip.AutoSize = true;
            this.labelReceiptTip.Location = new System.Drawing.Point(124, 295);
            this.labelReceiptTip.Name = "labelReceiptTip";
            this.labelReceiptTip.Size = new System.Drawing.Size(13, 13);
            this.labelReceiptTip.TabIndex = 29;
            this.labelReceiptTip.Text = "$";
            // 
            // labelReceiptTipLabel
            // 
            this.labelReceiptTipLabel.AutoSize = true;
            this.labelReceiptTipLabel.Location = new System.Drawing.Point(21, 295);
            this.labelReceiptTipLabel.Name = "labelReceiptTipLabel";
            this.labelReceiptTipLabel.Size = new System.Drawing.Size(28, 13);
            this.labelReceiptTipLabel.TabIndex = 28;
            this.labelReceiptTipLabel.Text = "Tip: ";
            // 
            // labelReceiptCashBack
            // 
            this.labelReceiptCashBack.AutoSize = true;
            this.labelReceiptCashBack.Location = new System.Drawing.Point(124, 278);
            this.labelReceiptCashBack.Name = "labelReceiptCashBack";
            this.labelReceiptCashBack.Size = new System.Drawing.Size(13, 13);
            this.labelReceiptCashBack.TabIndex = 27;
            this.labelReceiptCashBack.Text = "$";
            // 
            // labelReceiptCashBackLabel
            // 
            this.labelReceiptCashBackLabel.AutoSize = true;
            this.labelReceiptCashBackLabel.Location = new System.Drawing.Point(21, 278);
            this.labelReceiptCashBackLabel.Name = "labelReceiptCashBackLabel";
            this.labelReceiptCashBackLabel.Size = new System.Drawing.Size(65, 13);
            this.labelReceiptCashBackLabel.TabIndex = 26;
            this.labelReceiptCashBackLabel.Text = "Cash Back: ";
            // 
            // labelReceiptSubtotal
            // 
            this.labelReceiptSubtotal.AutoSize = true;
            this.labelReceiptSubtotal.Location = new System.Drawing.Point(124, 260);
            this.labelReceiptSubtotal.Name = "labelReceiptSubtotal";
            this.labelReceiptSubtotal.Size = new System.Drawing.Size(13, 13);
            this.labelReceiptSubtotal.TabIndex = 25;
            this.labelReceiptSubtotal.Text = "$";
            // 
            // labelReceiptSubtotalLabel
            // 
            this.labelReceiptSubtotalLabel.AutoSize = true;
            this.labelReceiptSubtotalLabel.Location = new System.Drawing.Point(21, 261);
            this.labelReceiptSubtotalLabel.Name = "labelReceiptSubtotalLabel";
            this.labelReceiptSubtotalLabel.Size = new System.Drawing.Size(52, 13);
            this.labelReceiptSubtotalLabel.TabIndex = 24;
            this.labelReceiptSubtotalLabel.Text = "Subtotal: ";
            // 
            // labelReceiptPaymentType
            // 
            this.labelReceiptPaymentType.AutoSize = true;
            this.labelReceiptPaymentType.Location = new System.Drawing.Point(103, 198);
            this.labelReceiptPaymentType.Name = "labelReceiptPaymentType";
            this.labelReceiptPaymentType.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptPaymentType.TabIndex = 23;
            // 
            // labelReceiptPaymentTypeLabel
            // 
            this.labelReceiptPaymentTypeLabel.AutoSize = true;
            this.labelReceiptPaymentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiptPaymentTypeLabel.Location = new System.Drawing.Point(22, 197);
            this.labelReceiptPaymentTypeLabel.Name = "labelReceiptPaymentTypeLabel";
            this.labelReceiptPaymentTypeLabel.Size = new System.Drawing.Size(81, 13);
            this.labelReceiptPaymentTypeLabel.TabIndex = 22;
            this.labelReceiptPaymentTypeLabel.Text = "Payment Type: ";
            // 
            // labelReceiptEntryMode
            // 
            this.labelReceiptEntryMode.AutoSize = true;
            this.labelReceiptEntryMode.Location = new System.Drawing.Point(103, 214);
            this.labelReceiptEntryMode.Name = "labelReceiptEntryMode";
            this.labelReceiptEntryMode.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptEntryMode.TabIndex = 21;
            // 
            // labelReceiptEntryModeLabel
            // 
            this.labelReceiptEntryModeLabel.AutoSize = true;
            this.labelReceiptEntryModeLabel.Location = new System.Drawing.Point(22, 213);
            this.labelReceiptEntryModeLabel.Name = "labelReceiptEntryModeLabel";
            this.labelReceiptEntryModeLabel.Size = new System.Drawing.Size(64, 13);
            this.labelReceiptEntryModeLabel.TabIndex = 20;
            this.labelReceiptEntryModeLabel.Text = "Entry Mode:";
            // 
            // labelReceiptAccountNumber
            // 
            this.labelReceiptAccountNumber.AutoSize = true;
            this.labelReceiptAccountNumber.Location = new System.Drawing.Point(103, 182);
            this.labelReceiptAccountNumber.Name = "labelReceiptAccountNumber";
            this.labelReceiptAccountNumber.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptAccountNumber.TabIndex = 19;
            // 
            // labelReceiptAccountNumberLabel
            // 
            this.labelReceiptAccountNumberLabel.AutoSize = true;
            this.labelReceiptAccountNumberLabel.Location = new System.Drawing.Point(22, 181);
            this.labelReceiptAccountNumberLabel.Name = "labelReceiptAccountNumberLabel";
            this.labelReceiptAccountNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.labelReceiptAccountNumberLabel.TabIndex = 18;
            this.labelReceiptAccountNumberLabel.Text = "Card: ";
            // 
            // labelReceiptApprovalNumber
            // 
            this.labelReceiptApprovalNumber.AutoSize = true;
            this.labelReceiptApprovalNumber.Location = new System.Drawing.Point(70, 345);
            this.labelReceiptApprovalNumber.Name = "labelReceiptApprovalNumber";
            this.labelReceiptApprovalNumber.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptApprovalNumber.TabIndex = 14;
            // 
            // labelReceiptStatus
            // 
            this.labelReceiptStatus.AutoSize = true;
            this.labelReceiptStatus.Location = new System.Drawing.Point(118, 242);
            this.labelReceiptStatus.Name = "labelReceiptStatus";
            this.labelReceiptStatus.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptStatus.TabIndex = 12;
            // 
            // labelReceiptTransactionID
            // 
            this.labelReceiptTransactionID.AutoSize = true;
            this.labelReceiptTransactionID.Location = new System.Drawing.Point(103, 153);
            this.labelReceiptTransactionID.Name = "labelReceiptTransactionID";
            this.labelReceiptTransactionID.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptTransactionID.TabIndex = 10;
            // 
            // labelReceiptTransactionIDLabel
            // 
            this.labelReceiptTransactionIDLabel.AutoSize = true;
            this.labelReceiptTransactionIDLabel.Location = new System.Drawing.Point(21, 152);
            this.labelReceiptTransactionIDLabel.Name = "labelReceiptTransactionIDLabel";
            this.labelReceiptTransactionIDLabel.Size = new System.Drawing.Size(80, 13);
            this.labelReceiptTransactionIDLabel.TabIndex = 9;
            this.labelReceiptTransactionIDLabel.Text = "TransactionID: ";
            // 
            // labelReceiptDateTime
            // 
            this.labelReceiptDateTime.AutoSize = true;
            this.labelReceiptDateTime.Location = new System.Drawing.Point(98, 114);
            this.labelReceiptDateTime.Name = "labelReceiptDateTime";
            this.labelReceiptDateTime.Size = new System.Drawing.Size(0, 13);
            this.labelReceiptDateTime.TabIndex = 8;
            // 
            // labelReceiptStoreName
            // 
            this.labelReceiptStoreName.AutoSize = true;
            this.labelReceiptStoreName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelReceiptStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiptStoreName.Location = new System.Drawing.Point(67, 16);
            this.labelReceiptStoreName.Name = "labelReceiptStoreName";
            this.labelReceiptStoreName.Size = new System.Drawing.Size(155, 16);
            this.labelReceiptStoreName.TabIndex = 7;
            this.labelReceiptStoreName.Text = "SAMPLE PURCHASE";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageReceiptViewer);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 695);
            this.tabControl1.TabIndex = 1;
            // 
            // triPOSSampleTransactionCSharpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 742);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTitle);
            this.Name = "triPOSSampleTransactionCSharpForm";
            this.Text = "triPOS.SampleTransaction.CSharp";
            this.tabPageReceiptViewer.ResumeLayout(false);
            this.tabPageReceiptViewer.PerformLayout();
            this.groupBoxReceipt.ResumeLayout(false);
            this.groupBoxReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSignature)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabPage tabPageReceiptViewer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxRequestHeader;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.TextBox textBoxPostBody;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.Button buttonTestJsonButton;
        private System.Windows.Forms.Button buttonClearTestData;
        private System.Windows.Forms.Button buttonTestXmlButton;
        private System.Windows.Forms.Button buttonClearForm;
        private System.Windows.Forms.Label labelException;
        private System.Windows.Forms.Label labelHeaders;
        private System.Windows.Forms.Button buttonSendRequest;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Label labelPostBody;
        private System.Windows.Forms.GroupBox groupBoxReceipt;
        private System.Windows.Forms.Label labelReceiptTerminalId;
        private System.Windows.Forms.Label labelReceiptTerminalIdLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxSignature;
        private System.Windows.Forms.Label labelReceiptApprovedAmount;
        private System.Windows.Forms.Label labelReceiptApprovedAmountLabel;
        private System.Windows.Forms.Label labelReceiptTotalAmount;
        private System.Windows.Forms.Label labelReceiptTotalAmountLabel;
        private System.Windows.Forms.Label labelReceiptTip;
        private System.Windows.Forms.Label labelReceiptTipLabel;
        private System.Windows.Forms.Label labelReceiptCashBack;
        private System.Windows.Forms.Label labelReceiptCashBackLabel;
        private System.Windows.Forms.Label labelReceiptSubtotal;
        private System.Windows.Forms.Label labelReceiptSubtotalLabel;
        private System.Windows.Forms.Label labelReceiptPaymentType;
        private System.Windows.Forms.Label labelReceiptPaymentTypeLabel;
        private System.Windows.Forms.Label labelReceiptEntryMode;
        private System.Windows.Forms.Label labelReceiptEntryModeLabel;
        private System.Windows.Forms.Label labelReceiptAccountNumber;
        private System.Windows.Forms.Label labelReceiptAccountNumberLabel;
        private System.Windows.Forms.Label labelReceiptApprovalNumber;
        private System.Windows.Forms.Label labelReceiptStatus;
        private System.Windows.Forms.Label labelReceiptTransactionID;
        private System.Windows.Forms.Label labelReceiptTransactionIDLabel;
        private System.Windows.Forms.Label labelReceiptDateTime;
        private System.Windows.Forms.Label labelReceiptStoreName;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

