namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResTokenizeCC
    {
        public static void Main(string[] args)
        {
            string store_id = "monca00544";
            string api_token = "5JLbUfpl9JsQzPmbyje7";
            string order_id = "Test1737561056105";
            string txn_number = "5354-0_1023";
            string phone = "0000000000";
            string email = "bob@smith.com";
            string note = "my note";
            string cust_id = "customer1";
			string data_key_format = "0";
            string processing_country_code = "CA";
            bool status_check = false;

            AvsInfo avsCheck = new AvsInfo();
            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

			CofInfo cof = new CofInfo();
			cof.SetIssuerId("168451306048014");

            ResTokenizeCC resTokenizeCC = new ResTokenizeCC();
            resTokenizeCC.SetOrderId(order_id);
            resTokenizeCC.SetTxnNumber(txn_number);
            resTokenizeCC.SetCustId(cust_id);
            resTokenizeCC.SetPhone(phone);
            resTokenizeCC.SetEmail(email);
            resTokenizeCC.SetNote(note);
            resTokenizeCC.SetAvsInfo(avsCheck);
			resTokenizeCC.SetCofInfo(cof);
            //resTokenizeCC.SetDataKeyFormat(data_key_format); //optional
            resTokenizeCC.SetReturnIssuerId(true);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resTokenizeCC);
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
                Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
                Console.WriteLine("Issuer ID = " + receipt.GetIssuerId());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
