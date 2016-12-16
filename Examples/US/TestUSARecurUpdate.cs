namespace Moneris
{
    using System;
    public class TestUSARecurUpdate
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test481881053";
            string cust_id = "bob";
            //string recur_amount = "45.00";
            string pan = "5454545454545454";
            string expiry_date = "1701";
            //string p_account_number = "123123123";
            //string presentation_type = "X";
            //string add_num = "";
            //string total_num = "";
            //string hold = "";
            //string terminate = "false";
            string processing_country_code = "US";

            RecurUpdate recurUpdate = new RecurUpdate();
            recurUpdate.SetOrderId(order_id);
            recurUpdate.SetCustId(cust_id);
            //recurUpdate.SetCustId(cust_id);
            //recurUpdate.SetRecurAmount(recur_amount);
            recurUpdate.SetPan(pan);
            recurUpdate.SetExpDate(expiry_date);
            //recurUpdate.SetPAccountNumber(p_account_number);
            //recurUpdate.SetPresentationType(presentation_type);
            //recurUpdate.SetAddNumRecurs(add_num);
            //recurUpdate.SetTotalNumRecurs(total_num);
            //recurUpdate.SetHold(hold);
            //recurUpdate.SetTerminate(terminate);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(recurUpdate);
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
