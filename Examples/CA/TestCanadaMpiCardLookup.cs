using System;
using Moneris;

public class TestCanadaMpiCardLookup
{
	public static void Main(string[] args)
	{
		string store_id = "moneris";
		string api_token = "hurgle";
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string pan = "4740611374762707";
		
		string processing_country_code = "CA";

		MpiCardLookup mpiCardLookup = new MpiCardLookup();
		mpiCardLookup.SetOrderId(order_id);
		mpiCardLookup.SetPan(pan);
		//mpiCardLookup.SetDataKey("8OOXGiwxgvfbZngigVFeld9d2"); //Optional - For Moneris Vault and Hosted Tokenization tokens in place of SetPan
		mpiCardLookup.SetNotificationUrl("https://yournotificationurl.com"); //(Website URL that will receive 3DS Method Completion response from ACS)

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(mpiCardLookup);
		mpgReq.Send();

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("Messagetype = " + receipt.GetMpiMessageType());
			Console.WriteLine("ThreeDSMethodURL = " + receipt.GetMpiThreeDSMethodURL());
			Console.WriteLine("ThreeDSMethodData = " + receipt.GetMpiThreeDSMethodData());
			Console.WriteLine("ThreeDSServerTransId = " + receipt.GetMpiThreeDSServerTransId());
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
