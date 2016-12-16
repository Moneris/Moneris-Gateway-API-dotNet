namespace Moneris
{
    using System;
    public class TestUSAPurchaseRecur
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string amount = "5.00";
            string pan = "4242424242424242";
            string expdate = "1902";        //YYMM format
            string crypt = "7";
            string commcard_invoice = "INVC090";
            string commcard_tax_amount = "1.00";
            string processing_country_code = "US";
            bool status_check = false;

            /************************* Recur Variables **********************************/

            string recur_unit = "month";
            string start_now = "true";
            string start_date = "2016/12/01";
            string num_recurs = "12";
            string period = "1";
            string recur_amount = "30.00";
            string cust_id = "my customer id";

            Recur recurring_cycle = new Recur(recur_unit, start_now, start_date,
                               num_recurs, period, recur_amount);

            Purchase purchase = new Purchase();
            purchase.SetOrderId(order_id);
            purchase.SetCustId(cust_id);
            purchase.SetAmount(amount);
            purchase.SetPan(pan);
            purchase.SetExpDate(expdate);
            purchase.SetCryptType(crypt);
            purchase.SetCommcardInvoice(commcard_invoice);
            purchase.SetCommcardTaxAmount(commcard_tax_amount);            
            purchase.SetRecur(recurring_cycle);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(purchase);
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
                Console.WriteLine("Recur Success = " + receipt.GetRecurSuccess());
                //Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
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
