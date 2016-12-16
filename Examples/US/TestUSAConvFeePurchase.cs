namespace Moneris
{
    using System;

    public class TestUSAConvFeePurchase
    {
		public static void Main(string[] args)
        {
            string store_id = "monusqa138";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string amount = "5.00";
            string pan = "4242424242424242";
            string expdate = "1602";        //YYMM format
            string crypt = "7";
            string commcard_invoice = "INVC090";
            string commcard_tax_amount = "1.00";
			string convenience_fee = "1.00";
            string processing_country_code = "US";
            bool status_check = false;

            ConvFeeInfo convFeeInfo = new ConvFeeInfo();
            convFeeInfo.SetConvenienceFee(convenience_fee);
            
			Purchase purchase = new Purchase();
            purchase.SetOrderId(order_id);
            purchase.SetAmount(amount);
            purchase.SetPan(pan);
            purchase.SetExpDate(expdate);
            purchase.SetCryptType(crypt);
            purchase.SetCommcardInvoice(commcard_invoice);
            purchase.SetCommcardTaxAmount(commcard_tax_amount);
			purchase.SetConvFeeInfo(convFeeInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(purchase);
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
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("CfSuccess = " + receipt.GetCfSuccess());
                Console.WriteLine("CfStatus = " + receipt.GetCfStatus());
                Console.WriteLine("FeeAmount = " + receipt.GetFeeAmount());
                Console.WriteLine("FeeRate = " + receipt.GetFeeRate());
                Console.WriteLine("FeeType = " + receipt.GetFeeType());
                //Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                //Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                //Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
