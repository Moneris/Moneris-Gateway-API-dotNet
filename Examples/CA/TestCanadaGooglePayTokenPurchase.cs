using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

public class TestCanadaGooglePayTokenPurchase
{
	public static void Main(string[] args)
	{
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string store_id = "store5";
		string api_token = "yesguy";        
		string amount = "1.00";
		string crypt_type = "2";
		string cust_id = "nqa-cust_id";
		string network = "MASTERCARD";
		string data_key = "ot-YbCPcwI8HxxuFSsYwaRZZq651";
		string threeds_server_trans_id = "de1b97ee-c610-4877-b53f-c1c5ecd99bf0";
		string ds_trans_id = "de1b97ee-c610-4877-b53f-c1c5ecd99bf0";
		string threeds_version = "2.2";
		string cavv = "kAABApFSYyd4l2eQQFJjAAAAAAA=";
		string dynamic_descriptor = "nqa-dd";
		string processing_country_code = "CA";

		GooglePayTokenPurchase googlePayTokenPurchase = new GooglePayTokenPurchase();
		googlePayTokenPurchase.SetOrderId(order_id);
		googlePayTokenPurchase.SetCustId(cust_id);
		googlePayTokenPurchase.SetAmount(amount);
		googlePayTokenPurchase.SetCryptType(crypt_type);
		googlePayTokenPurchase.SetNetwork(network);
		googlePayTokenPurchase.SetDataKey(data_key);
		googlePayTokenPurchase.SetThreeDSServerTransId(threeds_server_trans_id);
		googlePayTokenPurchase.SetDSTransId(ds_trans_id);
		googlePayTokenPurchase.SetThreeDSVersion(threeds_version);
		googlePayTokenPurchase.SetCavv(cavv);
		googlePayTokenPurchase.SetDynamicDescriptor(dynamic_descriptor);
		
		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(googlePayTokenPurchase);
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
			Console.WriteLine("ISO = " + receipt.GetISO());
			Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("Ticket = " + receipt.GetTicket());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
			Console.WriteLine("HostId = " + receipt.GetHostId());
			Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
			Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
			Console.WriteLine("ThreeDSVersion = " + receipt.GetThreeDSVersion());
			Console.WriteLine("DataKey = " + receipt.GetDataKey());
			Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
			Console.WriteLine("Par = " + receipt.GetPar());
			Console.WriteLine("GooglepayPaymentMethod = " + receipt.GetGooglepayPaymentMethod());
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
