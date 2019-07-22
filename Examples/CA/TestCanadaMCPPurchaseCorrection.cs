namespace Moneris
{
    using System;
    public class TestCanadaMCPPurchaseCorrection
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test20190426094615";
            string txn_number = "421047-0_14";
            string crypt = "7";
            string dynamic_descriptor = "123456";
            string processing_country_code = "CA";
            bool status_check = false;

            MCPPurchaseCorrection mcpPurchaseCorrection = new MCPPurchaseCorrection();
            mcpPurchaseCorrection.SetOrderId(order_id);
            mcpPurchaseCorrection.SetTxnNumber(txn_number);
            mcpPurchaseCorrection.SetCryptType(crypt);
            mcpPurchaseCorrection.SetDynamicDescriptor(dynamic_descriptor);
            mcpPurchaseCorrection.SetCustId("my customer id");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpPurchaseCorrection);
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
