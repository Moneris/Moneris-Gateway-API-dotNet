namespace Moneris
{
    using System;
    using System.Collections;

    public class TestCanadaCavvPreauth
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "CUS887H67";
            string amount = "10.42";
            string pan = "4242424242424242";
            string expdate = "1911"; //YYMM format
            string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA=";
            string dynamic_descriptor = "123456";
			string wallet_indicator = "APP";
            string processing_country_code = "CA";
			string crypt_type = "5";
            string ds_trans_id = "12345";
            bool status_check = false;
            bool is_incremental = true;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            CavvPreAuth cavvPreauth = new CavvPreAuth();
            cavvPreauth.SetOrderId(order_id);
            cavvPreauth.SetCustId(cust_id);
            cavvPreauth.SetAmount(amount);
            cavvPreauth.SetPan(pan);
            cavvPreauth.SetExpDate(expdate);
            cavvPreauth.SetCavv(cavv);
			cavvPreauth.SetCryptType(crypt_type); //Mandatory for AMEX cards only
            cavvPreauth.SetDynamicDescriptor(dynamic_descriptor);
			cavvPreauth.SetThreeDSVersion("2"); //Mandatory for 3DS Version 2.0+
			cavvPreauth.SetThreeDSServerTransId("e11d4985-8d25-40ed-99d6-c3803fe5e68f"); //Mandatory for 3DS Version 2.0+ - obtained from MpiCavvLookup or MpiThreeDSAuthentication 
			cavvPreauth.SetDsTransId(ds_trans_id); //Optional - to be used only if you are using 3rd party 3ds 2.0 service
            //cavvPreauth.SetWalletIndicator(wallet_indicator); //set only wallet transactions e.g. APPLE PAY
			//cavvPreauth.SetCmId("8nAK8712sGaAkls56"); //set only for usage with Offlinx - Unique max 50 alphanumeric characters transaction id generated by merchant
			cavvPreauth.SetCofInfo(cof);
            cavvPreauth.SetIsIncremental((is_incremental).ToString());

            // TrId and TokenCryptogram are optional, refer documentation for more details.
            cavvPreauth.SetTrId("50189815682");
		    cavvPreauth.SetTokenCryptogram("APmbM/411e0uAAH+s6xMAAADFA==");
			
            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(cavvPreauth);
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
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
				Console.WriteLine("ThreeDSVersion = " + receipt.GetThreeDSVersion());
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
