namespace Moneris
{
    using System;
    public class TestResCardVerificationCC
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string data_key = "V6F9PJKdXQj6vKiCMNrWbsyJ2";
            string order_id = "Test_P_033333_6";
            string cust_id = "Customer1";
            string crypt = "7";
			string processing_country_code = "CA";
            bool status_check = false;

            /*************** Address Verification Service **********************/

            AvsInfo avsCheck = new AvsInfo();

            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");
			
			/****************** Card Validation Digits *************************/

            CvdInfo cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator("1");
            cvdCheck.SetCvdValue("099");

			/*************** Credential on File *************************************/
			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            ResCardVerificationCC rescardverify = new ResCardVerificationCC();
			rescardverify.SetDataKey(data_key);
			rescardverify.SetOrderId(order_id);
			rescardverify.SetCustId(cust_id);
			//rescardverify.SetExpDate("1612");  //for use with Temp Tokens only
			rescardverify.SetCryptType(crypt);
            rescardverify.SetAvsInfo(avsCheck);
            rescardverify.SetCvdInfo(cvdCheck);
			rescardverify.SetCofInfo(cof);
			
            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(rescardverify);
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
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
				Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    } // end TestResCardVerificationCC
}
