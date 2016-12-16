namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResMpiTxn
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string data_key = "SzSrdoy0bt8UFXOtgS88wFAy7";
            string amount = "1.00";
            Random r = new Random();
			StringBuilder sb = new StringBuilder();
			for(int i=0; i< 20; i++)
			{
				sb.Append(r.Next(0,9));
			}
            string xid = sb.ToString();
            string MD = xid + "mycardinfo" + amount;
            string merchantUrl = "www.mystoreurl.com";
            string accept = "true";
            string userAgent = "Mozilla";
            string processing_country_code = "CA";
            bool status_check = false;

            ResMpiTxn resMpiTxn = new ResMpiTxn();
            resMpiTxn.SetDataKey(data_key);
            resMpiTxn.SetXid(xid);
            resMpiTxn.SetAmount(amount);
            resMpiTxn.SetMD(MD);
            resMpiTxn.SetMerchantUrl(merchantUrl);
            resMpiTxn.SetAccept(accept);
            resMpiTxn.SetUserAgent(userAgent);

            //************************OPTIONAL VARIABLES***************************

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resMpiTxn);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            /**********************   REQUEST  ************************/

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("MpiMessage = " + receipt.GetMpiMessage());
                Console.WriteLine("MpiSuccess = " + receipt.GetMpiSuccess());

                if (receipt.GetMpiSuccess() == "true")
                {
                    Console.WriteLine(receipt.GetInLineForm());
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    } // end TestResMpiTxn
}
