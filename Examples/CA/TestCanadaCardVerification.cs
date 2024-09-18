namespace Moneris
{
    using System;
    public class TestCanadaCardVerficiation
    {
        public static void Main(string[] args)
        {
            string store_id = "monca02932";
            string api_token = "CG8kYzGgzVU5z23irgMx";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string pan = "4761349999000039";
            string expdate = "1901"; //YYMM format
            string crypt = "7";
            string processing_country_code = "CA";
            bool status_check = false;
            

            AvsInfo avsCheck = new AvsInfo();
            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

            CvdInfo cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator("1");
            cvdCheck.SetCvdValue("099");

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            AccountNameVerificationInfo ani = new AccountNameVerificationInfo();
            ani.SetFirstName("FIRST");
            ani.SetMiddleName("MIDDLE");
            ani.SetLastName("LAST");

            CardVerification cardVerification = new CardVerification();
            cardVerification.SetOrderId(order_id);
            cardVerification.SetPan(pan);
            cardVerification.SetExpDate(expdate);
            cardVerification.SetCryptType(crypt);
            cardVerification.SetAvsInfo(avsCheck);
            cardVerification.SetCvdInfo(cvdCheck);
			cardVerification.SetCofInfo(cof);
            cardVerification.SetAccountNameVerificationInfo(ani);

		    // TrId and TokenCryptogram are optional, refer documentation for more details.
            cardVerification.SetTrId("50189815682");
		    cardVerification.SetTokenCryptogram("APmbM/411e0uAAH+s6xMAAADFA==");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(cardVerification);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();
                
                Console.WriteLine(cardVerification.toXML());
                
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
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
                Console.WriteLine("AccountNameVerificationResult = " + receipt.GetAccountNameVerificationResult());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
