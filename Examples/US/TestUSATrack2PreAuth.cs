namespace Moneris
{
    using System;
    using System.Text.RegularExpressions;
    public class TestUSATrack2Preauth
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "LBriggs";
            string amount = "5.00";
            string track2 = ";5258968987035454=06061015454001060101?";
            string pan = null;
            string exp = "0000";		//must send '0000' if swiped
            string pos_code = "00";
            string commcard_invoice = "INV98798";
            string commcard_tax_amount = "1.00";
            string descriptor = "my descriptor";
            string processing_country_code = "US";
            bool status_check = false;

            Track2PreAuth track2preauth = new Track2PreAuth();
            track2preauth.SetOrderId(order_id);
            track2preauth.SetCustId(cust_id);
            track2preauth.SetAmount(amount);
            track2preauth.SetTrack2(track2);
            track2preauth.SetPan(pan);
            track2preauth.SetExpDate(exp);
            track2preauth.SetPosCode(pos_code);
            track2preauth.SetDynamicDescriptor(descriptor);
            track2preauth.SetCommcardInvoice(commcard_invoice);
            track2preauth.SetCommcardTaxAmount(commcard_tax_amount);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(track2preauth);
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
