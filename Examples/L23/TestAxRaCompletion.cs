namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestAxRaCompletion
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="ord-210916-12:06:38";
			string comp_amount="62.37";
			string txn_number = "18924-0_11";
			string crypt="7";
			
			string airline_process_id = "000"; 	//Airline three-digit IATA code, Mandatory, Alphanumberic/3
			string invoice_batch = "580";		//Three-digit code that specifies processing options, Mandatory, Numeric/3
			string establishment_name = "TestEstablishment"; 	//Name of the ticket issuer, Mandatory, Alphanumberic/21
			string carrier_name = "M AIR";		//Name of the ticketing airline, Mandatory, Alphanumberic/8
			string ticket_id = "83060915430001";		//Ticket or document number, Mandatory, Numeric/14
			string issue_city = "Toronto";		//Name of the city, Mandatory, Alphanumberic/13
			string establishment_state = "ON";	//State or province code, Mandatory, Alphanumberic/2
			string number_in_party = "2";		//Number of the people, Optional, Numeric/3
			string passenger_name = "TestPassenger";		//Passenger name, Mandatory, Alphanumberic/20
			string taa_routing = "YYZ";		//Flight stopover and city/airport codes, Mandatory, Alphanumberic/20
			string carrier_code = "ClassA";	//Carrier designator codes, Mandatory, Alphanumberic/8
			string fare_basis = "Regular";	//Primary and secondary discount codes, Mandatory, Alphanumberic/24
			string document_type = "00";		//Airline document type code, Mandatory, Numeric/2
			string doc_number = "5908";		//Number assigned to the airline document, Mandatory, Numeric/4
			string departure_date = "0916";  //Departure date, Mandatory, Numeric/4 (MMDD)
			
			AxRaLevel23 raLevel23 = new AxRaLevel23();
			raLevel23.SetAirlineProcessId(airline_process_id);
			raLevel23.SetInvoiceBatch(invoice_batch);
			raLevel23.SetEstablishmentName(establishment_name);
			raLevel23.SetCarrierName(carrier_name);
			raLevel23.SetTicketId(ticket_id);
			raLevel23.SetIssueCity(issue_city);
			raLevel23.SetEstablishmentState(establishment_state);
			raLevel23.SetNumberInParty(number_in_party);
			raLevel23.SetPassengerName(passenger_name);
			raLevel23.SetTaaRouting(taa_routing);
			raLevel23.SetCarrierCode(carrier_code);
			raLevel23.SetFareBasis(fare_basis);
			raLevel23.SetDocumentType(document_type);
			raLevel23.SetDocNumber(doc_number);
			raLevel23.SetDepartureDate(departure_date);

			AxRaCompletion axRaCompletion = new AxRaCompletion();
			axRaCompletion.SetOrderId(order_id);
			axRaCompletion.SetCompAmount(comp_amount);
			axRaCompletion.SetTxnNumber(txn_number);
			axRaCompletion.SetCryptType(crypt);
			axRaCompletion.SetAxRaLevel23(raLevel23);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(axRaCompletion);
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
