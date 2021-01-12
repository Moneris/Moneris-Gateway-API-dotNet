using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

public class TestCanadaApplePayTokenPurchase
{
	public static void Main(string[] args)
	{
		string store_id = "intuit_sped";
		string api_token = "spedguy";
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string cust_id = "nqa-test";
		string amount = "1.00";
		string display_name = "Visa 0492";
		string network = "Visa";
		string version = "EC_v1";
		string data = "XxkxQPgssfAr4UgNZics6F3RXHvuAN/Aqk3Uq4912tEobzZBJVvRDC+1UFst5hIpjOV7I84LDjDidJkisE/BW34ziL/HLezo4PW32ECivCrskD46/9xYkL4ftx+cl3Fan1S3b+NZob1dFbr4+zNCPaoJqpoKQC3JwJNQy3UQWaeQy3Mix5JGMm3tvtQjB1nrHwhWZTJVO8u+S8vXvYkQA4sa002mVgNcAwhv9VIWzBXZ8aMuEk1FB8huk1KCL3wsIruwAdoFqockZ3vM5TSo5eJRSFjOLzjloMT4UMFeBXcXMv/xDf1Vu05k75j3vwGfW7S6pi68o6GDCP1qCosF1YpX7AUzCEiR0v4rUZV33b1ygbLE/jkZSwZ8amwCp5B1OoIcIH8eA6OWqj7bqdDCuVJc0fkYxDoMW2rMnyR4uQ==";
		string signature = "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";
		string public_key_hash = "YEZ6iwt41MEIKGm9VbWbW4VORemiABz/l7Ot1IDwCDE=";
		string ephemeral_public_key = "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEHapdvMszm/LiR54hCNFqDAEqHvSZrLGk0d6ojR5LeOG64Q5EjUopFo+whmwDNbAzZ4OkZ9E9mB7+78yNBzJjvA==";
		string transaction_id = "7514ec08ba689cddb5cbb316de0b0a475f1f428bcce616d022aae18503d9e746";
		string dynamic_descriptor = "nqa-dd";
		string processing_country_code = "CA";

		ApplePayTokenPurchase applePayTokenPurchase = new ApplePayTokenPurchase();
		applePayTokenPurchase.SetOrderId(order_id);
		applePayTokenPurchase.SetCustId(cust_id);
		applePayTokenPurchase.SetAmount(amount);
		applePayTokenPurchase.SetDisplayName(display_name);
		applePayTokenPurchase.SetNetwork(network);
		applePayTokenPurchase.SetVersion(version);
		applePayTokenPurchase.SetData(data);
		applePayTokenPurchase.SetSignature(signature);
		applePayTokenPurchase.SetHeader(public_key_hash, ephemeral_public_key, transaction_id);
		applePayTokenPurchase.SetDynamicDescriptor(dynamic_descriptor);

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(applePayTokenPurchase);
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
			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
