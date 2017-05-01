namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestVsRefund
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="Test20170116043144";
			string amount="5.00";
			string txn_number = "39011-0_11";
			string crypt="7";
			string national_tax = "1.23";
			string merchant_vat_no = "gstno111";
			string local_tax = "2.34";
			string customer_vat_no = "gstno999";
			string cri = "CUST-REF-002";
			string customer_code="ccvsfp";
			string invoice_number="invsfp";
			string local_tax_no="ltaxno";

			VsRefund vsRefund = new VsRefund();
			vsRefund.SetOrderId(order_id);
			vsRefund.SetAmount(amount);
			vsRefund.SetTxnNumber(txn_number);
			vsRefund.SetCryptType(crypt);
			vsRefund.SetNationalTax(national_tax);
			vsRefund.SetMerchantVatNo(merchant_vat_no);
			vsRefund.SetLocalTax(local_tax);
			vsRefund.SetCustomerVatNo(customer_vat_no);
			vsRefund.SetCri(cri);
			vsRefund.SetCustomerCode(customer_code);
			vsRefund.SetInvoiceNumber(invoice_number);
			vsRefund.SetLocalTaxNo(local_tax_no);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vsRefund);
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
