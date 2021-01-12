using System;
using System.Text;
using System.Collections;
using Moneris;

public class TestCanadaResOCTPaymentCC
{
	public static void Main(string[] args)
	{
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");   
		string store_id = "store5";
		string api_token = "yesguy";
		string data_key = "71Sc8RZFWDW7NvxSXCLC9unF4";
		string amount = "1.00";
		string cust_id = "customer1";
		string crypt_type = "1";
		string processing_country_code = "CA";
		bool status_check = false;

		ResOCTPaymentCC resOCTPaymentCC = new ResOCTPaymentCC();
		resOCTPaymentCC.SetOrderId(order_id);
		resOCTPaymentCC.SetCustId(cust_id);
		resOCTPaymentCC.SetAmount(amount);
		resOCTPaymentCC.SetCryptType(crypt_type);
		resOCTPaymentCC.SetDataKey(data_key);

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(resOCTPaymentCC);
		mpgReq.SetStatusCheck(status_check);
		mpgReq.Send();

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("DataKey = " + receipt.GetDataKey());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("TransType = " + receipt.GetTransType());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
			Console.WriteLine("CardType = " + receipt.GetCardType());
			Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
			Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
			Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
			Console.WriteLine("FastFundsIndicator = " + receipt.GetFastFundsIndicator());

			Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
			Console.WriteLine("Phone = " + receipt.GetResDataPhone());
			Console.WriteLine("Email = " + receipt.GetResDataEmail());
			Console.WriteLine("Note = " + receipt.GetResDataNote());
			Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
			Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
			Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
