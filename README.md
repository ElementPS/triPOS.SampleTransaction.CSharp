# triPOS.SampleTransaction.CSharp

<a href="https://developer.vantiv.com/?utm_campaign=githubcta&utm_medium=hyperlink&utm_source=github&utm_content=gotquestions">Got questions? Connect with our experts on Worldpay ONE.</a>

<a href="https://developer.vantiv.com/?utm_campaign=githubcta&utm_medium=hyperlink&utm_source=github&utm_content=codingforcommerce">Are you coding for commerce? Connect with our experts on Worldpay ONE.</a>

* Questions?  certification@elementps.com
* **Feature request?** Open an issue.
* Feel like **contributing**?  Submit a pull request.


## Overview

This repository demonstrates an integration to the triPOS product using c#.  The code was compiled and tested using Microsoft Visual Studio Express 2013 for Windows Desktop.  The application itself allows a user to populate a credit sale request in either XML or JSON and then send that request to triPOS for further processing.  The app then uses the information provided in the response to display a receipt image.

![triPOS.CSharp](https://github.com/ElementPS/triPOS.SampleTransaction.CSharp/blob/master/screenshot.PNG)

## Prerequisites

Please contact your Integration Analyst for any questions about the below prerequisites.

* Register and download the triPOS application: https://mft.elementps.com/backend/plugin/Registration/ (once activated, login at https://mft.elementps.com)
* Create Express test account: http://www.elementps.com/Resources/Create-a-Test-Account
* Install and configure triPOS
* Optionally install a hardware peripheral and obtain test cards (but you can be up and running without hardware for testing purposes)
* Currently triPOS is supported on Windows 7

## Documentation/Troubleshooting

* To view the triPOS embedded API documentation point your favorite browser to:  http://localhost:8080/help/ (for a default install).”
* In addition to the help documentation above triPOS writes information to a series of log files located at:  C:\Program Files (x86)\Vantiv\triPOS Service\Logs (for a default install).

## Step 1: Generate a request package

You can either generate an XML request or a JSON request.  This example shows the JSON request.  Also notice that the value in laneId is 9999.  This is the 'null' laneId meaning a transaction will flow through the system without requiring hardware.  All lanes are configured in the triPOS.config file located at:  C:\Program Files (x86)\Vantiv\triPOS Service (if you kept the default installation directory).  If you modify this file make sure to restart the triPOS.NET service in the Services app to read in your latest triPOS.config changes.

```
{
  "address": {
    "BillingAddress1": "123 Sample Street",
    "BillingAddress2": "Suite 101",
    "BillingCity": "Chandler",
    "BillingPostalCode": "85224",
    "BillingState": "AZ"
  },
  "cashbackAmount": 0.0,
  "convenienceFeeAmount": 0.0,
  "emvFallbackReason": "None",
  "tipAmount": 0.0,
  "transactionAmount": 3.25,
  "clerkNumber": "Clerk101",
  "configuration": {
    "allowPartialApprovals": false,
    "checkForDuplicateTransactions": true,
    "currencyCode": "Usd",
    "marketCode": "Retail"
  },
  "laneId": 9999,
  "referenceNumber": "Ref000001",
  "shiftId": "ShiftA",
  "ticketNumber": "T0000001"
}

```

## Step 2:Create message headers

```
AuthorizationHeader authorizationHeader = AuthorizationHeader.Create(message.Headers, message.RequestUri, postBody, message.Method.Method, "1.0", "TP-HMAC-SHA1", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("O"), developerKey, developerSecret);

message.Headers.Add("tp-authorization", authorizationHeader.ToString());
message.Headers.Add("tp-application-id", "1234");
message.Headers.Add("tp-application-name", "SendRequestAndViewReceipt");
message.Headers.Add("tp-application-version", "1.0.0");
message.Headers.Add("tp-return-logs", "false");
message.Headers.Add("accept", contentType);
message.Content = new StringContent(postBody, Encoding.UTF8, contentType);
```

## Step 3: Send request to triPOS

Use any http library to send a request to triPOS which is listening on a local address:  http://localhost:8080/api/v1/sale (if you kept the install default).

```
HttpResponseMessage respMessage = null;
using (var httpClient = new HttpClient())
{
  var message = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
  this.CreateRequestHeaders(message, postBody, contentType, developerKey, developerSecret);
  Task<HttpResponseMessage> response = httpClient.SendAsync(message);
  response.Wait();
  respMessage = response.Result;
}
```

## Step 4: Receive response from triPOS

As stated above the response will be in the same format as the request and therefore we show the JSON format here.


```
{
  "cashbackAmount": 0,
  "debitSurchargeAmount": 0,
  "approvedAmount": 3.25,
  "convenienceFeeAmount": 0,
  "subTotalAmount": 3.25,
  "tipAmount": 0,
  "accountNumber": "400300******6781",
  "binValue": "400300000000",
  "cardHolderName": "GLOBAL PAYMENTS TEST CARD/",
  "cardLogo": "Visa",
  "currencyCode": "Usd",
  "entryMode": "Swiped",
  "paymentType": "Credit",
  "signature": {
    "data": "**[Removed]**",
    "format": "PointsBigEndian",
    "statusCode": "SignaturePresent"
  },
  "terminalId": "0000009999",
  "totalAmount": 3.25,
  "approvalNumber": "000034",
  "isApproved": true,
  "_processor": {
    "processorLogs": [
      "ProcessorResponseCode: **[Removed]**"
    ],
    "processorRawResponse": "**[Removed]**",
    "processorReferenceNumber": "Ref000001",
    "processorRequestFailed": false,
    "processorRequestWasApproved": true,
    "processorResponseCode": "Approved",
    "processorResponseMessage": "Approved"
  },
  "statusCode": "Approved",
  "transactionDateTime": "2015-01-21T14:34:21-08:00",
  "transactionId": "2004243943",
  "_errors": [],
  "_hasErrors": false,
  "_links": [
    {
      "href": "http://localhost:8080/api/v1/sale/2004243943/return/credit",
      "method": "POST",
      "rel": "return"
    }
  ],
  "_logs": [],
  "_type": "saleResponse",
  "_warnings": []
}
```

## Step 5: Parse response data

You may parse the JSON or XML in any manner but one easy way to parse the JSON is to use the JsonConvert.DeserializeObject method (from the Newtonsoft JSON nuget package) which deserializes the textual response from triPOS into an object format that is easier to work with.

```
respObj = JsonConvert.DeserializeObject<SaleResponse>(actualResponse);
```

##### © 2018 Worldpay, LLC and/or its affiliates. All rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Element Payment Services, Inc., a Vantiv company, shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.

![Analytics](https://ga-beacon.appspot.com/UA-60858025-37/triPOS.SampleTransaction.CSharp/readme?pixel)
