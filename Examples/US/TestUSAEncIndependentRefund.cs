namespace Moneris
{
    using System;
    public class TestUSAEncIndependentRefund
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "Ced_Benson32";
            string amount = "5.00";
            string device_type = "idtech";
            string crypt = "7";
            string enc_track2 = "028400850000000004142348E7643B2599ACC00517C5AB6FB164486B1A4A83E7A81048D6CBA51604FDD12B72C228028E727AF6664C7A0431393035FFFF3141594047A0009E79C903";
            string processing_country_code = "US";
            bool status_check = false;

            EncIndRefund encindrefund = new EncIndRefund();
            encindrefund.SetOrderId(order_id);
            encindrefund.SetCustId(cust_id);
            encindrefund.SetAmount(amount);
            encindrefund.SetEncTrack2(enc_track2);
            encindrefund.SetDeviceType(device_type);
            encindrefund.SetCryptType(crypt);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(encindrefund);
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
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
