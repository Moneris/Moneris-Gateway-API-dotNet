namespace Moneris
{
    using System;
    using System.Text.RegularExpressions;
    public class TestCanadaTrack2Purchase
    {
        public static void Main(string[] args)
        {
            string store_id = "store1";
            string api_token = "yesguy";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "LBriggs";
            string amount = "1.00";
            string track2 = "";
            //string track2 = ";5258968987035454=06061015454001060101?";
            string pan = "4242424242424242";
            string exp_date = "1903";		//must send '0000' if swiped
            string pos_code = "00";
            string commcard_invoice = "INV98798";
            string commcard_tax_amount = "1.00";
            string processing_country_code = "CA";
            bool status_check = false;

            Track2Purchase track2purchase = new Track2Purchase();
            track2purchase.SetOrderId(order_id);
            track2purchase.SetCustId(cust_id);
            track2purchase.SetAmount(amount);
            track2purchase.SetTrack2(track2);
            track2purchase.SetPan(pan);
            track2purchase.SetExpDate(exp_date);
            track2purchase.SetPosCode(pos_code);
            track2purchase.SetCommcardInvoice(commcard_invoice);
            track2purchase.SetCommcardTaxAmount(commcard_tax_amount);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(track2purchase);
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
