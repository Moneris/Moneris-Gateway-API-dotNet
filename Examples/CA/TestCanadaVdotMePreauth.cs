using System;
namespace Moneris
{
    class TestCanadaVdotMePreauth
    {
        public static void Main(string[] args)
        {
            string store_id = "store2";
            string api_token = "yesguy";
            string amount = "5.00";
            string crypt_type = "7";
            string order_id = "VmeOrder" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string call_id = "2336392495138357172";
            string cust_id = "my customer id";
            string processing_country_code = "CA";
            bool status_check = false;

            VdotMePreauth vMePreauthRequest = new VdotMePreauth();
            vMePreauthRequest.SetOrderId(order_id);
            vMePreauthRequest.SetAmount(amount);
            vMePreauthRequest.SetCallId(call_id);
            vMePreauthRequest.SetCustId(cust_id);
            vMePreauthRequest.SetCryptType(crypt_type);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vMePreauthRequest);
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
                Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                Console.WriteLine("\r\nPress the enter key to exit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
