namespace Moneris
{
    using System;
    public class TestCanadaEncResUpdateCC
    {
        public static void Main(string[] args)
        {

            /******************* REQUEST VARIABLES*******************************/

            string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id = "nqa";
			string device_type = "idtech_bdk";
			string crypt = "7";
			string enc_track2 = "02840085000000000416BC6FCE0D7A8B07E6278E60D237CA9362767ADC2C93A2EA5D9BED3E4D1A791C3F4FC61C1800486A8A6B6CCAA00431353131FFFF3141594047A00090055103";
			string processing_country_code = "CA";
			string data_key = "gF5IpsWD3s42r2TZxZyecE9Gs";
			bool status_check = false;
            

            EncResUpdateCC encresupdatecc = new EncResUpdateCC();
			encresupdatecc.SetDataKey(data_key);
            encresupdatecc.SetCustId(cust_id);
			encresupdatecc.SetNote("Just a note2");
			encresupdatecc.SetEmail("example1@test.com");
			encresupdatecc.SetPhone("866-319-7450");
			encresupdatecc.SetEncTrack2(enc_track2);
			encresupdatecc.SetDeviceType(device_type);
			encresupdatecc.SetCryptType(crypt);
			
			/*************** Address Verification Service **********************/
            AvsInfo avsCheck = new AvsInfo();
            avsCheck.SetAvsStreetNumber("3300");
            avsCheck.SetAvsStreetName("Bloor Street");
            avsCheck.SetAvsZipCode("M2X2X2");

            encresupdatecc.SetAvsInfo(avsCheck);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(encresupdatecc);
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
                Console.WriteLine("\nCust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
