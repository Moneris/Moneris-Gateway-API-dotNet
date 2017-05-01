namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestMcIndependentRefund
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id = "CUST13343";
			string amount = "5.00";
			string pan = "5454545442424242";
			string expiry_date = "1912"; //YYMM
			string crypt = "7";
			string merchant_ref_no = "319038";

			McIndependentRefund mcindrefund = new McIndependentRefund();
			mcindrefund.SetOrderId(order_id);
			mcindrefund.SetCustId(cust_id);
			mcindrefund.SetAmount(amount);
			mcindrefund.SetPan(pan);
			mcindrefund.SetExpDate(expiry_date);
			mcindrefund.SetCryptType(crypt);
			mcindrefund.SetMerchantRefNo(merchant_ref_no);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcindrefund);
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
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

		}
	}
}
