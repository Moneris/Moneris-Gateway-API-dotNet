namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestMcCorpaisCommonPassengerLineItemRail
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="Test20170112020548";
			string txn_number="660117311792017012140548199-0_11";

			//Common Data
			string customer_code1_c ="CustomerCode123";
			string additional_card_acceptor_data_c ="acad1";
			string austin_tetra_number_c ="atn1";
			string naics_code_c ="nc1";
			string card_acceptor_type_c ="0000nnnn";
			string card_acceptor_tax_id_c ="Moneristaxid1";
			string corporation_vat_number_c ="cvn123";
			string card_acceptor_reference_number_c ="carn1";
			string freight_amount1_c ="1.23";
			string duty_amount1_c ="2.34";
			string destination_province_code_c ="ONT";
			string destination_country_code_c ="CAN";
			string ship_from_pos_code_c ="M8X 2X2";
			string ship_to_pos_code_c ="_M1R 1R5";
			string order_date_c ="141211";
			string card_acceptor_vat_number_c ="cavn1";
			string customer_vat_number_c ="customervn231";
			string unique_invoice_number_c ="uin567";
			string commodity_code_c ="paCCC1";
			string authorized_contact_name_c ="John Walker";
			string authorized_contact_phone_c ="416-734-1000";

			//Common Tax Details
			string[] tax_amount_c = {"1.19", "1.29"};
			string[] tax_rate_c = {"6.0", "7.0"};
			string[] tax_type_c = {"GST", "PST"};
			string[] tax_id_c = {"gst1298", "pst1298"};
			string[] tax_included_in_sales_c = {"Y", "N"};

			//General Passenger Ticket Information
			string passenger_name1_i ="MCC Tester";
			string ticket_number1_i ="1234567890001";
			string travel_agency_name_i ="Moneris Travel";
			string travel_agency_code_i ="MC322";
			string issuing_carrier_i ="2R";
			string customer_code1_i ="passengerabc";
			string issue_date_i ="141210";
			string total_fare_i ="129.45";
			string travel_authorization_code_i ="sde-erdsz-452112";
			string total_fee_i ="10.34";
			string total_taxes_i ="11.56";
			string restricted_ticket_indicator_i ="1";
			string exchange_ticket_amount_i ="13.98";
			string exchange_fee_amount_i ="1.78";
			string iata_client_code_i ="icc2";

			//Tax Details for passenger
			string[] tax_amount_i = {"3.28"};
			string[] tax_rate_i = {"13.00"};
			string[] tax_type_i = {"HST"};
			string[] tax_id_i = {"hst1298"};
			string[] tax_included_in_sales_i = {"Y"};

			//Passenger Air Travel Details
			string[] travel_date_s = {"150101", "150102"};
			string[] carrier_code1_s = {"3R", "4R"};
			string[] service_class_s = {"E", "B"};
			string[] orig_city_airport_code_s = {"Toron", "Montr"};
			string[] dest_city_airport_code_s = {"Montr", "Halif"};
			string[] stop_over_code_s = {"", "X"};
			string[] coupon_number1_s = {"1", "2"};
			string[] fare_basis_code1_s = {"FClass", "SClass"};
			string[] flight_number_s = {"56786", "54386"};
			string[] departure_time_s = {"1920", "1120"};
			string[] arrival_time_s = {"0620", "1620"};
			string[] conjunction_ticket_number1_s = {"123456789054367", null};
			string[] exchange_ticket_number1_s = {"123456789067892", null};
			string[] fare_s = {"1.69", null};
			string[] fee_s = {"1.48", null};
			string[] taxes_s = {"3.91", null};
			string[] endorsement_restrictions_s = {"er6", null};

			//Tax Details for Air Travel
			string[] tax_amount_s = {"4.67", "7.43"};
			string[] tax_rate_s = {"5.0", "9.975"};
			string[] tax_type_s = {"GST", "QST"};
			string[] tax_id_s = {"gst1298", "qst1298"};
			string[] tax_included_in_sales_s = {"Y", "Y"};

			//Item Details
			string[] customer_code1_l = {"customer code", "customer code2"};
			string[] line_item_date_l = {"150114", "150114"};
			string[] ship_date_l = {"150120", "150122"};
			string[] order_date1_l = {"150114", "150114"};
			string[] medical_services_ship_to_health_industry_number_l = {null, null};
			string[] contract_number_l = {null, null};
			string[] medical_services_adjustment_l = {null, null};
			string[] medical_services_product_number_qualifier_l = {null, null};
			string[] product_code1_l = {"pc11", "pc12"};
			string[] item_description_l = {"Good item", "Better item"};
			string[] item_quantity_l = {"4", "5"};
			string[] unit_cost_l ={"1.25", "10.00"};
			string[] item_unit_measure_l = {"EA", "EA"};
			string[] ext_item_amount_l ={"5.00", "50.00"};
			string[] discount_amount_l ={"1.00", "50.00"};
			string[] commodity_code_l ={"cCode11", "cCode12"};
			string[] type_of_supply_l = {null, null};
			string[] vat_ref_num_l = {null, null};

			//Tax Details for Items
			string[] tax_amount_l = {"0.52", "1.48"};
			string[] tax_rate_l = {"13.0", "13.0"};
			string[] tax_type_l = {"HST", "HST"};
			string[] tax_id_l = {"hst1298", "hst1298"};
			string[] tax_included_in_sales_l = {"Y", "Y"};

			//Passenger Rail Details
			string[] passenger_name1_r = {"Passenger Namer", "Passenger Namer1"};
			string[] ticket_number1_r = {"1234567890002", "1234567890003"};
			string[] travel_agency_code_r = {"TAC1", "TAC2"};
			string[] travel_agency_name_r = {"Daily Travel", "Daily Travel"};
			string[] travel_date_r = {"141223", "141222"};
			string[] sequence_number_r = {"001", "002"};
			string[] service_type_r = {"01", "02"};
			string[] service_nature_r = {"01", "02"};
			string[] service_amount_r = {"788.34", "56.34"};
			string[] full_vat_gross_amount_r = {"68.12", null};
			string[] start_station_r = {"Vanco", "Calgr"};
			string[] destination_station_r = {"Calgr", "Winpg"};
			string[] number_of_adults_r = {"2", "4"};
			string[] number_of_children_r = {"3", "6"};
			string[] class_of_ticket_r = {"E", "B"};
			string[] procedure_id_r = {"RS-23IVTY", null};
			string[] full_vat_tax_amount_r = {"4.49", null};
			string[] half_vat_gross_amount_r = {"1.08", null};
			string[] half_vat_tax_amount_r = {"0.87", null};
			string[] traffic_code_r = {"665", null};
			string[] sample_number_r = {"125", null};
			string[] generic_code_r = {"66", null};
			string[] generic_number_r = {"gn2", null};
			string[] generic_other_code_r = {"13", null};
			string[] generic_other_number_r = {"gon2", null};
			string[] reduction_code_r = {"14", null};
			string[] reduction_number_r = {"rn2", null};
			string[] reduction_other_code_r = {"17", null};
			string[] reduction_other_number_r = {"ron2", null};
			string[] transportation_other_code_r = {"115", null};
			string[] transportation_service_provider_r = {"tsp2", null};
			string[] transportation_service_offered_r = {"tso2", null};

			//Create and set Tax for McCorpac
			McTax mcTax_c = new McTax();
			mcTax_c.SetTax(tax_amount_c[0], tax_rate_c[0], tax_type_c[0], tax_id_c[0], tax_included_in_sales_c[0]);
			mcTax_c.SetTax(tax_amount_c[1], tax_rate_c[1], tax_type_c[1], tax_id_c[1], tax_included_in_sales_c[1]);

			//Create and set McCorpac for common data - only set values that you know
			McCorpac mcCorpac = new McCorpac();
			mcCorpac.SetCustomerCode1(customer_code1_c);
			mcCorpac.SetAdditionalCardAcceptorData(additional_card_acceptor_data_c);
			mcCorpac.SetAustinTetraNumber(austin_tetra_number_c);
			mcCorpac.SetNaicsCode(naics_code_c);
			mcCorpac.SetCardAcceptorType(card_acceptor_type_c);
			mcCorpac.SetCardAcceptorTaxTd(card_acceptor_tax_id_c);
			mcCorpac.SetCorporationVatNumber(corporation_vat_number_c);
			mcCorpac.SetCardAcceptorReferenceNumber(card_acceptor_reference_number_c);
			mcCorpac.SetFreightAmount1(freight_amount1_c);
			mcCorpac.SetDutyAmount1(duty_amount1_c);
			mcCorpac.SetDestinationProvinceCode(destination_province_code_c);
			mcCorpac.SetDestinationCountryCode(destination_country_code_c);
			mcCorpac.SetShipFromPosCode(ship_from_pos_code_c);
			mcCorpac.SetShipToPosCode(ship_to_pos_code_c);
			mcCorpac.SetOrderDate(order_date_c);
			mcCorpac.SetCardAcceptorVatNumber(card_acceptor_vat_number_c);
			mcCorpac.SetCustomerVatNumber(customer_vat_number_c);
			mcCorpac.SetUniqueInvoiceNumber(unique_invoice_number_c);
			mcCorpac.SetCommodityCode(commodity_code_c);
			mcCorpac.SetAuthorizedContactName(authorized_contact_name_c);
			mcCorpac.SetAuthorizedContactPhone(authorized_contact_phone_c);
			mcCorpac.SetTax(mcTax_c);

			//Create and set Tax for McCorpai
			McTax mcTax_i = new McTax();
			mcTax_i.SetTax(tax_amount_i[0], tax_rate_i[0], tax_type_i[0], tax_id_i[0], tax_included_in_sales_i[0]);

			//Create and set McCorpai
			McCorpai mcCorpai = new McCorpai();
			mcCorpai.SetPassengerName1(passenger_name1_i);
			mcCorpai.SetTicketNumber1(ticket_number1_i);
			mcCorpai.SetTravelAgencyName(travel_agency_name_i);
			mcCorpai.SetTravelAgencyCode(travel_agency_code_i);
			mcCorpai.SetIssuingCarrier(issuing_carrier_i);
			mcCorpai.SetCustomerCode1(customer_code1_i);
			mcCorpai.SetIssueDate(issue_date_i);
			mcCorpai.SetTotalFare(total_fare_i);
			mcCorpai.SetTravelAuthorizationCode(travel_authorization_code_i);
			mcCorpai.SetTotalFee(total_fee_i);
			mcCorpai.SetTotalTaxes(total_taxes_i);
			mcCorpai.SetRestrictedTicketIndicator(restricted_ticket_indicator_i);
			mcCorpai.SetExchangeTicketAmount(exchange_ticket_amount_i);
			mcCorpai.SetExchangeFeeAmount(exchange_fee_amount_i);
			mcCorpai.SetIataClientCode(iata_client_code_i);
			mcCorpai.SetTax(mcTax_i);

			//Create and set Tax for McCorpas
			McTax[] mcTax_s = new McTax[2];
			mcTax_s[0] = new McTax();
			mcTax_s[0].SetTax(tax_amount_s[0], tax_rate_s[0], tax_type_s[0], tax_id_s[0], tax_included_in_sales_s[0]);
			mcTax_s[1] = new McTax();
			mcTax_s[1].SetTax(tax_amount_s[1], tax_rate_s[1], tax_type_s[1], tax_id_s[1], tax_included_in_sales_s[1]);

			//Create and set McCorpas for Air Travel Details only
			McCorpas mcCorpas = new McCorpas();
			mcCorpas.SetMcCorpas(travel_date_s[0], carrier_code1_s[0], service_class_s[0], orig_city_airport_code_s[0], dest_city_airport_code_s[0], stop_over_code_s[0],
								conjunction_ticket_number1_s[0],exchange_ticket_number1_s[0], coupon_number1_s[0], fare_basis_code1_s[0], flight_number_s[0], departure_time_s[0],
								arrival_time_s[0], fare_s[0], fee_s[0], taxes_s[0], endorsement_restrictions_s[0], mcTax_s[0]);
			mcCorpas.SetMcCorpas(travel_date_s[1], carrier_code1_s[1], service_class_s[1], orig_city_airport_code_s[1], dest_city_airport_code_s[1], stop_over_code_s[1],
								conjunction_ticket_number1_s[1],exchange_ticket_number1_s[1], coupon_number1_s[1], fare_basis_code1_s[1], flight_number_s[1], departure_time_s[1],
								arrival_time_s[1], fare_s[1], fee_s[1], taxes_s[1], endorsement_restrictions_s[1], mcTax_s[1]);

			//Create and set Tax for McCorpal
			McTax[] mcTax_l = new McTax[2];
			mcTax_l[0] = new McTax();
			mcTax_l[0].SetTax(tax_amount_l[0], tax_rate_l[0], tax_type_l[0], tax_id_l[0], tax_included_in_sales_l[0]);
			mcTax_l[1] = new McTax();
			mcTax_l[1].SetTax(tax_amount_l[1], tax_rate_l[1], tax_type_l[1], tax_id_l[1], tax_included_in_sales_l[1]);

			//Create and set McCorpal for each item
			McCorpal mcCorpal = new McCorpal();
			mcCorpal.SetMcCorpal(customer_code1_l[0], line_item_date_l[0], ship_date_l[0], order_date1_l[0], medical_services_ship_to_health_industry_number_l[0], contract_number_l[0],
									medical_services_adjustment_l[0], medical_services_product_number_qualifier_l[0], product_code1_l[0], item_description_l[0], item_quantity_l[0],
									unit_cost_l[0], item_unit_measure_l[0], ext_item_amount_l[0], discount_amount_l[0], commodity_code_l[0], type_of_supply_l[0], vat_ref_num_l[0], mcTax_l[0]);
			mcCorpal.SetMcCorpal(customer_code1_l[1], line_item_date_l[1], ship_date_l[1], order_date1_l[1], medical_services_ship_to_health_industry_number_l[1], contract_number_l[1],
									medical_services_adjustment_l[1], medical_services_product_number_qualifier_l[1], product_code1_l[1], item_description_l[1], item_quantity_l[1],
									unit_cost_l[1], item_unit_measure_l[1], ext_item_amount_l[1], discount_amount_l[1], commodity_code_l[1], type_of_supply_l[1], vat_ref_num_l[1], mcTax_l[1]);

			//Create and set McCorpar for Rail Travel Details only
			McCorpar mcCorpar = new McCorpar();
			mcCorpar.SetMcCorpar(passenger_name1_r[0], ticket_number1_r[0], travel_agency_code_r[0], travel_agency_name_r[0], travel_date_r[0], sequence_number_r[0], procedure_id_r[0], service_type_r[0],
								service_nature_r[0], service_amount_r[0], full_vat_gross_amount_r[0], full_vat_tax_amount_r[0], half_vat_gross_amount_r[0], half_vat_tax_amount_r[0], traffic_code_r[0],
								sample_number_r[0], start_station_r[0], destination_station_r[0], generic_code_r[0], generic_number_r[0], generic_other_code_r[0], generic_other_number_r[0], reduction_code_r[0],
								reduction_number_r[0], reduction_other_code_r[0], reduction_other_number_r[0], transportation_other_code_r[0], number_of_adults_r[0], number_of_children_r[0],
								class_of_ticket_r[0], transportation_service_provider_r[0], transportation_service_offered_r[0]);
			mcCorpar.SetMcCorpar(passenger_name1_r[1], ticket_number1_r[1], travel_agency_code_r[1], travel_agency_name_r[1], travel_date_r[1], sequence_number_r[1], procedure_id_r[1], service_type_r[1],
								service_nature_r[1], service_amount_r[1], full_vat_gross_amount_r[1], full_vat_tax_amount_r[1], half_vat_gross_amount_r[1], half_vat_tax_amount_r[1], traffic_code_r[1],
								sample_number_r[1], start_station_r[1], destination_station_r[1], generic_code_r[1], generic_number_r[1], generic_other_code_r[1], generic_other_number_r[1], reduction_code_r[1],
								reduction_number_r[1], reduction_other_code_r[1], reduction_other_number_r[1], transportation_other_code_r[1], number_of_adults_r[1], number_of_children_r[1],
								class_of_ticket_r[1], transportation_service_provider_r[1], transportation_service_offered_r[1]);

			McCorpais mcCorpais = new McCorpais();
			mcCorpais.SetOrderId(order_id);
			mcCorpais.SetTxnNumber(txn_number);
			mcCorpais.SetMcCorpac(mcCorpac);
			mcCorpais.SetMcCorpai(mcCorpai);
			mcCorpais.SetMcCorpas(mcCorpas);
			mcCorpais.SetMcCorpal(mcCorpal);
			mcCorpais.SetMcCorpar(mcCorpar);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(mcCorpais);
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
