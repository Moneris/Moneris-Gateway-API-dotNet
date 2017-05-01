using System;

namespace Moneris
{
	class TestCanadaVdotMeCompletion
	{
            public static void Main(string[] args)
	    {
			string store_id = "store2";
			string api_token = "yesguy";
            string order_id = "VmeOrder20150626023358";
            string txn_number = "737541-0_10";
			string comp_amount = "1.00";
            string ship_indicator = "P";
            string crypt_type = "7";
            string cust_id = "mycustomerid";
			string dynamic_descriptor = "inv 123";
            string processing_country_code = "CA";
            bool status_check = false;

            VdotMeCompletion vmecompletion = new VdotMeCompletion();
            vmecompletion.SetOrderId(order_id);
            vmecompletion.SetTxnNumber(txn_number);
            vmecompletion.SetAmount(comp_amount);
            vmecompletion.SetCryptType(crypt_type);
            vmecompletion.SetDynamicDescriptor(dynamic_descriptor);
            vmecompletion.SetCustId(cust_id);
            vmecompletion.SetShipIndicator(ship_indicator);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vmecompletion);
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
