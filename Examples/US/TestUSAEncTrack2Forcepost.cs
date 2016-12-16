namespace Moneris
{
    using System;
    public class TestUSAEncTrack2Forcepost
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
            string auth_code = "";
            string processing_country_code = "US";
            bool status_check = false;
            string descriptor = "my descriptor";
            string enc_track2 = "";            

            EncTrack2Forcepost enctrack2fp = new EncTrack2Forcepost();
            enctrack2fp.SetOrderId(order_id);
            enctrack2fp.SetCustId(cust_id);
            enctrack2fp.SetAmount(amount);
            enctrack2fp.SetEncTrack2(enc_track2);
            enctrack2fp.SetPosCode(pos_code);
            enctrack2fp.SetDeviceType(device_type);
            enctrack2fp.SetAuthCode(auth_code);
            enctrack2fp.SetDynamicDescriptor(descriptor);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(enctrack2fp);
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
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
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
