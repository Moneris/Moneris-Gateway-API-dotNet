namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResPurchaseCC
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "monca00597";
            string api_token = "O27AbCbxQorPggMQe6hU";
            string data_key = "m5FubAMXr8IK4lC0eTv0c9zA0";
            string amount = "4.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string crypt_type = "1";
            string descriptor = "my descriptor";
            string processing_country_code = "CA";
            string expdate = "2301"; //For Temp Token
            bool status_check = false;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("C");
			cof.SetPaymentInformation("0");
			//cof.SetIssuerId("168451306048014");

            ResPurchaseCC resPurchaseCC = new ResPurchaseCC();
            resPurchaseCC.SetDataKey(data_key);
            resPurchaseCC.SetOrderId(order_id);
            resPurchaseCC.SetCustId(cust_id);
            resPurchaseCC.SetAmount(amount);
            resPurchaseCC.SetCryptType(crypt_type);
            resPurchaseCC.SetDynamicDescriptor(descriptor);
			resPurchaseCC.SetCofInfo(cof);
		    resPurchaseCC.SetExpDate(expdate); //optional - use for temp token only

            //NT Response Option
			bool get_nt_response = true;
			resPurchaseCC.SetGetNtResponse(get_nt_response);

            // InstallmentInfo installmentInfo = new InstallmentInfo();
            // installmentInfo.SetPlanId("ae859ef1-eb91-b708-8b80-1dd481746401");
            // installmentInfo.SetPlanIdRef("0000000065");
            // installmentInfo.SetTacVersion("2");
            // resPurchaseCC.SetInstallmentInfo(installmentInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resPurchaseCC);
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

                // InstallmentResults installmentResults = receipt.GetInstallmentResults();

                // Console.WriteLine("\nPlanId = " + installmentResults.GetPlanId() +"\n");
                // Console.WriteLine("PlanIDRef = " + installmentResults.GetPlanIDRef());
                // Console.WriteLine("TacVersion = " + installmentResults.GetTacVersion());
                // Console.WriteLine("PlanAcceptanceId = " + installmentResults.GetPlanAcceptanceId());
                // Console.WriteLine("PlanStatus = " + installmentResults.GetPlanStatus()); 
                // Console.WriteLine("PlanResponse = " + installmentResults.GetPlanResponse());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
