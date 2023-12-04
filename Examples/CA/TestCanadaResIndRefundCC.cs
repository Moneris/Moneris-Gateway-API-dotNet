namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResIndRefundCC
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");   
            string store_id = "store1";
            string api_token = "yesguy";
            string data_key = "qJD5kCZiCjsfabKH7WuxoHyZx";
            string amount = "1.00";
            string cust_id = "customer1";
            string crypt_type = "1";
            string processing_country_code = "CA";
            bool status_check = false;

            ResIndRefundCC resIndRefundCC = new ResIndRefundCC();
            resIndRefundCC.SetOrderId(order_id);
            resIndRefundCC.SetCustId(cust_id);
            resIndRefundCC.SetAmount(amount);
            resIndRefundCC.SetCryptType(crypt_type);
            resIndRefundCC.SetDataKey(data_key);

            //NT Response Option
			bool get_nt_response = true;
			resIndRefundCC.SetGetNtResponse(get_nt_response);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resIndRefundCC);
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
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());

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
