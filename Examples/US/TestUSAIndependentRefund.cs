namespace Moneris
{
    using System;
    public class TestUSAIndependentRefund
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string cust_id = "my customer id";
            string amount = "20.00";
            string pan = "4242424242424242";
            string expdate = "1602";        //YYMM format
            string crypt = "7";
            string commcard_invoice = "INVC090";
            string commcard_tax_amount = "1.00";
            string processing_country_code = "US";
            bool status_check = false;

            IndependentRefund indrefund = new IndependentRefund();
            indrefund.SetOrderId(order_id);
            indrefund.SetCustId(cust_id);
            indrefund.SetAmount(amount);
            indrefund.SetPan(pan);
            indrefund.SetExpDate(expdate);
            indrefund.SetCryptType(crypt);
            indrefund.SetCommcardInvoice(commcard_invoice);
            indrefund.SetCommcardTaxAmount(commcard_tax_amount);
            indrefund.SetDynamicDescriptor("123456");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(indrefund);
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
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
