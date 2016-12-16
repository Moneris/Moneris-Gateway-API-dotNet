using System;

namespace Moneris{

  using Moneris;
  using System.Collections;
  using System;

public class TestUSAEncResUpdateCC
{
    
public static void Main(string[] args)
	{
		String store_id = "monusqa002";
		String api_token = "qatoken";

        String data_key = "ZjjRgfpvUEBysJO5eSUAB242U";
        String enc_track2 = "028400850000000004142348E7643B2599ACC00517C5AB6FB164486B1A4A83E7A81048D6CBA51604FDD12B72C228028E727AF6664C7A0431393035FFFF3141594047A0009E79C903";
        String device_type = "idtech"; 
        String phone = "55555555555";
		String email = "test.user@moneris.com";
		String note = "my note";
		String cust_id = "customer2";
		String crypt = "7";
		String processing_country_code = "US";
		
		AvsInfo avsinfo = new AvsInfo();

		avsinfo.SetAvsStreetNumber("212");
		avsinfo.SetAvsStreetName("Smith Street");
		avsinfo.SetAvsZipCode("M1M1M1");

		EncResUpdateCC enc_res_update_cc = new EncResUpdateCC ();
		enc_res_update_cc.SetDataKey(data_key);
		enc_res_update_cc.SetAvsInfo(avsinfo);
		enc_res_update_cc.SetCustId(cust_id);
		enc_res_update_cc.SetEncTrack2(enc_track2);
		enc_res_update_cc.SetDeviceType(device_type);
		enc_res_update_cc.SetPhone(phone);
		enc_res_update_cc.SetEmail(email);
		enc_res_update_cc.SetNote(note);
		enc_res_update_cc.SetCryptType(crypt);

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(enc_res_update_cc);
		mpgReq.Send();
		
		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("DataKey = " + receipt.GetDataKey());
			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
			Console.WriteLine("PaymentType = " + receipt.GetPaymentType() + "\n");

			//Contents of ResolveData
			Console.WriteLine("Cust ID = " + receipt.GetResCustId());
			Console.WriteLine("Phone = " + receipt.GetResPhone());
			Console.WriteLine("Email = " + receipt.GetResEmail());
			Console.WriteLine("Note = " + receipt.GetResNote());
			Console.WriteLine("MaskedPan = " + receipt.GetResMaskedPan());
			Console.WriteLine("Exp Date = " + receipt.GetResExpDate());
			Console.WriteLine("Crypt Type = " + receipt.GetResCryptType());
			Console.WriteLine("Avs Street Number = " + receipt.GetResAvsStreetNumber());
			Console.WriteLine("Avs Street Name = " + receipt.GetResAvsStreetName());
			Console.WriteLine("Avs Zipcode = " + receipt.GetResAvsZipcode());
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
}
