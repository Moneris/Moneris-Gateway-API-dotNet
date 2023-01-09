namespace Moneris
{
	using System;

	public class TestCanadaEncContactlessPreauth
	{
		public static void Main(string[] args)
		{
			string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id = "my customer id";
			string amount = "9.00";
			string enc_track2 = "02D901801F4F2800039B%*4924********3428^TESTCARD/MONERIS^*****************************************?*;4924********3428=********************?*F74686E9C85DF05DD8886EE84E5AC0E416FBCBDC12F7516869E4FB88153EF0AEF91A03C45A7BB2917A6B007F50FCB169BE18C6BA1C9EDE0FD3A2408DAFC7B6D2104DE936B693C23F3433A13D06A57DEA237F7A268E8A86F13D5FD1A6443B34DFECE10FCB89D061C9CDB1CE9330F787B59788B2414D73CBC33CD06F7A188D84EA0260832F743E485C0D369929D4840FFAFA12BC3938C4A4DE4FA3FA837D1C2190FFFF3141594047A0008E488C03";
			string pos_code = "00";
			string device_type = "idtech_bdk";
			string dynamic_descriptor = "my descriptor";
			string token = "";
			string processing_country_code = "CA";
			bool status_check = false;

			EncContactlessPreauth preauth = new EncContactlessPreauth();
			preauth.SetOrderId(order_id);
			preauth.SetCustId(cust_id);
			preauth.SetAmount(amount);
			preauth.SetEncTrack2(enc_track2);
			preauth.SetPosCode(pos_code);
			preauth.SetDeviceType(device_type);
			preauth.SetDynamicDescriptor(dynamic_descriptor);
			preauth.SetToken(token);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetProcCountryCode(processing_country_code);
			mpgReq.SetTestMode(true); //false or comment out this line for production transactions
			mpgReq.SetStoreId(store_id);
			mpgReq.SetApiToken(api_token);
			mpgReq.SetTransaction(preauth);
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
				Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
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
