using System;
using Moneris;
using System.Collections;


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
        mpiThreeDSAuthentication.SetPan("340087427838525");
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
        mpiThreeDSAuthentication.SetBrowserIP("127.0.0.1"); //(defined by IETF BCP47)
        
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

        mpiThreeDSAuthentication.SetMessageCategory("01");
        mpiThreeDSAuthentication.SetDeviceChannel("02");
        mpiThreeDSAuthentication.SetDecoupledRequestIndicator("Y");
        mpiThreeDSAuthentication.SetDecoupledRequestMaxTime("00010");
        mpiThreeDSAuthentication.SetDecoupledRequestAsyncURL("https://yourasyncnotificationurl.com");
        mpiThreeDSAuthentication.SetRiIndicator("03");
        //mpiThreeDSAuthentication.SetRecurringExpiry("20221230");
        //mpiThreeDSAuthentication.SetRecurringFrequency("031");

		Hashtable priorRequestParams = new Hashtable();
        priorRequestParams.Add("prior_request_auth_data", "1");
        priorRequestParams.Add("prior_request_ref", "2c581b9d-7f77-4772-a92b-e11df34bce61");
        priorRequestParams.Add("prior_request_auth_method", "01");
        priorRequestParams.Add("prior_request_auth_timestamp", "202308151640");
        PaiInfo pai = new PaiInfo();
        pai.SetPriorRequest(priorRequestParams);
        mpiThreeDSAuthentication.SetPriorRequestAuthInfo(pai);
        
		Hashtable workPhoneParams = new Hashtable();
        workPhoneParams.Add("cc", "1");
        workPhoneParams.Add("subscriber", "1111111111");
        WorkPhoneInfo wpi = new WorkPhoneInfo();
        wpi.SetPhoneRequest(workPhoneParams);
        mpiThreeDSAuthentication.SetWorkPhoneInfo(wpi);

		Hashtable mobilePhoneParams = new Hashtable();
        mobilePhoneParams.Add("cc", "2");
        mobilePhoneParams.Add("subscriber", "2222222222");
        MobilePhoneInfo mpi = new MobilePhoneInfo();
        mpi.SetPhoneRequest(mobilePhoneParams);
        mpiThreeDSAuthentication.SetMobilePhoneInfo(mpi);

		Hashtable homePhoneParams = new Hashtable();
        homePhoneParams.Add("cc", "3");
        homePhoneParams.Add("subscriber", "3333333333");
        HomePhoneInfo hpi = new HomePhoneInfo();
        hpi.SetPhoneRequest(homePhoneParams);
        mpiThreeDSAuthentication.SetHomePhoneInfo(hpi);

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
			Console.WriteLine("TransStatusReason = " + receipt.GetMpiTransStatusReason());
			Console.WriteLine("ChallengeURL = " + receipt.GetMpiChallengeURL());
			Console.WriteLine("ChallengeData = " + receipt.GetMpiChallengeData());
            Console.WriteLine("ThreeDSServerTransId = " + receipt.GetMpiThreeDSServerTransId());
            Console.WriteLine("ThreeDSVersion = " + receipt.GetThreeDSVersion());
            Console.WriteLine("ThreeDSAcsTransID = " + receipt.GetMpiThreeDSAcsTransID());
            Console.WriteLine("ThreeDSTransID = " + receipt.GetMpiDSTransId());
            Console.WriteLine("ThreeDSAuthTimeStamp = " + receipt.GetMpiThreeDSAuthTimeStamp());
            Console.WriteLine("CardholderInfo = " + receipt.GetMpiCardholderInfo());
            Console.WriteLine("AuthenticationType = " + receipt.GetMpiAuthenticationType());

            //In Frictionless flow, you may receive TransStatus as "Y",
            //in which case you can then proceed directly to Cavv Purchase/Preauth with values below
            if (receipt.GetMpiTransStatus().Equals("Y"))
			{
				Console.WriteLine("Cavv = " + receipt.GetMpiCavv());
				Console.WriteLine("ECI = " + receipt.GetMpiEci());
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
