using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

namespace CanadaPurchaseConsoleTest
{
    class CanadaPreauthTest
    {
		public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string amount = "5.00";
            string pan = "4242424242424242";
            string expdate = "0412";
            string crypt = "7";
            string processing_country_code = "CA";
            bool status_check = false;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("12345678901234");

            PreAuth preauth = new PreAuth();
            preauth.SetOrderId(order_id);
            preauth.SetAmount(amount);
            preauth.SetPan(pan);
            preauth.SetExpDate(expdate);
            preauth.SetCryptType(crypt);
			//preauth.SetWalletIndicator(""); //Refer to documentation for details
			preauth.SetCofInfo(cof);

			//Optional - Set for Multi-Currency only
			//setAmount must be 0.00 when using multi-currency
			//preauth.SetMCPAmount("500"); //penny value amount 1.25 = 125
			//preauth.SetMCPCurrencyCode("840"); //ISO-4217 country currency number

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
                //Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                //Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                Console.WriteLine("MCPAmount = " + receipt.GetMCPAmount());
                Console.WriteLine("MCPCurrencyCode = " + receipt.GetMCPCurrencyCode());
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
