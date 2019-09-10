namespace Moneris
{
    using System;
	using System.Net;
	public class TestKountInquiry
	{
		public static void Main(string[] args)
		{
			
			KountInquiry kount_inquiry = new KountInquiry();

			kount_inquiry.SetKountMerchantId("760000"); //6 digit - This is a UNIQUE local identifier used by the merchant to identify the kount inquiry request
			kount_inquiry.SetKountApiKey("mykey"); //214 character max - This is a UNIQUE local identifier used by the merchant to identify the kount inquiry request
			kount_inquiry.SetOrderId("nqa-orderidkount-1"); //64 characters max - This is a UNIQUE local identifier used by the merchant to identify the transaction e.g. purchase order number.
			kount_inquiry.SetCallCenterInd("N"); //Y or N - Risk Inquiry originating from call center environment
			kount_inquiry.SetCurrency("CAD"); //country of currency submitted on order
			kount_inquiry.SetEmail("test@gmail.com"); //email address submitted by the customer
			kount_inquiry.SetDataKey("ak84nklcma9Khdg1"); //token from moneris vault service to represent pan if previously tokenized
			kount_inquiry.SetCustomerId("NQA"); //Merchant assigned account number for consumer
			kount_inquiry.SetAutoNumberId("NQA-X1"); //Automatic Number Identification (ANI) submitted with order
			kount_inquiry.SetFinancialOrderId("nqa-fin-orderid-1"); //64 characters max - This is a local identifier used by the merchant to identify the transaction e.g. purchase order number.
			kount_inquiry.SetPaymentToken("4242424242424242"); //payment token submitted by merchant (ie: credit card, payer ID)
															   /*	Payment Type Must be one of the following values:
																   APAY-�Apple Pay
																   CARD-�Credit Card
																   PYPL-�PayPal
																   NONE-�None
																   GOOG-�Google Checkout
																   GIFT-�Gift Card
																   INTERAC-�Interac
																   CHEK - Check
																   GDMP - Green Dot Money Pack
																   BLML - Bill Me Later
																   BPAY - BPAY
																   NETELLER - Neteller
																   GIROPAY - GiroPay
																   ELV - ELV
																   MERCADE_PAGO - Mercade Pago
																   SEPA - Single Euro Payments Area
																   CARTE_BLEUE - Carte Bleue
																   POLI - POLi
																   Skrill/Moneybookers - SKRILL
																   SOFORT - Sofort
															   */
			kount_inquiry.SetPaymentType("CARD"); //payment type submitted by merchant
			kount_inquiry.SetIpAddress("192.168.2.1"); //Dotted Decimal IPv4 address that the merchant sees coming from the customer
			kount_inquiry.SetSessionId("xjudq804i1049jkjakdad"); //unique session id.  Must be unique over a 30-day span
			kount_inquiry.SetWebsiteId("DEFAULT");
			kount_inquiry.SetAmount("100"); //Transaction amount This must contain at least 3 digits, two of which are penny values
			kount_inquiry.SetPaymentResponse("A"); //A - Authorized, D - Declined - payment transaction response
			kount_inquiry.SetAvsResponse("M"); //M - Match, N - No Match - avs verification response returned from payment request. This can be provided should kount_inquiry be performed after the transaction is complete
			kount_inquiry.SetCvdResponse("M"); //M - Match, N - No Match, X - Unsupported/Unavailable - cvd response returned to merchant from processor. This can be provided should kount_inquiry be performed after the transaction is complete
			kount_inquiry.SetBillStreet1("3300 Bloor Street"); //billing street address line 1
			kount_inquiry.SetBillStreet2("West Tower"); //billing street address line 2
			kount_inquiry.SetBillCountry("CA"); //2 character - billing country code
			kount_inquiry.SetBillCity("Toronto"); //billing address city
			kount_inquiry.SetBillPostalCode("M8X2X2"); //billing address postal code
			kount_inquiry.SetBillPhone("4167341000"); //billing phone number
			kount_inquiry.SetBillProvince("ON"); //billing address province
			kount_inquiry.SetDob("1950-11-12"); //YYYY-MM-DD
			kount_inquiry.SetEpoc("1491783223"); //timestamp expressed as seconds from epoch
			kount_inquiry.SetGender("M"); //M - Male or F - Female
			kount_inquiry.SetLast4("4242"); //last 4 digits of credit card value
			kount_inquiry.SetCustomerName("Moneris Test"); //customer name submitted with the order
			kount_inquiry.SetShipStreet1("3200 Bloor Street"); //shipping street address line 1
			kount_inquiry.SetShipStreet2("East Tower"); //shipping street address line 2
			kount_inquiry.SetShipCountry("CA"); //2 digit - shipping country code
			kount_inquiry.SetShipCity("Toronto"); //shipping address city
			kount_inquiry.SetShipEmail("test@gmail.com"); //email of recipient
			kount_inquiry.SetShipName("Moneris Test"); //name of recipient
			kount_inquiry.SetShipPostalCode("M8X2X3"); //shipping address postal code
			kount_inquiry.SetShipPhone("4167341001"); //ship-to phone number
			kount_inquiry.SetShipProvince("ON"); //shipping address province
			kount_inquiry.SetShipType("ST"); //Same Day = SD, Next Day = ND, Second Day = 2D, Standard = ST

			//Product Details - item number, product_type, product_item (SKU), product_description, product quatity, product_price
			//1-25 products can be added - must be in sequence starting with 1
			kount_inquiry.SetProduct(1, "Phone", "XM9731S", "iPhone 7", "1", "100");
			kount_inquiry.SetProduct(2, "Phone", "YM9731R", "iPhone 6", "1", "100");

			//Local Attributes - 255 character max each,These attributes can be used to pass custom attribute data. These are used if you wish to correlate some data with the returned response via kount
			//1-25 of these can be submitted in one request - must be in sequence starting with 1
			kount_inquiry.SetUdfField("local_custom_1", "iPhone 7");
			kount_inquiry.SetUdf();

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetProcCountryCode("CA");
			mpgReq.SetStoreId("intuit_sped");
			mpgReq.SetApiToken("spedguy");
			mpgReq.SetTestMode(true);
			mpgReq.SetTransaction(kount_inquiry);
			mpgReq.Send();

			try
			{
				Receipt receipt = mpgReq.GetReceipt();
				Console.WriteLine("Response Code = " + receipt.GetResponseCode());
				Console.WriteLine("Receipt Id = " + receipt.GetReceiptId());
				Console.WriteLine("Message = " + receipt.GetMessage());
				Console.WriteLine("Kount Transaction Id = " + receipt.GetKountTransactionId());
				Console.WriteLine("Kount Result = " + receipt.GetKountResult());
				Console.WriteLine("Kount Score = " + receipt.GetKountScore());
				Console.WriteLine("Kount info = " + receipt.GetKountInfo());
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} // end TestKountInquiry
}
