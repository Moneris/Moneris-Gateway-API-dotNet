using System;
using Moneris;

public class TestCanadaOCTPayment
{
	public static void Main(string[] args)
	{
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string store_id = "store5";
		string api_token = "yesguy";
		string cust_id = "my customer id";
		string amount = "20.00";
		string pan = "4761260000000134";
		string expdate = "2012"; //YYMM
		string crypt = "7";
		string processing_country_code = "CA";
		bool status_check = false;

		OCTPayment oCTPayment = new OCTPayment();
		oCTPayment.SetOrderId(order_id);
		oCTPayment.SetCustId(cust_id);
		oCTPayment.SetAmount(amount);
		oCTPayment.SetPan(pan);
		oCTPayment.SetExpDate(expdate);
		oCTPayment.SetCryptType(crypt);
		oCTPayment.SetDynamicDescriptor("123456");

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(oCTPayment);
		mpgReq.SetStatusCheck(status_check);
		mpgReq.Send();

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("CardType = " + receipt.GetCardType());
			Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
			Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("TransType = " + receipt.GetTransType());
			Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("ISO = " + receipt.GetISO());
			Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("Ticket = " + receipt.GetTicket());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
			Console.WriteLine("FastFundsIndicator = " + receipt.GetFastFundsIndicator());
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

