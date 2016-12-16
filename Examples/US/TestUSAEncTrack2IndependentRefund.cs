namespace Moneris
{
    using System;
    public class TestUSAEncTrack2IndependentRefund
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "my customer id";
            string amount = "5.00";
            string pos_code = "00";
            string device_type = "idtech";
            string processing_country_code = "US";
            string enc_track2 = "";

            EncTrack2IndependentRefund encindrefund = new EncTrack2IndependentRefund();
            encindrefund.SetOrderId(order_id);
            encindrefund.SetCustId(cust_id);
            encindrefund.SetAmount(amount);
            encindrefund.SetEncTrack2(enc_track2);
            encindrefund.SetPosCode(pos_code);
            encindrefund.SetDeviceType(device_type);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(encindrefund);
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
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
