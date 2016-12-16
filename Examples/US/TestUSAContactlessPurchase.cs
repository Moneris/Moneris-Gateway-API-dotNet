namespace Moneris
{
    using System;

    public class TestUSAContactlessPurchase
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "my customer id";
            string amount = "1.00";
            string track2 = ";4924190000004030=09121214797536211133?";
            string commcard_invoice = "INVC090";
            string commcard_tax_amount = "1.00";
            string dynamic_descriptor = "my descriptor";
            string processing_country_code = "US";
            string pos_code = "00";
            bool status_check = false;

            ContactlessPurchase purchase = new ContactlessPurchase();
            purchase.SetOrderId(order_id);
            purchase.SetAmount(amount);
            purchase.SetTrack2(track2);
            purchase.SetPosCode(pos_code);
            purchase.SetCustId(cust_id);
            purchase.SetCommcardInvoice(commcard_invoice);
            purchase.SetCommcardTaxAmount(commcard_tax_amount);
            purchase.SetDynamicDescriptor(dynamic_descriptor);


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
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                //Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                //Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                //Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
