namespace Moneris
{
	using System;

	public class TestCanadaEncPurchaseEfraud
	{
		public static void Main(string[] args)
		{
			string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string amount = "1.00";
			string device_type = "idtech_bdk";
			string crypt = "7";
			string enc_track2 = "02840085000000000416BC6FCE0D7A8B07E6278E60D237CA9362767ADC2C93A2EA5D9BED3E4D1A791C3F4FC61C1800486A8A6B6CCAA00431353131FFFF3141594047A00090055103";
			string processing_country_code = "CA";
			bool status_check = false;

			AvsInfo avsCheck = new AvsInfo();
			avsCheck.SetAvsStreetNumber("212");
			avsCheck.SetAvsStreetName("Payton Street");
			avsCheck.SetAvsZipCode("M1M1M1");

			CvdInfo cvdCheck = new CvdInfo();
			cvdCheck.SetCvdIndicator("1");
			cvdCheck.SetCvdValue("099");

			EncPurchase encpurchase = new EncPurchase();
			encpurchase.SetOrderId(order_id);
			encpurchase.SetAmount(amount);
			encpurchase.SetEncTrack2(enc_track2);
			encpurchase.SetDeviceType(device_type);
			encpurchase.SetCryptType(crypt);
			encpurchase.SetAvsInfo(avsCheck);
			encpurchase.SetCvdInfo(cvdCheck);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetProcCountryCode(processing_country_code);
			mpgReq.SetTestMode(true); //false or comment out this line for production transactions
			mpgReq.SetStoreId(store_id);
			mpgReq.SetApiToken(api_token);
			mpgReq.SetTransaction(encpurchase);
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
				Console.WriteLine("ISO = " + receipt.GetISO());
				Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
				Console.WriteLine("Message = " + receipt.GetMessage());
				Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
				Console.WriteLine("Complete = " + receipt.GetComplete());
				Console.WriteLine("TransDate = " + receipt.GetTransDate());
				Console.WriteLine("TransTime = " + receipt.GetTransTime());
				Console.WriteLine("Ticket = " + receipt.GetTicket());
				Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
				Console.WriteLine("Avs Response = " + receipt.GetAvsResultCode());
				Console.WriteLine("Cvd Response = " + receipt.GetCvdResultCode());
				Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
				Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
