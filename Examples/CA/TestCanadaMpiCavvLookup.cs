using System;
using Moneris;

public class TestCanadaMpiCavvLookup
{
	public static void Main(string[] args)
	{
		string store_id = "moneris";
		string api_token = "hurgle";
		string processing_country_code = "CA";
		
		//BASE64 Encoded CRes value returned from response at completion of challenge flow.
        string cres = "eyJhY3NUcmFuc0lEIjoiNzQ0ZDI2NjUtNjU2Yy00ZGNiLTg3MWUtYTBkYmMwODA0OTYzIiwibWVzc2FnZVR5cGUiOiJDUmVzIiwiY2hhbGxlbmdlQ29tcGxldGlvbkluZCI6IlkiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMS4wIiwidHJhbnNTdGF0dXMiOiJZIiwidGhyZWVEU1NlcnZlclRyYW5zSUQiOiJlMTFkNDk4NS04ZDI1LTQwZWQtOTlkNi1jMzgwM2ZlNWU2OGYifQ==";

		MpiCavvLookup mpiCavvLookup = new MpiCavvLookup();    
		mpiCavvLookup.SetCRes(cres);

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(mpiCavvLookup);
		mpgReq.Send();

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("Message = " + receipt.GetMessage());
			
			Console.WriteLine("ThreeDSServerTransId = " + receipt.GetMpiThreeDSServerTransId());
			Console.WriteLine("TransStatus = " + receipt.GetMpiTransStatus());
			Console.WriteLine("ChallengeCompletionIndicator = " + receipt.GetMpiChallengeCompletionIndicator());
			Console.WriteLine("Cavv = " + receipt.GetMpiCavv());
			Console.WriteLine("ECI = " + receipt.GetMpiEci());
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
