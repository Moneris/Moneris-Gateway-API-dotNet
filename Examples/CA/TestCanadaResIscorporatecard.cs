namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResIscorporatecard
    {
        public static void Main(string[] args)
        {
            string store_id = "store1";
            string api_token = "yesguy";
            string data_key = "eLqsADfwqHDxIpJG9vLnELx01";
            string processing_country_code = "CA";
            bool status_check = false;

            ResIscorporatecard resIscorporatecard = new ResIscorporatecard();
            resIscorporatecard.SetDataKey(data_key);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resIscorporatecard);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();
            
            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("CorporateCard = " + receipt.GetCorporateCard());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
