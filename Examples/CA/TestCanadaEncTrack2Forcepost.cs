namespace Moneris
{
	using System;
	public class TestCanadaEncTrack2Forcepost
	{
		public static void Main(string[] args)
		{
			string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id = "my customer id";
			string amount = "5.00";
			string pos_code = "00";
			string device_type = "idtech_bdk";
			string auth_code = "123456";
			string processing_country_code = "CA";
			bool status_check = false;
			string descriptor = "my descriptor";
			string enc_track2 = "02D901801F4F2800039B%*4924********3428^TESTCARD/MONERIS^*****************************************?*;4924********3428=********************?*A9E67BEBD723D9A37AC3079BD043ECBDA4A353F4900048E5FE44C78835477C5900BCAF5702643EED11DC4B9090BE9BC2ABFBE7C572EB7A16CE901AA1DA59836F08D257DBFA0FD6656CBC63B201EB917D7416B1D1C0E83634FD461BB9F1E631F01838D91B60F73E1A6A7FB73AFBD6D2E29FCC1044171642EB3CD06F7A188D84EA0260832F743E485C0D369929D4840FFAFA12BC3938C4A4DE4FA3FA837D1C2190FFFF3141594047A000913F1F03";            

			EncTrack2Forcepost enctrack2fp = new EncTrack2Forcepost();
			enctrack2fp.SetOrderId(order_id);
			enctrack2fp.SetCustId(cust_id);
			enctrack2fp.SetAmount(amount);
			enctrack2fp.SetEncTrack2(enc_track2);
			enctrack2fp.SetPosCode(pos_code);
			enctrack2fp.SetDeviceType(device_type);
			enctrack2fp.SetAuthCode(auth_code);
			enctrack2fp.SetDynamicDescriptor(descriptor);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetProcCountryCode(processing_country_code);
			mpgReq.SetTestMode(true); //false or comment out this line for production transactions
			mpgReq.SetStoreId(store_id);
			mpgReq.SetApiToken(api_token);
			mpgReq.SetTransaction(enctrack2fp);
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
				Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
				Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
