namespace Moneris
{
    using System;

    public class TestCanadaContactlessRefund
    {
        public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
            string order_id = "Test20150723120048";
            string amount = "1.00";
            string txn_number = "230675-0_10";
            string processing_country_code = "CA";
            bool status_check = false;

            ContactlessRefund refund = new ContactlessRefund();
            refund.SetOrderId(order_id);
            refund.SetAmount(amount);
            refund.SetTxnNumber(txn_number);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(refund);
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
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
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
