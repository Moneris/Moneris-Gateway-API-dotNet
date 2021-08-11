namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaMCPResPreauthCC
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store5";
            string api_token = "yesguy";
            string data_key = "rS7DbroQHJmJxdBfXFXiauQc4";
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string crypt_type = "1";
            string dynamic_descriptor = "my descriptor";
            string processing_country_code = "CA";
            bool status_check = false;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            MCPResPreauthCC mcpResPreauthCC = new MCPResPreauthCC();
            mcpResPreauthCC.SetDataKey(data_key);
            mcpResPreauthCC.SetOrderId(order_id);
            mcpResPreauthCC.SetCustId(cust_id);
            mcpResPreauthCC.SetAmount(amount);
            mcpResPreauthCC.SetCryptType(crypt_type);
            mcpResPreauthCC.SetDynamicDescriptor(dynamic_descriptor);
			mcpResPreauthCC.SetCofInfo(cof);

			//MCP Fields
			mcpResPreauthCC.SetMCPVersion("1.0");
			mcpResPreauthCC.SetCardholderAmount("500");
			mcpResPreauthCC.SetCardholderCurrencyCode("840");
			mcpResPreauthCC.SetMCPRateToken("P1538681661706745");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpResPreauthCC);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
                
				Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());

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
