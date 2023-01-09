namespace Moneris
{
	using System;

	public class TestCanadaEncContactlessPurchase
	{
		public static void Main(string[] args)
		{
			string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id = "my customer id";
			string amount = "1.00";
			string enc_track2 = "ZLrh4VKryAo4d67jdaxYPguMPSRHovKrekcSwhsobBQhxsxXE+gWPBB1XZV83Migq796muJYGHOy2UhuxYmJU4npXw7qKNHtIvyre4+5vVIxNHl3bCDK7RYzrUASDjaehxzk0HFGJq9G6QohTThpSa7ml1xPdOWn7b0KHic/KeU=";
			string pos_code = "00";
			string device_type = "public";
			string dynamic_descriptor = "my descriptor";
			string processing_country_code = "CA";
			bool status_check = false;

			EncContactlessPurchase purchase = new EncContactlessPurchase();
			purchase.SetOrderId(order_id);
			purchase.SetCustId(cust_id);
			purchase.SetAmount(amount);
			purchase.SetEncTrack2(enc_track2);
			purchase.SetPosCode(pos_code);
			purchase.SetDeviceType(device_type);
			purchase.SetDynamicDescriptor(dynamic_descriptor);

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
				//Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
				//Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
				//Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
				Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
