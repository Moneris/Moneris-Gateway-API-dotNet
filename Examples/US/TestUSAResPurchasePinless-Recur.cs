namespace Moneris
{
    using Moneris;

    using System;
    using System.Text;
    using System.Collections;

    public class TestUSAResPurchasePinlessRecur
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string data_key = "AhcyWhamRPNnhyU8RYPxM3saK";
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string intended_use = "1";
            string p_account_number = "23456789";
            string processing_country_code = "US";

            ResPurchasePinless resPurchasePinless = new ResPurchasePinless();
            resPurchasePinless.SetDataKey(data_key);
            resPurchasePinless.SetOrderId(order_id);
            resPurchasePinless.SetCustId(cust_id);
            resPurchasePinless.SetAmount(amount);
            resPurchasePinless.SetIntendedUse(intended_use);
            resPurchasePinless.SetPAccountNumber(p_account_number);

            /************************* Recur Variables **********************************/

            string recur_unit = "month";
            string start_now = "true";
            string start_date = "2018/12/01";
            string num_recurs = "12";
            string period = "1";
            string recur_amount = "30.00";

            /************************* Recur Object Option1 ******************************/

            Recur recurring_cycle = new Recur(recur_unit, start_now, start_date,
                               num_recurs, period, recur_amount);

            resPurchasePinless.SetRecur(recurring_cycle);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resPurchasePinless);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("RecurSuccess = " + receipt.GetRecurSuccess());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Presentation Type = " + receipt.GetResDataPresentationType());
                Console.WriteLine("P Account Number = " + receipt.GetResDataPAccountNumber());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
