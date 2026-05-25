namespace Moneris
{
    using System;

    public class TestCanadaPBBGetAccessToken
    {
      
        public static void Main(string[] args)
        {
            string store_id = "monca03650";
            string api_token = "7Yw0MPTlhjBRcZiE6837";
            string processing_country_code = "CA";

            PBB_GetAccessToken pbbGetAccessToken = new PBB_GetAccessToken();

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(pbbGetAccessToken);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();
                

                Console.WriteLine("TokenType = " + receipt.getTokenType());
                Console.WriteLine("ExpiresIn = " + receipt.getExpiresIn());
                Console.WriteLine("ExtExpiresIn = " + receipt.getExtExpiresIn());
                Console.WriteLine("AccessToken = " + receipt.getAccessToken());
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

