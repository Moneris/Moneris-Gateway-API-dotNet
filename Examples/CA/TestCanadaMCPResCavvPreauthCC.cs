namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaMCPResCavvPreauthCC
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store1";
            string api_token = "yesguy1";
            string data_key = "4INQR1A8ocxD0oafSz50LADXy";
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
            string expdate = "1911";
            string crypt_type = "7";
            string processing_country_code = "CA";
            string ds_trans_id = "12345";
            bool status_check = false;

            CofInfo cof = new CofInfo();
            cof.SetPaymentIndicator("U");
            cof.SetPaymentInformation("2");
            cof.SetIssuerId("139X3130ASCXAS9");

            MCPResCavvPreauthCC mcpResCavvPreauthCC = new MCPResCavvPreauthCC();
            mcpResCavvPreauthCC.SetDataKey(data_key);
            mcpResCavvPreauthCC.SetOrderId(order_id);
            mcpResCavvPreauthCC.SetCustId(cust_id);
            mcpResCavvPreauthCC.SetAmount(amount);
            mcpResCavvPreauthCC.SetCavv(cavv);
            mcpResCavvPreauthCC.SetExpDate(expdate);
            mcpResCavvPreauthCC.SetCryptType(crypt_type);
            mcpResCavvPreauthCC.SetThreeDSVersion("2"); //Mandatory for 3DS Version 2.0+
            mcpResCavvPreauthCC.SetThreeDSServerTransId("e11d4985-8d25-40ed-99d6-c3803fe5e68f"); //Mandatory for 3DS Version 2.0+ - obtained from MpiCavvLookup or MpiThreeDSAuthentication
            mcpResCavvPreauthCC.SetDsTransId(ds_trans_id); //Optional - to be used only if you are using 3rd party 3ds 2.0 service

            mcpResCavvPreauthCC.SetCofInfo(cof);

            //MCP Fields
            mcpResCavvPreauthCC.SetMCPVersion("1.0");
            mcpResCavvPreauthCC.SetCardholderAmount("500");
            mcpResCavvPreauthCC.SetCardholderCurrencyCode("840");
            mcpResCavvPreauthCC.SetMCPRateToken("P1623704155960714");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpResCavvPreauthCC);
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
