namespace Moneris
{
    using System;
	using System.Text;

    public class TestUSAMpiTxn
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
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
            string processing_country_code = "US";
            string pan = "4242424242424242";
            string expdate = "1905";
            bool status_check = false;

            MpiTxn mpiTxn = new MpiTxn();
            mpiTxn.SetXid(xid);
            mpiTxn.SetPan(pan);
            mpiTxn.SetExpDate(expdate);
            mpiTxn.SetAmount(amount);
            mpiTxn.SetMD(MD);
            mpiTxn.SetMerchantUrl(merchantUrl);
            mpiTxn.SetAccept(accept);
            mpiTxn.SetUserAgent(userAgent);

            //************************OPTIONAL VARIABLES***************************

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mpiTxn);
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    } // end TestResMpiTxn
}
