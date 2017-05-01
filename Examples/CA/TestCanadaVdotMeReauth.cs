using System;

namespace Moneris
{
     	class TestCanadaVdotMeReauth
	{
        	public static void Main(string[] args)
		{
			string store_id = "store2";
			string api_token = "yesguy";
	    		string order_id = "VmeOrder" + DateTime.Now.ToString("yyyyMMddhhmmss");
          		string orig_order_id = "VmeOrder20150626023358";
            		string txn_number = "737541-0_10";
			string amount = "1.00";
	    		string crypt_type = "7";
			string processing_country_code = "CA";
			bool status_check = false;

            		VdotMeReauth vDotMeReauthRequest = new VdotMeReauth();
            		vDotMeReauthRequest.SetOrderId(order_id);
            		vDotMeReauthRequest.SetOrigOrderId(orig_order_id);
            		vDotMeReauthRequest.SetTxnNumber(txn_number);
            		vDotMeReauthRequest.SetAmount(amount);
           		vDotMeReauthRequest.SetCryptType(crypt_type);

            		HttpsPostRequest mpgReq = new HttpsPostRequest();
           		mpgReq.SetProcCountryCode(processing_country_code);
            		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            		mpgReq.SetStoreId(store_id);
            		mpgReq.SetApiToken(api_token);
            		mpgReq.SetTransaction(vDotMeReauthRequest);
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
