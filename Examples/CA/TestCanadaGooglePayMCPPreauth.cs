using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

public class TestCanadaGooglePayMCPPreauth
{
	public static void Main(string[] args)
	{
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string store_id = "intuit_sped";
		string api_token = "spedguy";            
		string amount = "1.00";
		string cust_id = "nqa-cust_id";
		string network = "MASTERCARD";
		string signature = "MEQCIHqTNrWj16DTwJUKi/AHbcp12n7hWgLYpcZeIL4YE6v2AiBabiGJla15MuHs0irVOXX2/jW/YxID1aUmaHSBRddy5Q==";
		string protocol_version = "ECv1";
		string signed_message =  "{\"encryptedMessage\":\"UC+YsDq+MDGAbMS+8liNngnEnHHsh/LueiqZlkCaVz3fYuWqL3i70Xk72yEg+Riu6erDA49nth7F/VkAH8Lun6ZvKC+r7AHLc7kScIAhRJf/muPYas9Zwr5sHV7WdmKLNoPi5Ni5YYGH8jXry7byJCXU0fbVYvFcR1zqrVL+IgdIRxu0hjpyP2NVhv9lNCaCP4Qk7bQf5jN0XhBYVzHwWc42knGkV8oHLBQ199IXl+ARjizax1zcZsa10+dPySBYQD2rcu6THp/aIRfHbW5feux/ifn4sbv4Xq3SNHJluo2L2MfKEiPLwFV6NyyMLRqXNIoLLB/5l8IjEqBgSkEXh4oBbyZcKsWw9udnzwf/K3Mat7lfu2xSPB9eLRJvwOtg3pgkYf8o+gZTW4UEbuBJwOtDDVtmZQeLVOFGTGZSX+tSn5Ua6unWEgwXkH9XTYXYtHlgGjOb\",\"ephemeralPublicKey\":\"BPoyXz2b9VdlFfcnsJ0pbu57wxNIrTxkVHDKstNmxTXKu0rE+5S6BcT9m5zPU8WR/CZ/H+lbXgAp9USPL3ZdRMY\\u003d\",\"tag\":\"dN9RJUDMztNgUkvPE/ys8ZLNpCUkpKi+ZLB6SoGx6Ww\\u003d\"}";
		string dynamic_descriptor = "nqa-dd";
		string processing_country_code = "CA";

		GooglePayMCPPreauth googlePayMCPPreauth = new GooglePayMCPPreauth();
		googlePayMCPPreauth.SetOrderId(order_id);
		googlePayMCPPreauth.SetCustId(cust_id);
		googlePayMCPPreauth.SetAmount(amount);
		googlePayMCPPreauth.SetNetwork(network);
		googlePayMCPPreauth.SetPaymentToken(signature, protocol_version, signed_message);
		googlePayMCPPreauth.SetDynamicDescriptor(dynamic_descriptor);

        //MCP Fields
        googlePayMCPPreauth.SetMCPVersion("1.0");
        googlePayMCPPreauth.SetCardholderAmount("500");
        googlePayMCPPreauth.SetCardholderCurrencyCode("840");
        googlePayMCPPreauth.SetMCPRateToken("P1538681661706745");
		
		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(googlePayMCPPreauth);
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

            Console.WriteLine("MerchantSettlementAmount = " + receipt.GetMerchantSettlementAmount());
            Console.WriteLine("CardholderAmount = " + receipt.GetCardholderAmount());
            Console.WriteLine("CardholderCurrencyCode = " + receipt.GetCardholderCurrencyCode());
            Console.WriteLine("MCPRate = " + receipt.GetMCPRate());
            Console.WriteLine("MCPErrorStatusCode = " + receipt.GetMCPErrorStatusCode());
            Console.WriteLine("MCPErrorMessage = " + receipt.GetMCPErrorMessage());
            Console.WriteLine("HostId = " + receipt.GetHostId());

			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
