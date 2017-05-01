namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaPaypassTxn
    {
        public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
			
			Random r = new Random();
			StringBuilder sb = new StringBuilder();
			for(int i=0; i< 20; i++)
			{
				sb.Append(r.Next(0,9));
			}
			
            string xid = sb.ToString();
            string amount = "1.00";
            string mp_request_token = "47edbc7b56cac2b7ed27ab4d62214407";
            string MD = "qa";
            string merchantUrl = "https://YOUR_MPI_RESPONSE_URL";
			string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
			string userAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3)";
            string processing_country_code = "CA";

            PaypassTxn paypassTxn = new PaypassTxn();
            paypassTxn.SetXid(xid);
            paypassTxn.SetAmount(amount);
            paypassTxn.SetMpRequestToken(mp_request_token);
			paypassTxn.SetMD(MD);
            paypassTxn.SetMerchantUrl(merchantUrl);
            paypassTxn.SetAccept(accept);
			paypassTxn.SetUserAgent(userAgent);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(paypassTxn);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("CardType = " + receipt.GetCardType());
				Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
				Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
				Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
				Console.WriteLine("TransType = " + receipt.GetTransType());
				Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
				Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
				Console.WriteLine("ISO = " + receipt.GetISO());
				Console.WriteLine("Message = " + receipt.GetMessage());
				Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
				Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
				Console.WriteLine("Complete = " + receipt.GetComplete());
				Console.WriteLine("TransDate = " + receipt.GetTransDate());
				Console.WriteLine("TransTime = " + receipt.GetTransTime());
				Console.WriteLine("Ticket = " + receipt.GetTicket());
				Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
				Console.WriteLine("MpiMessage = " + receipt.GetMpiMessage());
				Console.WriteLine("MpiSuccess = " + receipt.GetMpiSuccess());
				Console.WriteLine("MpiParesVerified = " + receipt.GetMpiPAResVerified());
				Console.WriteLine("MpiAcsUrl = " + receipt.GetMpiACSUrl());
				Console.WriteLine("MpiPaReq = " + receipt.GetMpiPaReq());
				Console.WriteLine("MpiTermUrl = " + receipt.GetMpiTermUrl());
				Console.WriteLine("MpiMD = " + receipt.GetMpiMD());
				Console.WriteLine("MpiType = " + receipt.GetMpiType());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
