namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestVsCorpaisInvoice
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="ord-160916-15:31:39";
			string txn_number="18306-0_11";

			string buyer_name = "Buyer Manager";
			string local_tax_rate = "13.00";
			string duty_amount = "0.00";
			string discount_treatment = "0";
			string discount_amt = "0.00";
			string freight_amount = "0.20";
			string ship_to_pos_code = "M8X 2W8";
			string ship_from_pos_code = "M1K 2Y7";
			string des_cou_code = "CAN";
			string vat_ref_num = "VAT12345";
			string tax_treatment = "3";//3 = Gross prices given with tax information provided at invoice level
			string gst_hst_freight_amount = "0.00";
			string gst_hst_freight_rate = "13.00";  

			string[] item_com_code = {"X3101", "X84802"};
			string[] product_code = {"CHR123", "DDSK200"};
			string[] item_description = {"Office Chair", "Disk Drive"};
			string[] item_quantity = {"3", "1"};
			string[] item_uom = {"EA", "EA"};
			string[] unit_cost = {"0.20", "0.40"};
			string[] vat_tax_amt = {"0.00", "0.00"};
			string[] vat_tax_rate = {"13.00", "13.00"};
			string[] discount_treatmentL = {"0", "0"};
			string[] discount_amtL = {"0.00", "0.00"};

			//Create and set VsPurcha
			VsPurcha vsPurcha = new VsPurcha();
			vsPurcha.SetBuyerName(buyer_name);
			vsPurcha.SetLocalTaxRate(local_tax_rate);
			vsPurcha.SetDutyAmount(duty_amount);
			vsPurcha.SetDiscountTreatment(discount_treatment);
			vsPurcha.SetDiscountAmt(discount_amt);
			vsPurcha.SetFreightAmount(freight_amount);
			vsPurcha.SetShipToPostalCode(ship_to_pos_code);
			vsPurcha.SetShipFromPostalCode(ship_from_pos_code);
			vsPurcha.SetDesCouCode(des_cou_code);
			vsPurcha.SetVatRefNum(vat_ref_num);
			vsPurcha.SetTaxTreatment(tax_treatment);
			vsPurcha.SetGstHstFreightAmount(gst_hst_freight_amount);
			vsPurcha.SetGstHstFreightRate(gst_hst_freight_rate);

			//Create and set VsPurchl
			VsPurchl vsPurchl = new VsPurchl();
			vsPurchl.SetVsPurchl(item_com_code[0], product_code[0], item_description[0], item_quantity[0], item_uom[0], unit_cost[0], vat_tax_amt[0], vat_tax_rate[0], discount_treatmentL[0], discount_amtL[0]);
			vsPurchl.SetVsPurchl(item_com_code[1], product_code[1], item_description[1], item_quantity[1], item_uom[1], unit_cost[1], vat_tax_amt[1], vat_tax_rate[1], discount_treatmentL[1], discount_amtL[1]);
			
			VsCorpais vsCorpais = new VsCorpais();
			vsCorpais.SetOrderId(order_id);
			vsCorpais.SetTxnNumber(txn_number);
			vsCorpais.SetVsPurch(vsPurcha, vsPurchl);

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
