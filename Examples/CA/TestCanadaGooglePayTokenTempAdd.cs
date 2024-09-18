using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

public class TestCanadaGooglePayTokenTempAdd
{
	public static void Main(string[] args)
	{
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string store_id = "store5";
		string api_token = "yesguy";
		string signature = "MEYCIQCdjfGZ1k/8h+eH9Ue5UxJsgDEFimp6YIrWhtpte+W3kAIhAOKikmz1B/C4WB5g3mXy139euOHHnSQ7bQWl2chgwole";
		string protocol_version = "ECv1";
		string signed_message =  "{\"encryptedMessage\":\"nAEP5f0pzvU+cJHwxCwrCVPRrl96NugevgfrdidPOB5B+WG7+yrsYoUVA7HopRD5y5GCldQwrKnP2h2w/Qc2HBfn+G/g2IXqPBzMjguhpGItr6lV0tRLaYimxrgrbh/Xn8DxfW++pTHHoo+0xJiON6o3JC4vM6wmAuhjjwEOgiDeKpgxJKEl8NULR2RK1OtvongkR80K8Et7CT+W0lXoMCoYrH3tJDKMtovyFNfHPMAXLeV4NfVV+ZwhwD3F+tGm7bQkPFMy2xUQxzdj7/H03vmyxwsblSKXhVG3hWKPmnY/+Gkb2K0pAicOHaB/SZuwaxHQll30jaNafUIm96R9T2Yc3p5gmnGiR03R9H5R8JqLL9Wb7LncvfIwuQppgbAKa6HdbuSjbehNOtW8S34VqxvpeSfQFUNYgkQ+fVEU/VaClE17PyF8AMZKN10ZIZ1jj7jntqoD\",\"ephemeralPublicKey\":\"BD5snQM3HF2gdCyERaF9XBPDGOXL8fNyTM9QY/xNTi9VkWTtq5sg7dYgPXdLmQuwIhBN9OyLULAMsNcmsv2TT7k\\u003d\",\"tag\":\"hyG7Ty/qQAZe1t2INIMtDQPMAfoDVhUinW451hJrcP4\\u003d\"}";
		
		GooglePayTokenTempAdd googlePayTokenTempAdd = new GooglePayTokenTempAdd();
		googlePayTokenTempAdd.SetPaymentToken(signature, protocol_version, signed_message);
		
		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(googlePayTokenTempAdd);
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
            Console.WriteLine("DataKey = " + receipt.GetDataKey());
            Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
            Console.WriteLine("ExpDate = " + receipt.GetResExpDate());
            Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
			Console.WriteLine("GooglepayPaymentMethod = " + receipt.GetGooglepayPaymentMethod());

			Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
