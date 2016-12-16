namespace Moneris
{
    using System;
	using System.Text;

    public class TestCanadaMpiTxn
    {
		public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
            string amount = "1.00";
			Random r = new Random();
			StringBuilder sb = new StringBuilder();
			for(int i=0; i< 20; i++)
			{
				sb.Append(r.Next(0,9));
			}
            string xid = sb.ToString();
            //string MD = xid + "mycardinfo" + amount;
            string MD = "xid=99999999999999992464&amp;pan=4242424242424242&amp;expiry=1511&amp;amount=1.00";
            string merchantUrl = "https://YOUR_MPI_RESPONSE_URL";
            string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Safari/537.36";
            string processing_country_code = "CA";
            string pan = "4242424242424242";
            string expdate = "1511";
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
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    } // end TestResMpiTxn
}
