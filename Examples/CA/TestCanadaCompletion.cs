namespace Moneris
{
    using System;
    public class TestCanadaCompletion
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test20160815041528";
            string amount = "2.00";
            string txn_number = "118149-0_10";
            string crypt = "7";
            string cust_id = "my customer id";
            string dynamic_descriptor = "my descriptor";
            string ship_indicator = "F";
            string processing_country_code = "CA";
            bool status_check = false;

            Completion completion = new Completion();
            completion.SetOrderId(order_id);
            completion.SetCompAmount(amount);
            completion.SetTxnNumber(txn_number);
            completion.SetCryptType(crypt);
            completion.SetCustId(cust_id);
            completion.SetDynamicDescriptor(dynamic_descriptor);
            //completion.SetShipIndicator(ship_indicator); //optional

            //Optional
            InstallmentInfo installmentInfo = new InstallmentInfo();
            installmentInfo.SetPlanId("ae859ef1-eb91-b708-8b80-1dd481746401");
            installmentInfo.SetPlanIdRef("0000000065");
            installmentInfo.SetTacVersion("2");
            //completion.SetInstallmentInfo(installmentInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(completion);
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
