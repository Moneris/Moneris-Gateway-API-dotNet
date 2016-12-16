namespace Moneris
{
    using System;
    public class TestCanadaIndependentRefund
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store5";
            string api_token = "yesguy";
            string cust_id = "my customer id";
            string amount = "20.00";
            string pan = "4242424242424242";
            string expdate = "1901"; //YYMM
            string crypt = "7";
            string processing_country_code = "CA";
            bool status_check = false;

            IndependentRefund indrefund = new IndependentRefund();
            indrefund.SetOrderId(order_id);
            indrefund.SetCustId(cust_id);
            indrefund.SetAmount(amount);
            indrefund.SetPan(pan);
            indrefund.SetExpDate(expdate);
            indrefund.SetCryptType(crypt);
            indrefund.SetDynamicDescriptor("123456");

			//Optional - Set for Multi-Currency only
			//setAmount must be 0.00 when using multi-currency
			//indrefund.SetMCPAmount("500"); //penny value amount 1.25 = 125
			//indrefund.SetMCPCurrencyCode("840"); //ISO-4217 country currency number

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(indrefund);
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
                Console.WriteLine("MCPAmount = " + receipt.GetMCPAmount());
                Console.WriteLine("MCPCurrencyCode = " + receipt.GetMCPCurrencyCode());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
