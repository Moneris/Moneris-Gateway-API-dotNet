namespace Moneris
{
    using System;
    public class TestCanadaRecurUpdate
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test20150625013553";
            string cust_id = "antonio";
            string recur_amount = "1.50";
            string pan = "4242424242424242";
            string expiry_date = "1901";
            //string add_num = "";
            //string total_num = "";
            //string hold = "";
            //string terminate = "";
            string processing_country_code = "CA";
            bool status_check = false;
			
			CofInfo cof = new CofInfo();
			cof.SetIssuerId("139X3130ASCXAS9");

            RecurUpdate recurUpdate = new RecurUpdate();
            recurUpdate.SetOrderId(order_id);
            recurUpdate.SetCustId(cust_id);
            recurUpdate.SetRecurAmount(recur_amount);
            recurUpdate.SetPan(pan);
            recurUpdate.SetExpDate(expiry_date);
            //recurUpdate.SetAddNumRecurs(add_num);
            //recurUpdate.SetTotalNumRecurs(total_num);
            //recurUpdate.SetHold(hold);
            //recurUpdate.SetTerminate(terminate);
			recurUpdate.SetCofInfo(cof);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(recurUpdate);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("RecurUpdateSuccess = " + receipt.GetRecurUpdateSuccess());
                Console.WriteLine("NextRecurDate = " + receipt.GetNextRecurDate());
                Console.WriteLine("RecurEndDate = " + receipt.GetRecurEndDate());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
