namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResGetExpiring
    {
        public static void Main(string[] args)
        {
            string store_id = "store1";
            string api_token = "yesguy";
            string processing_country_code = "CA";
            bool status_check = false;

            ResGetExpiring resGetExpiring = new ResGetExpiring();

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resGetExpiring);
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

                //ResolveData
                foreach (string dataKey in receipt.GetDataKeys())
                {
                    Console.WriteLine("\nDataKey = " + dataKey);
                    Console.WriteLine("Payment Type = " + receipt.GetExpPaymentType(dataKey));
                    Console.WriteLine("Cust ID = " + receipt.GetExpCustId(dataKey));
                    Console.WriteLine("Phone = " + receipt.GetExpPhone(dataKey));
                    Console.WriteLine("Email = " + receipt.GetExpEmail(dataKey));
                    Console.WriteLine("Note = " + receipt.GetExpNote(dataKey));
                    Console.WriteLine("Masked Pan = " + receipt.GetExpMaskedPan(dataKey));
                    Console.WriteLine("Exp Date = " + receipt.GetExpExpdate(dataKey));
                    Console.WriteLine("Crypt Type = " + receipt.GetExpCryptType(dataKey));
                    Console.WriteLine("Avs Street Number = " + receipt.GetExpAvsStreetNumber(dataKey));
                    Console.WriteLine("Avs Street Name = " + receipt.GetExpAvsStreetName(dataKey));
                    Console.WriteLine("Avs Zipcode = " + receipt.GetExpAvsZipCode(dataKey));
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
