namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResForcePostCC
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store1";
            string api_token = "yesguy";
            string data_key = "eLqsADfwqHDxIpJG9vLnELx01";
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
			string auth_code = "245465";
            string crypt_type = "7";
            string descriptor = "my descriptor";
            string processing_country_code = "CA";
            bool status_check = false;

            ResForcePostCC resForcePostCC = new ResForcePostCC();
            resForcePostCC.SetDataKey(data_key);
            resForcePostCC.SetOrderId(order_id);
            resForcePostCC.SetCustId(cust_id);
            resForcePostCC.SetAmount(amount);
			resForcePostCC.SetAuthCode(auth_code);
            resForcePostCC.SetCryptType(crypt_type);
            resForcePostCC.SetDynamicDescriptor(descriptor);

            //NT Response Option
			bool get_nt_response = true;
			resForcePostCC.SetGetNtResponse(get_nt_response);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resForcePostCC);
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
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
                
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
                
                if (get_nt_response)
				{
					Console.WriteLine("\nNTResponseCode = " + receipt.GetNTResponseCode());
					Console.WriteLine("NTMessage = " + receipt.GetNTMessage());
					Console.WriteLine("NTUsed = " + receipt.GetNTUsed());
                    Console.WriteLine("NTTokenBin = " + receipt.GetNTTokenBin());
                    Console.WriteLine("NTTokenLast4 = " + receipt.GetNTTokenLast4());
                    Console.WriteLine("NTTokenExpDate = " + receipt.GetNTTokenExpDate());
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
