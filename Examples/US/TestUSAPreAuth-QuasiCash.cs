namespace Moneris
{
	using System;
	
	public class TestUSAPreAuthQuasiCash
	{
        	public static void Main(string[] args)
		{
			string store_id = "monusqa002";
			string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string amount = "9.00";
			string pan = "4242424242424242";
            string expdate = "1602";        //YYMM format
			string crypt = "7";
            string processing_country_code = "US";
            bool status_check = false;
			
			PreAuth preauth = new PreAuth();
            preauth.SetOrderId(order_id);
            preauth.SetAmount(amount);
            preauth.SetPan(pan);
            preauth.SetExpDate(expdate);
            preauth.SetCryptType(crypt); 
            preauth.SetQuasiCash("Y");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(preauth);
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
				Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
				Console.WriteLine("Message = " + receipt.GetMessage());
				Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
				Console.WriteLine("Complete = " + receipt.GetComplete());
				Console.WriteLine("TransDate = " + receipt.GetTransDate());
				Console.WriteLine("TransTime = " + receipt.GetTransTime());
				Console.WriteLine("Ticket = " + receipt.GetTicket());
				Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
				Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	} 
}
