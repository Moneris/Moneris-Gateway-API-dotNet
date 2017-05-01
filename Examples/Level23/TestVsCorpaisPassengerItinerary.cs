namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestVsCorpaisPassengerItinerary
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="ord-160916-15:31:39";
			string txn_number="18306-0_11";

			string ticket_number = "X9831083193";
			string passenger_name = "John Williams";
			string total_fee = "0.23";
			string exchange_ticket_number = "1234567890001";
			string exchange_ticket_amount = "0.24";
			string travel_agency_code = "XH1";
			string travel_agency_name="AIR FLY";
			string internet_indicator = "Y";
			string electronic_ticket_indicator = "Y";
			string vat_ref_num = "XH13983189";

			string[] conjunction_ticket_number = {"1234567890100", "1234567890101"};

			string[] coupon_number = {"1", "3", "2"};
			string[] carrier_code1 = {"2R", "2R", "2R"};
			string[] flight_number = {"1234", "5678", "3456"};
			string[] service_class = {"A", "B", "C"};
			string[] orig_city_airport_code = {"YVR", "BOS", "NYC"};
			string[] stop_over_code = {"O", "O", "X"};
			string[] dest_city_airport_code = {"BOS", "NYC", "EWR"};
			string[] fare_basis_code = {"FClass", "Business", "Business"};
			string[] departure_date1 = {"030113", "030213", "030313"};
			string[] departure_time = {"1110", "1120", "1130"};
			string[] arrival_time = {"1210", "1220", "1230"};

			string[] control_id = {"1234567890300", "1234567890301"};

			//Create and set VsCorpai
			VsCorpai vsCorpai = new VsCorpai();
			vsCorpai.SetTicketNumber(ticket_number);
			vsCorpai.SetPassengerName1(passenger_name);
			vsCorpai.SetTotalFee(total_fee);
			vsCorpai.SetExchangeTicketNumber(exchange_ticket_number);
			vsCorpai.SetExchangeTicketAmount(exchange_ticket_amount);
			vsCorpai.SetTravelAgencyCode(travel_agency_code);
			vsCorpai.SetTravelAgencyName(travel_agency_name);
			vsCorpai.SetInternetIndicator(internet_indicator);
			vsCorpai.SetElectronicTicketIndicator(electronic_ticket_indicator);
			vsCorpai.SetVatRefNum(vat_ref_num);

			//Create and set VsCorpais
			//Every Corpas can only have up to 2 TripLegInfo
			VsTripLegInfo[] vsTripLegInfo = {new VsTripLegInfo(), new VsTripLegInfo()};
			vsTripLegInfo[0].SetTripLegInfo(coupon_number[0], carrier_code1[0], flight_number[0], service_class[0], orig_city_airport_code[0], stop_over_code[0], dest_city_airport_code[0], fare_basis_code[0], departure_date1[0], departure_time[0], arrival_time[0]);
			vsTripLegInfo[0].SetTripLegInfo(coupon_number[1], carrier_code1[1], flight_number[1], service_class[1], orig_city_airport_code[1], stop_over_code[1], dest_city_airport_code[1], fare_basis_code[1], departure_date1[1], departure_time[1], arrival_time[1]);

			vsTripLegInfo[1].SetTripLegInfo(coupon_number[2], carrier_code1[2], flight_number[2], service_class[2], orig_city_airport_code[2], stop_over_code[2], dest_city_airport_code[2], fare_basis_code[2], departure_date1[2], departure_time[2], arrival_time[2]);

			VsCorpas vsCorpas = new VsCorpas();
			vsCorpas.SetCorpas(conjunction_ticket_number[0], vsTripLegInfo[0], control_id[0]);
			vsCorpas.SetCorpas(conjunction_ticket_number[1], vsTripLegInfo[1], control_id[1]);
		
			VsCorpais vsCorpais = new VsCorpais();
			vsCorpais.SetOrderId(order_id);
			vsCorpais.SetTxnNumber(txn_number);
			vsCorpais.SetVsCorpa(vsCorpai, vsCorpas);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vsCorpais);
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
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

		}
	}
}
