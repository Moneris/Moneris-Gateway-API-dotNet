namespace Moneris
{
    using System;
	public class TestKountUpdate
	{
		public static void Main(string[] args)
		{
			KountUpdate kount_update = new KountUpdate();

			kount_update.SetKountTransactionId("PHKH0QSYJN50"); //kount transaction ID number that is returned in the response of a kount_inquiry request
			kount_update.SetKountMerchantId("760000"); //6 digit - This is a UNIQUE local identifier used by the merchant to identify the kount inquiry request
			kount_update.SetKountApiKey("mykey"); //214 character max - This is a UNIQUE local identifier used by the merchant to identify the kount inquiry request
			kount_update.SetOrderId("nqa-orderidkount-5"); //64 characters max - This is a UNIQUE local identifier used by the merchant to identify the transaction e.g. purchase order number.
			kount_update.SetFinancialOrderId("nqa-fin-orderid-1"); //64 characters max - This is a local identifier used by the merchant to identify the transaction e.g. purchase order number
			kount_update.SetPaymentToken("4242424242424242"); //payment token submitted by merchant (ie: credit card, payer ID)
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
			kount_update.SetPaymentType("CARD"); //payment type submitted by merchant
			kount_update.SetSessionId("xjudq804i1049jkjakdad");  //unique session id.  Must be unique over a 30-day spa
			kount_update.SetPaymentResponse("A"); //A - Authorized, D - Declined - payment transaction response
			kount_update.SetAvsResponse("M"); //M - Match, N - No Match - avs verification response returned from payment request. This can be provided should kount_inquiry be performed after the transaction is complete
			kount_update.SetCvdResponse("N"); //M - Match, N - No Match, X - Unsupported/Unavailable - cvd response returned to merchant from processor. This can be provided should kount_inquiry be performed after the transaction is complete
			kount_update.SetLast4("4242"); ////last 4 digits of credit card value
			kount_update.SetEvaluate("Y"); //Y or N - If set to Y, full re-evaluation will be performed with Kount.  If unset, default value is N
			kount_update.SetRefundStatus("C"); //R = Refund, C = Chargeback		

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetProcCountryCode("CA");
			mpgReq.SetStoreId("intuit_sped");
			mpgReq.SetApiToken("spedguy");
			mpgReq.SetTestMode(true);
			mpgReq.SetTransaction(kount_update);
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
				
	} // end TestKountUpdate
}
