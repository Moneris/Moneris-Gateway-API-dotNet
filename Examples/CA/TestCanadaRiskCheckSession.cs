namespace Moneris
{
    using System;
    using System.Collections;
    public class TestCanadaRiskCheckSession
    {
        public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string session_id = "abc123";
            string service_type = "session";
            //string event_type = "LOGIN";
            string processing_country_code = "CA";
            bool status_check = false;

            SessionQuery sq = new SessionQuery();
            sq.SetOrderId(order_id);
            sq.SetSessionId(session_id);
            sq.SetServiceType(service_type);
            sq.SetEventType(service_type);
            //sq.SetPolicy("");
            //sq.SetDeviceId("4EC40DE5-0770-4fa0-BE53-981C067C598D");
            sq.SetAccountLogin("13195417-8CA0-46cd-960D-14C158E4DBB2");
            sq.SetPasswordHash("489c830f10f7c601d30599a0deaf66e64d2aa50a");
            sq.SetAccountNumber("3E17A905-AC8A-4c8d-A417-3DADA2A55220");
            sq.SetAccountName("4590FCC0-DF4A-44d9-A57B-AF9DE98B84DD");
            sq.SetAccountEmail("3CAE72EF-6B69-4a25-93FE-2674735E78E8@test.threatmetrix.com");
            //sq.SetAccountTelephone("5556667777");
            sq.SetPan("4242424242424242");
            //sq.SetAccountAddressStreet1("3300 Bloor St W");
            //sq.SetAccountAddressStreet2("4th Flr West Tower");
            //sq.SetAccountAddressCity("Toronto");
            //sq.SetAccountAddressState("Ontario");
            //sq.SetAccountAddressCountry("Canada");
            //sq.SetAccountAddressZip("M8X2X2");
            //sq.SetShippingAddressStreet1("3300 Bloor St W");
            //sq.SetShippingAddressStreet2("4th Flr West Tower");
            //sq.SetShippingAddressCity("Toronto");
            //sq.SetShippingAddressState("Ontario");
            //sq.SetShippingAddressCountry("Canada");
            //sq.SetShippingAddressZip("M8X2X2");
            //sq.SetLocalAttrib1("a");
            //sq.SetLocalAttrib2("b");
            //sq.SetLocalAttrib3("c");
            //sq.SetLocalAttrib4("d");
            //sq.SetLocalAttrib5("e");
            //sq.SetTransactionAmount("1.00");
            //sq.SetTransactionCurrency("840");
            //set SessionAccountInfo
            sq.SetTransactionCurrency("CAN");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(sq);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Hashtable results = new Hashtable();
                string[] rules;
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());

                // results = receipt.GetResult();

                //Iterate through the response
                //  IDictionaryEnumerator r = results.GetEnumerator();
                // while (r.MoveNext())
                // {
                //     Console.WriteLine(r.Key.ToString() + " = " + r.Value.ToString());
                // }

                //Iterate through the rules that were fired
                rules = receipt.GetRules();

                for (int i = 0; i < rules.Length; i++)
                {
                    Console.WriteLine("RuleName = " + rules[i]);
                    Console.WriteLine("RuleCode = " + receipt.GetRuleCode(rules[i]));
                    Console.WriteLine("RuleMessageEn = " + receipt.GetRuleMessageEn(rules[i]));
                    Console.WriteLine("RuleMessageFr = " + receipt.GetRuleMessageFr(rules[i]));
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    } // end TestRiskCheckSession
}
