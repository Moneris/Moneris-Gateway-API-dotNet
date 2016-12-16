namespace Moneris
{
        using System;
    using System.Text;
    using System.Collections;

public class TestUSAResPurchaseAch
{
    	public static void Main(string[] args)
	{

		/********************** Request Variables ****************************/

		String store_id = "monusqa002";
		String api_token = "qatoken";

		/********************** Transaction Variables ************************/

		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		String data_key = "0HjrtlV2VCu4DRRv8zwZmjbJk";
		String cust_id = "Hilton_1";
		String amount = "1.00";
		String processing_country_code = "US";

		/************************ Request Object ******************************/

		ResPurchaseAch resPurchaseAch = new ResPurchaseAch();
		resPurchaseAch.SetDataKey(data_key);
		resPurchaseAch.SetOrderId(order_id);
		resPurchaseAch.SetCustId(cust_id);
		resPurchaseAch.SetAmount(amount);
		
		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(resPurchaseAch);
		mpgReq.Send();

		/************************ Receipt Object ******************************/

		try
		{
			Receipt receipt = mpgReq.GetReceipt();
			
			Console.WriteLine("DataKey = " + receipt.GetDataKey());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("TransType = " + receipt.GetTransType());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
			Console.WriteLine("CardType = " + receipt.GetCardType());
			Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
			Console.WriteLine("PaymentType = " + receipt.GetPaymentType() + "\n");

			Console.WriteLine("Cust ID = " + receipt.GetResCustId());
			Console.WriteLine("Phone = " + receipt.GetResPhone());
			Console.WriteLine("Email = " + receipt.GetResEmail());
			Console.WriteLine("Note = " + receipt.GetResNote());
			Console.WriteLine("Sec = " + receipt.GetResSec());
			Console.WriteLine("Cust First Name = " + receipt.GetResCustFirstName());
			Console.WriteLine("Cust Last Name = " + receipt.GetResCustLastName());
			Console.WriteLine("Cust Address1 = " + receipt.GetResCustAddress1());
			Console.WriteLine("Cust Address2 = " + receipt.GetResCustAddress2());
			Console.WriteLine("Cust City = " + receipt.GetResCustCity());
			Console.WriteLine("Cust State = " + receipt.GetResCustState());
			Console.WriteLine("Cust Zip = " + receipt.GetResCustZip());
			Console.WriteLine("Routing Num = " + receipt.GetResRoutingNum());
			Console.WriteLine("Account Num = " + receipt.GetResAccountNum());
			Console.WriteLine("Masked Account Num = " + receipt.GetResMaskedAccountNum());
			Console.WriteLine("Check Num = " + receipt.GetResCheckNum());
			Console.WriteLine("Account Type = " + receipt.GetResAccountType());
        }
		catch  (Exception e)
            {
                Console.WriteLine(e);
		}
	}  
}
}
