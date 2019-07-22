namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaMCPGetRate
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string processing_country_code = "CA";
            bool status_check = false;

            MCPGetRate mcpGetRate = new MCPGetRate();
			mcpGetRate.SetMCPVersion("1.0"); //MCP Version number.  Should always be 1.0
			mcpGetRate.SetMCPRateTxnType("P"); //P or R are valid values (Purchase or Refund)

			MCPRate rate = new MCPRate();
			rate.AddCardholderAmount("500", "840");
			rate.AddMerchantSettlementAmount("500", "840");

			mcpGetRate.SetMCPRateInfo(rate);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcpGetRate);
            mpgReq.Send();

            try
            {
            
				Receipt receipt = mpgReq.GetReceipt();

	            Console.WriteLine("RateTxnType = " + receipt.GetRateTxnType());
	            Console.WriteLine("MCPRateToken = " + receipt.GetMCPRateToken());
	            
	            Console.WriteLine("RateInqStartTime = " + receipt.GetRateInqStartTime());  //The time (unix UTC) of when the rate is requested
	            Console.WriteLine("RateInqEndTime = " + receipt.GetRateInqEndTime());  //The time (unix UTC) of when the rate is returned
	            Console.WriteLine("RateValidityStartTime = " + receipt.GetRateValidityStartTime());    //The time (unix UTC) of when the rate is valid from
	            Console.WriteLine("RateValidityEndTime = " + receipt.GetRateValidityEndTime());    //The time (unix UTC) of when the rate is valid until
	            Console.WriteLine("RateValidityPeriod = " + receipt.GetRateValidityPeriod());  //The time in minutes this rate is valid for
	            
	            Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	            Console.WriteLine("Message = " + receipt.GetMessage());
	            Console.WriteLine("Complete = " + receipt.GetComplete());
	            Console.WriteLine("TransDate = " + receipt.GetTransDate());
	            Console.WriteLine("TransTime = " + receipt.GetTransTime());
	            Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
	            
	            //RateData
				for (int index = 0; index < receipt.GetRatesCount(); index++)
				{
	                Console.WriteLine("MCPRate = " + receipt.GetMCPRate(index));
	                Console.WriteLine("MerchantSettlementCurrency = " + receipt.GetMerchantSettlementCurrency(index));
	                Console.WriteLine("MerchantSettlementAmount = " + receipt.GetMerchantSettlementAmount(index));    //Domestic(CAD) amount
	                Console.WriteLine("CardholderCurrencyCode = " + receipt.GetCardholderCurrencyCode(index));
	                Console.WriteLine("CardholderAmount = " + receipt.GetCardholderAmount(index));    //Foreign amount
	                
	                Console.WriteLine("MCPErrorStatusCode = " + receipt.GetMCPErrorStatusCode(index));
	                Console.WriteLine("MCPErrorMessage = " + receipt.GetMCPErrorMessage(index));
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
