using System;
using Moneris;

public class TestCanadaSurchargeLookup
{
	public static void Main(string[] args)
	{
		string store_id = "moneris";
		string api_token = "hurgle";
		string amount = "20.00";
		string data_key = "KqqbXgdjpmANR9vxoeGxn51y2";

		string processing_country_code = "CA";
		bool status_check = false;

		ResSurchargeLookup resSurchargeLookup = new ResSurchargeLookup();
		resSurchargeLookup.SetDataKey(data_key);
		resSurchargeLookup.SetAmount(amount);
		

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(resSurchargeLookup);
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
			Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
			Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
			Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
                
			Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
			Console.WriteLine("Phone = " + receipt.GetResDataPhone());
			Console.WriteLine("Email = " + receipt.GetResDataEmail());
			Console.WriteLine("Note = " + receipt.GetResDataNote());
			Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
			Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
			Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
			Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
			Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
			Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

