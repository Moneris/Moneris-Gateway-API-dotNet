namespace Moneris
{
        using System;
    using System.Text;
    using System.Collections;

public class TestUSAResPurchaseAchRecur
{
    	public static void Main(string[] args)
	{

		/********************** Request Variables ****************************/

		string store_id = "monusqa002";
		string api_token = "qatoken";

		/********************** Transaction Variables ************************/

		string data_key = "QMlFZodHBk5K102EKnoyobs1N";
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string cust_id = "Hilton_1";
		string amount = "1.00";
		string processing_country_code = "US";

		/*********************** Recur Varables ******************************/

		string recur_unit = "month";
		string start_now = "true";
		string start_date = "2019/12/12";
		string num_recurs = "12";
		string period = "1";
		string recur_amount = "1.00";

		/************************** Recur Object ******************************/

		Recur monthlyPayment = new Recur (recur_unit, start_now, start_date,
				num_recurs, period, recur_amount);

		/************************ Request Object ******************************/

		ResPurchaseAch resPurchaseAch = new ResPurchaseAch();
		resPurchaseAch.SetDataKey(data_key);
		resPurchaseAch.SetOrderId(order_id);
		resPurchaseAch.SetCustId(cust_id);
		resPurchaseAch.SetAmount(amount);
		resPurchaseAch.SetRecur(monthlyPayment);

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
			Console.WriteLine("RecurSuccess = " + receipt.GetRecurSuccess());
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
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}  
}
}
