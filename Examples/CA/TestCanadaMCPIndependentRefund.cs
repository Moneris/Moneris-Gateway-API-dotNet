namespace Moneris
{
    using System;
    public class TestCanadaMCPIndependentRefund
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

            MCPIndependentRefund mcpIndrefund = new MCPIndependentRefund();
            mcpIndrefund.SetOrderId(order_id);
            mcpIndrefund.SetCustId(cust_id);
            mcpIndrefund.SetAmount(amount);
            mcpIndrefund.SetPan(pan);
            mcpIndrefund.SetExpDate(expdate);
            mcpIndrefund.SetCryptType(crypt);
            mcpIndrefund.SetDynamicDescriptor("123456");

			//MCP Fields
			mcpIndrefund.SetMCPVersion("1.0");
			mcpIndrefund.SetCardholderAmount("500");
			mcpIndrefund.SetCardholderCurrencyCode("840");
			//mcpIndrefund.SetMCPRateToken("P1538681661706745");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpIndrefund);
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
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
				
				Console.WriteLine("MerchantSettlementAmount = " + receipt.GetMerchantSettlementAmount());
				Console.WriteLine("CardholderAmount = " + receipt.GetCardholderAmount());
				Console.WriteLine("CardholderCurrencyCode = " + receipt.GetCardholderCurrencyCode());
				Console.WriteLine("MCPRate = " + receipt.GetMCPRate());
				Console.WriteLine("MCPErrorStatusCode = " + receipt.GetMCPErrorStatusCode());
				Console.WriteLine("MCPErrorMessage = " + receipt.GetMCPErrorMessage());
				Console.WriteLine("HostId = " + receipt.GetHostId());	
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
