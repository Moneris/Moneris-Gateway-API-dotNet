using System;
using Moneris;

namespace ACME
{
	class TestCanadaVdotMePurchaseCorrection
	{
        	public static void Main(string[] args)
		{
			string store_id = "store2";
			string api_token = "yesguy";
            		string order_id = "VmeOrder20150626022834";
            		string txn_number = "737534-0_10";
            		string crypt_type = "7";
            		string cust_id = "my customer id";
            		string processing_country_code = "CA";
            		bool status_check = false;

            		VdotMePurchaseCorrection vDotMePurchaseCorrection = new VdotMePurchaseCorrection();
           		vDotMePurchaseCorrection.SetOrderId(order_id);
            		vDotMePurchaseCorrection.SetCustId(cust_id);
            		vDotMePurchaseCorrection.SetTxnNumber(txn_number);
            		vDotMePurchaseCorrection.SetCryptType(crypt_type);

            		HttpsPostRequest mpgReq = new HttpsPostRequest();
            		mpgReq.SetProcCountryCode(processing_country_code);
            		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            		mpgReq.SetStoreId(store_id);
            		mpgReq.SetApiToken(api_token);
            		mpgReq.SetTransaction(vDotMePurchaseCorrection);
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
				Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
				Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                		Console.WriteLine("\r\nPress the enter key to exit");
               			Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}	
}
