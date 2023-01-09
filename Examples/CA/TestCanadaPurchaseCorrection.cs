namespace Moneris
{
    using System;
    public class TestCanadaPurchaseCorrection
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test20160815041411";
            string txn_number = "118147-0_10";
            string crypt = "7";
            string dynamic_descriptor = "123456";
            string processing_country_code = "CA";
            bool status_check = false;

            PurchaseCorrection purchasecorrection = new PurchaseCorrection();
            purchasecorrection.SetOrderId(order_id);
            purchasecorrection.SetTxnNumber(txn_number);
            purchasecorrection.SetCryptType(crypt);
            purchasecorrection.SetDynamicDescriptor(dynamic_descriptor);
            purchasecorrection.SetCustId("my customer id");

            //Optional
            InstallmentInfo installmentInfo = new InstallmentInfo();
            installmentInfo.SetPlanId("ae859ef1-eb91-b708-8b80-1dd481746401");
            installmentInfo.SetPlanIdRef("0000000065");
            installmentInfo.SetTacVersion("2");
            //purchasecorrection.SetInstallmentInfo(installmentInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(purchasecorrection);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("ISO = " + receipt.GetISO());
                Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
                 
                // InstallmentResults installmentResults = receipt.GetInstallmentResults();

                // Console.WriteLine("\nPlanId = " + installmentResults.GetPlanId() +"\n");
                // Console.WriteLine("PlanIDRef = " + installmentResults.GetPlanIDRef());
                // Console.WriteLine("TacVersion = " + installmentResults.GetTacVersion());
                // Console.WriteLine("PlanAcceptanceId = " + installmentResults.GetPlanAcceptanceId());
                // Console.WriteLine("PlanStatus = " + installmentResults.GetPlanStatus()); 
                // Console.WriteLine("PlanResponse = " + installmentResults.GetPlanResponse());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
