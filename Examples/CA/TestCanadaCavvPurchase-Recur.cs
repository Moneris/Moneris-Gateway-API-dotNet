namespace Moneris
{
    using System;
    using System.Collections;

    public class TestCanadaCavvPurchase
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "CUS887H67";
            string amount = "10.42";
            string pan = "4242424242424242";
            string expdate = "1901"; //YYMM
            string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA=";
            string dynamic_descriptor = "123456";
			string wallet_indicator = "APP";
            string processing_country_code = "CA";
			string crypt_type = "5";
            bool status_check = false;

            /************************* Recur Variables **********************************/

            string recur_unit = "month"; //eom = end of month
            string start_now = "true";
            string start_date = "2018/02/25";
            string num_recurs = "12";
            string period = "1";
            string recur_amount = "30.00";

            /************************* Recur Object Option1 ******************************/

            Recur recurring_cycle = new Recur(recur_unit, start_now, start_date,
                               num_recurs, period, recur_amount);

            /************************* Recur Object Option2 ******************************/

            Hashtable recur_hash = new Hashtable();

            recur_hash.Add("recur_unit", recur_unit);
            recur_hash.Add("start_now", start_now);
            recur_hash.Add("start_date", start_date);
            recur_hash.Add("num_recurs", num_recurs);
            recur_hash.Add("period", period);
            recur_hash.Add("recur_amount", recur_amount);

            Recur recurring_cycle2 = new Recur(recur_hash);

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("R");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");
            
			CavvPurchase cavvPurchase = new CavvPurchase();
            cavvPurchase.SetOrderId(order_id);
            cavvPurchase.SetCustId(cust_id);
            cavvPurchase.SetAmount(amount);
            cavvPurchase.SetPan(pan);
            cavvPurchase.SetExpDate(expdate);
            cavvPurchase.SetCavv(cavv);
			cavvPurchase.SetCryptType(crypt_type); //Mandatory for AMEX cards only
            cavvPurchase.SetDynamicDescriptor(dynamic_descriptor);
			cavvPurchase.SetThreeDSVersion("2"); //Mandatory for 3DS Version 2.0+
			cavvPurchase.SetThreeDSServerTransId("e11d4985-8d25-40ed-99d6-c3803fe5e68f"); //Mandatory for 3DS Version 2.0+ - obtained from MpiCavvLookup or MpiThreeDSAuthentication
			//cavvPurchase.SetNetwork("Interac");  //set only for Interac e-commerce
			//cavvPurchase.SetDataType("3DSecure"); //set only for Interac e-commerce
			//cavvPurchase.SetWalletIndicator(wallet_indicator); //set only wallet transactions e.g. APPLE PAY
			
			cavvPurchase.SetRecur(recurring_cycle);
			cavvPurchase.SetCofInfo(cof);

            HttpsPostRequest mpgReq = new HttpsPostRequest(); 
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(cavvPurchase);
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
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
