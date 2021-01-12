using System;
using Moneris;

public class TestCanadaMpiThreeDSAuthentication
{
	public static void Main(string[] args)
	{
		string store_id = "moneris";
		string api_token = "hurgle";
		
		string processing_country_code = "CA";

		MpiThreeDSAuthentication mpiThreeDSAuthentication = new MpiThreeDSAuthentication();
        mpiThreeDSAuthentication.SetOrderId("Test1597873519352");	//must be the same one that was used in MpiCardLookup call
        mpiThreeDSAuthentication.SetCardholderName("Moneris Test");
        mpiThreeDSAuthentication.SetPan("4740611374762707");
		//mpiThreeDSAuthentication.SetDataKey("8OOXGiwxgvfbZngigVFeld9d2"); //Optional - For Moneris Vault and Hosted Tokenization tokens in place of SetPan
        mpiThreeDSAuthentication.SetExpdate("2310");
        mpiThreeDSAuthentication.SetAmount("1.00");
        mpiThreeDSAuthentication.SetThreeDSCompletionInd("Y"); //(Y|N|U) indicates whether 3ds method MpiCardLookup was successfully completed
        mpiThreeDSAuthentication.SetRequestType("01"); //(01=payment|02=recur)
        mpiThreeDSAuthentication.SetPurchaseDate("20200819035249"); //(YYYYMMDDHHMMSS)
        mpiThreeDSAuthentication.SetNotificationURL("https://yournotificationurl.com"); //(Website where response from RRes or CRes after challenge will go)
        mpiThreeDSAuthentication.SetChallengeWindowSize("03"); //(01 = 250 x 400, 02 = 390 x 400, 03 = 500 x 600, 04 = 600 x 400, 05 = Full screen)
        
        mpiThreeDSAuthentication.SetBrowserUserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36\\");
        mpiThreeDSAuthentication.SetBrowserJavaEnabled("true"); //(true|false)
        mpiThreeDSAuthentication.SetBrowserScreenHeight("1000"); //(pixel height of cardholder screen)
        mpiThreeDSAuthentication.SetBrowserScreenWidth("1920"); //(pixel width of cardholder screen)
        mpiThreeDSAuthentication.SetBrowserLanguage("en-GB"); //(defined by IETF BCP47)
        
        //Optional Methods
		mpiThreeDSAuthentication.SetBillAddress1("3300 Bloor St W");
        mpiThreeDSAuthentication.SetBillProvince("ON");
        mpiThreeDSAuthentication.SetBillCity("Toronto");
        mpiThreeDSAuthentication.SetBillPostalCode("M8X 2X2");
        mpiThreeDSAuthentication.SetBillCountry("124");
        
        mpiThreeDSAuthentication.SetShipAddress1("3300 Bloor St W");
        mpiThreeDSAuthentication.SetShipProvince("ON");
        mpiThreeDSAuthentication.SetShipCity("Toronto");
        mpiThreeDSAuthentication.SetShipPostalCode("M8X 2X2");
        mpiThreeDSAuthentication.SetShipCountry("124");

        mpiThreeDSAuthentication.SetEmail("test@email.com");
        mpiThreeDSAuthentication.SetRequestChallenge("Y"); //(Y|N Requesting challenge regardless of outcome)

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(mpiThreeDSAuthentication);
		mpgReq.Send();

		/**********************   REQUEST  ************************/

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("Message = " + receipt.GetMessage());
			
			Console.WriteLine("MessageType = " + receipt.GetMpiMessageType());
			Console.WriteLine("TransStatus = " + receipt.GetMpiTransStatus());
			Console.WriteLine("ChallengeURL = " + receipt.GetMpiChallengeURL());
			Console.WriteLine("ChallengeData = " + receipt.GetMpiChallengeData());
			Console.WriteLine("ThreeDSServerTransId = " + receipt.GetMpiThreeDSServerTransId());
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
