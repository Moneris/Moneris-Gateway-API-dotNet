using System;
using Moneris;

public class TestCanadaSurchargeLookup
{
	public static void Main(string[] args)
	{
		string store_id = "moneris";
		string api_token = "hurgle";
		string amount = "20.00";
		string pan = "5454545454545454";

		string processing_country_code = "CA";
		bool status_check = false;

		SurchargeLookup surchargeLookup = new SurchargeLookup();
		surchargeLookup.SetPan(pan);
		surchargeLookup.SetAmount(amount);
		

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(surchargeLookup);
		mpgReq.SetStatusCheck(status_check);
		mpgReq.Send();

		try
		{
			Receipt receipt = mpgReq.GetReceipt();
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("CardType = " + receipt.GetCardType());
			Console.WriteLine("SurchargeAmount = " + receipt.GetIsSurchargeEligible());
			Console.WriteLine("MaxSurchargeRate = " + receipt.GetMaxSurchargeRate());
			Console.WriteLine("MaxSurchargeAmount = " + receipt.GetMaxSurchargeAmount());
			Console.WriteLine("ServiceType = " + receipt.GetServiceType());
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

