namespace Moneris
{
    using System;
    using System.Text.RegularExpressions;
    public class TestUSAEncTrack2Purchase
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string cust_id = "LBriggs";
            string amount = "1.00";
            string pos_code = "00";
            string device_type = "idtech";
            string processing_country_code = "US";
            bool status_check = false;
            string dynamic_descriptor = "my descriptor";

            string enc_track2 =
                "02D901801F4F2800039B%*4924********4030^TESTCARD/MONERIS^***************************************"
              + "**?*;4924********4030=********************?*A7150C78335A5024949516FDA9A68A91C4FBAB1279DD1DE2283D"
              + "BEBB2C6B3FDEACF7B5B314219D76C00890F347A9640EFE90023E31622F5FD95C14C0362DD2EAB28ADEB46B8B577DA1A1"
              + "8B707BCC7E48068EFF1882CFB4B369BDC4BB646C870D6083239860B23837EA91DB3F1D8AD066DAAACE2B2DA18D563E4F"
              + "1EF997696337B8999E9C707DEC4CB0410B887291CAF2EE449573D01613484B80760742A3506C31415939320000A00028"
              + "3C5E03";
            

            EncTrack2Purchase encpurchase = new EncTrack2Purchase();
            encpurchase.SetOrderId(order_id);
            encpurchase.SetCustId(cust_id);
            encpurchase.SetAmount(amount);
            encpurchase.SetEncTrack2(enc_track2);
            encpurchase.SetPosCode(pos_code);
            encpurchase.SetDeviceType(device_type);
            encpurchase.SetDynamicDescriptor(dynamic_descriptor);

            AvsInfo avsCheck = new AvsInfo();
            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

            encpurchase.SetAvsInfo(avsCheck);

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
                Console.WriteLine("AVS Response = " + receipt.GetAvsResultCode());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
