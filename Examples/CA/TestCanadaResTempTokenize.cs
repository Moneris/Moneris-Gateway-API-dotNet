namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResTempTokenize
    {
        public static void Main(string[] args)
        {
            String store_id = "moneris";
            String api_token = "hurgle";

            String order_id = "mvt3213606574";
            String txn_number = "200055-0_10";
            String crypt_type = "7";
            String duration = "60";
            String processing_country_code = "CA";

            ResTempTokenize temp_tokenize = new ResTempTokenize();
            temp_tokenize.SetOrderId(order_id);
            temp_tokenize.SetTxnNumber(txn_number); 
            temp_tokenize.SetDuration(duration);
            temp_tokenize.SetCryptType(crypt_type);
            //temp_tokenize.setDataKeyFormat("1"); //1=F6L4 w/ Length preserve, 2=F6L4 w/o Length preserve

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(temp_tokenize);
            mpgReq.Send();

            try
            {
                Receipt resreceipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + resreceipt.GetDataKey());
                Console.WriteLine("ResponseCode = " + resreceipt.GetResponseCode());
                Console.WriteLine("Message = " + resreceipt.GetMessage());
                Console.WriteLine("TransDate = " + resreceipt.GetTransDate());
                Console.WriteLine("TransTime = " + resreceipt.GetTransTime());
                Console.WriteLine("Complete = " + resreceipt.GetComplete());
                Console.WriteLine("TimedOut = " + resreceipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + resreceipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + resreceipt.GetPaymentType() + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
