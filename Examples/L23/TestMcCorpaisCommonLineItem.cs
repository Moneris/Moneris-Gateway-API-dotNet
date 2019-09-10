namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestMcCorpaisCommonLineItem
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="ord-200916-13:29:27";
			string txn_number="66011731632016264132927986-0_11";

			string customer_code1_c ="CustomerCode123";
			string card_acceptor_tax_id_c ="UrTaxId";//Merchant tax id which is mandatory
			string corporation_vat_number_c ="cvn123";
			string freight_amount_c ="1.23";
			string duty_amount_c ="2.34";
			string ship_to_pos_code_c ="M1R 1W5";
			string order_date_c ="141211";
			string customer_vat_number_c ="customervn231";
			string unique_invoice_number_c ="uin567";
			string authorized_contact_name_c ="John Walker";

			//Tax Details
			string[] tax_amount_c = { "1.19", "1.29"};
			string[] tax_rate_c = { "6.0", "7.0"};
			string[] tax_type_c = { "GST", "PST"};
			string[] tax_id_c = { "gst1298", "pst1298"};
			string[] tax_included_in_sales_c = { "Y", "N"};

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

			//Create and set Tax for McCorpac
			McTax tax_c = new McTax();
			tax_c.SetTax(tax_amount_c[0], tax_rate_c[0], tax_type_c[0], tax_id_c[0], tax_included_in_sales_c[0]);
			tax_c.SetTax(tax_amount_c[1], tax_rate_c[1], tax_type_c[1], tax_id_c[1], tax_included_in_sales_c[1]);

			//Create and set McCorpac for common data - only set values that you know
			McCorpac mcCorpac = new McCorpac();
			mcCorpac.SetCustomerCode1(customer_code1_c);
			mcCorpac.SetCardAcceptorTaxTd(card_acceptor_tax_id_c);
			mcCorpac.SetCorporationVatNumber(corporation_vat_number_c);
			mcCorpac.SetFreightAmount1(freight_amount_c);
			mcCorpac.SetDutyAmount1(duty_amount_c);
			mcCorpac.SetShipToPosCode(ship_to_pos_code_c);
			mcCorpac.SetOrderDate(order_date_c);
			mcCorpac.SetCustomerVatNumber(customer_vat_number_c);
			mcCorpac.SetUniqueInvoiceNumber(unique_invoice_number_c);
			mcCorpac.SetAuthorizedContactName(authorized_contact_name_c);
			mcCorpac.SetTax(tax_c);

			//Create and set Tax for McCorpal
			McTax[] tax_l = new McTax[2];
			tax_l[0] = new McTax();
			tax_l[0].SetTax(tax_amount_l[0], tax_rate_l[0], tax_type_l[0], tax_id_l[0], tax_included_in_sales_l[0]);
			tax_l[1] = new McTax();
			tax_l[1].SetTax(tax_amount_l[1], tax_rate_l[1], tax_type_l[1], tax_id_l[1], tax_included_in_sales_l[1]);

			//Create and set McCorpal for each item
			McCorpal mcCorpal = new McCorpal();
			mcCorpal.SetMcCorpal(customer_code1_l[0], line_item_date_l[0], ship_date_l[0], order_date1_l[0], medical_services_ship_to_health_industry_number_l[0], contract_number_l[0],
						medical_services_adjustment_l[0], medical_services_product_number_qualifier_l[0], product_code1_l[0], item_description_l[0], item_quantity_l[0],
						unit_cost_l[0], item_unit_measure_l[0], ext_item_amount_l[0], discount_amount_l[0], commodity_code_l[0], type_of_supply_l[0], vat_ref_num_l[0], tax_l[0]);
			mcCorpal.SetMcCorpal(customer_code1_l[1], line_item_date_l[1], ship_date_l[1], order_date1_l[1], medical_services_ship_to_health_industry_number_l[1], contract_number_l[1],
						medical_services_adjustment_l[1], medical_services_product_number_qualifier_l[1], product_code1_l[1], item_description_l[1], item_quantity_l[1],
						unit_cost_l[1], item_unit_measure_l[1], ext_item_amount_l[1], discount_amount_l[1], commodity_code_l[1], type_of_supply_l[1], vat_ref_num_l[1], tax_l[1]);

			McCorpais mcCorpais = new McCorpais();
			mcCorpais.SetOrderId(order_id);
			mcCorpais.SetTxnNumber(txn_number);
			mcCorpais.SetMcCorpac(mcCorpac);
			mcCorpais.SetMcCorpal(mcCorpal);

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
