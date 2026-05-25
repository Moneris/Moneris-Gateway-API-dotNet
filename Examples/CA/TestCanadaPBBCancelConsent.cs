namespace Moneris
{
    using System;

    public class TestCanadaPBBCancelConsent
    {
      
        public static void Main(string[] args)
        {
            string store_id = "monca03650";
            string api_token = "7Yw0MPTlhjBRcZiE6837";
            string processing_country_code = "CA";
            string consentId = "1e72d58d-2b53-41a9-8be1-3453868cbba3";
            string cancelRef = "e32f9a6b-843c-4fbb-a8ac-2b11bbca7fd3";
            string cancelReason="this is the optional cancel ";

            PBB_CancelConsent pbbCancelConsent = new PBB_CancelConsent();
            pbbCancelConsent.setConsentId(consentId);
            pbbCancelConsent.setCancelRef(cancelRef);
            pbbCancelConsent.setCancelReason(cancelReason);
            
            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(pbbCancelConsent);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();
                if((receipt.getCorrelationId()!=null)&& !(receipt.getCorrelationId().Equals("")))
                {   
                    Console.WriteLine("RequestId = " + receipt.getRequestId());
                    Console.WriteLine("CorrelationId = "+ receipt.getCorrelationId());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("CODE = " +  receipt.getCode());
                    Console.WriteLine("Type = " + receipt.getType());
                    Console.WriteLine("Message" + receipt.GetMessage());
                    Console.ReadLine();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

