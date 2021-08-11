namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResCavvPreauthCC
    {
        public static void Main(string[] args)
        {
            string store_id = "store1";
            string api_token = "yesguy1";
            string data_key = "4INQR1A8ocxD0oafSz50LADXy";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
            string expdate = "1911";
			string processing_country_code = "CA";
            bool status_check = false;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            ResCavvPreauthCC resCavvPreauthCC = new ResCavvPreauthCC();
            resCavvPreauthCC.SetOrderId(order_id);
            resCavvPreauthCC.SetDataKey(data_key);
            resCavvPreauthCC.SetCustId(cust_id);
            resCavvPreauthCC.SetAmount(amount);
            resCavvPreauthCC.SetCavv(cavv);
			//resCavvPreauthCC.SetExpDate(expdate); //mandatory for temp token only
			resCavvPreauthCC.SetThreeDSVersion("2"); //Mandatory for 3DS Version 2.0+
			resCavvPreauthCC.SetThreeDSServerTransId("e11d4985-8d25-40ed-99d6-c3803fe5e68f"); //Mandatory for 3DS Version 2.0+ - obtained from MpiCavvLookup or MpiThreeDSAuthentication
			//resCavvPreauthCC.SetDsTransId("12345"); //Optional - to be used only if you are using 3rd party 3ds 2.0 service
            resCavvPreauthCC.SetCofInfo(cof);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resCavvPreauthCC);
            mpgReq.SetStatusCheck(status_check);
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
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
				Console.WriteLine("ThreeDSVersion = " + receipt.GetThreeDSVersion());

                //ResolveData
                Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
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
