namespace Moneris
{
    using System;
    public class TestCanadaMCPCompletion
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test20160815041528";
            string amount = "2.00";
            string txn_number = "118149-0_10";
            string crypt = "7";
            string cust_id = "my customer id";
            string dynamic_descriptor = "my descriptor";
            string ship_indicator = "F";
            string processing_country_code = "CA";
            bool status_check = false;

            MCPCompletion mcpCompletion = new MCPCompletion();
            mcpCompletion.SetOrderId(order_id);
            mcpCompletion.SetCompAmount(amount);
            mcpCompletion.SetTxnNumber(txn_number);
            mcpCompletion.SetCryptType(crypt);
            mcpCompletion.SetCustId(cust_id);
            mcpCompletion.SetDynamicDescriptor(dynamic_descriptor);
            //mcpCompletion.SetShipIndicator(ship_indicator); //optional

			//MCP Fields
			mcpCompletion.SetMCPVersion("1.0");
			mcpCompletion.SetCardholderAmount("500");
			mcpCompletion.SetCardholderCurrencyCode("840");
			mcpCompletion.SetMCPRateToken("P1538681661706745");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpCompletion);
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
