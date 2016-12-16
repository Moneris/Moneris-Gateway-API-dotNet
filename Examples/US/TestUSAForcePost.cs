namespace Moneris
{
    using System;

	public class TestUSAForcePost
	{
        	public static void Main(string[] args)
		{
            		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            		string store_id = "monusqa002";
            		string api_token = "qatoken";
            		string cust_id = "customer1";
			string amount = "10.00";
            		string pan = "4242424242424242";
            		string expdate = "1602";        //YYMM format
            		string auth_code = "AU4R6";
            		string crypt = "1";
            		string processing_country_code = "US";
            		bool status_check = false;
            		string dynamic_descriptor = "my descriptor";

            		ForcePost forcepost = new ForcePost();
            		forcepost.SetOrderId(order_id);
            		forcepost.SetCustId(cust_id);
            		forcepost.SetAmount(amount);
            		forcepost.SetPan(pan);
            		forcepost.SetExpDate(expdate);
            		forcepost.SetAuthCode(auth_code);
            		forcepost.SetCryptType(crypt);
            		forcepost.SetDynamicDescriptor(dynamic_descriptor);

            		HttpsPostRequest mpgReq = new HttpsPostRequest();
            		mpgReq.SetProcCountryCode(processing_country_code);
            		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            		mpgReq.SetStoreId(store_id);
            		mpgReq.SetApiToken(api_token);
            		mpgReq.SetTransaction(forcepost);
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
                		//Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                		//Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                		//Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                		Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
