namespace Moneris
{
    using System;
    public class TestUSAEncPurchase
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string amount = "5.00";
            string crypt = "7";
            string commcard_invoice = "INVC090";
            string commcard_tax_amount = "1.00";
            string processing_country_code = "US";
            bool status_check = false;
            string enc_track2 = "028400850000000004142348E7643B2599ACC00517C5AB6FB164486B1A4A83E7A81048D6CBA51604FDD12B72C228028E727AF6664C7A0431393035FFFF3141594047A0009E79C903";
            string device_type = "idtech"; 
      
            EncPurchase encpurchase = new EncPurchase();
            encpurchase.SetOrderId(order_id);
            encpurchase.SetAmount(amount);
            encpurchase.SetEncTrack2(enc_track2);
            encpurchase.SetDeviceType(device_type);
            encpurchase.SetCryptType(crypt);
            encpurchase.SetCommcardInvoice(commcard_invoice);
            encpurchase.SetCommcardTaxAmount(commcard_tax_amount);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(encpurchase);
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
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
