namespace Moneris
{
    using System;
    public class TestUSATrack2IndependentRefund
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "Ced_Benson32";
            string amount = "5.00";
            string track2 = ";5258968987035454=06061015454001060101?";
            string pan = "";
            string exp_date = "0000"; //YYMM format
            string pos_code = "00";
            string processing_country_code = "US";
            bool status_check = false;

            Track2IndependentRefund track2indrefund = new Track2IndependentRefund();
            track2indrefund.SetOrderId(order_id);
            track2indrefund.SetCustId(cust_id);
            track2indrefund.SetAmount(amount);
            track2indrefund.SetTrack2(track2);
            track2indrefund.SetPan(pan);
            track2indrefund.SetExpDate(exp_date);
            track2indrefund.SetPosCode(pos_code);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(track2indrefund);
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
