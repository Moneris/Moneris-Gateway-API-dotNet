namespace Moneris
{
    using System;
    using System.Collections;

    public class TestUSACavvPurchase
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "B_Urlac_54";
            string amount = "10.42";
            string pan = "4005554444444403";
            string expdate = "1901";        //YYMM format
            string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
			string crypt_type = "5";
            string commcard_invoice = "COINV982";
            string commcard_tax_amount = "1.00";
            string dynamic_descriptor = "my descriptor";
            string processing_country_code = "US";
            bool status_check = false;

            AvsInfo avsCheck = new AvsInfo();
            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

            CvdInfo cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator("1");
            cvdCheck.SetCvdValue("099");

            CavvPurchase cavvPurchase = new CavvPurchase();
            cavvPurchase.SetOrderId(order_id);
            cavvPurchase.SetCustId(cust_id);
            cavvPurchase.SetAmount(amount);
            cavvPurchase.SetPan(pan);
            cavvPurchase.SetExpDate(expdate);
            cavvPurchase.SetCavv(cavv);
			cavvPurchase.SetCryptType(crypt_type); //Mandatory for AMEX cards only
            cavvPurchase.SetDynamicDescriptor(dynamic_descriptor);
            cavvPurchase.SetCommcardInvoice(commcard_invoice);
            cavvPurchase.SetCommcardTaxAmount(commcard_tax_amount);
            cavvPurchase.SetAvsInfo(avsCheck);
            cavvPurchase.SetCvdInfo(cvdCheck);

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
                Console.WriteLine("Avs Response = " + receipt.GetAvsResultCode());
                Console.WriteLine("Cvd Response = " + receipt.GetCvdResultCode());
                //Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
                //Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                //Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
