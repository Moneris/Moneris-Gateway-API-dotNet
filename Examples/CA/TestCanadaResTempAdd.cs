namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResTempAdd
    {
        public static void Main(string[] args)
        {
            string store_id = "store1";
            string api_token = "yesguy";
            string pan = "5454545454545454";
            string expdate = "1901"; //YYMM format
            string crypt_type = "7";
            string duration = "900";
            string processing_country_code = "CA";
            bool status_check = false;

            ResTempAdd resTempAdd = new ResTempAdd();
            resTempAdd.SetPan(pan);
            resTempAdd.SetExpDate(expdate);
            resTempAdd.SetDuration(duration);
            resTempAdd.SetCryptType(crypt_type);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resTempAdd);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
