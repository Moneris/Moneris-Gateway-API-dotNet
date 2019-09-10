namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestVsIndependentRefund
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id="CUST13343";
			string amount="5.00";
			string pan="4242424254545454";
			string expiry_date="2012"; //YYMM
			string crypt="7";
			string national_tax = "1.23";
			string merchant_vat_no = "gstno111";
			string local_tax = "2.34";
			string customer_vat_no = "gstno999";
			string cri = "CUST-REF-002";
			string customer_code="ccvsfp";
			string invoice_number="invsfp";
			string local_tax_no="ltaxno";

			VsIndependentRefund vsIndependentRefund = new VsIndependentRefund();
			vsIndependentRefund.SetOrderId(order_id);
			vsIndependentRefund.SetCustId(cust_id);
			vsIndependentRefund.SetAmount(amount);
			vsIndependentRefund.SetPan(pan);
			vsIndependentRefund.SetExpDate(expiry_date);
			vsIndependentRefund.SetCryptType(crypt);
			vsIndependentRefund.SetNationalTax(national_tax);
			vsIndependentRefund.SetMerchantVatNo(merchant_vat_no);
			vsIndependentRefund.SetLocalTax(local_tax);
			vsIndependentRefund.SetCustomerVatNo(customer_vat_no);
			vsIndependentRefund.SetCri(cri);
			vsIndependentRefund.SetCustomerCode(customer_code);
			vsIndependentRefund.SetInvoiceNumber(invoice_number);
			vsIndependentRefund.SetLocalTaxNo(local_tax_no);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vsIndependentRefund);
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
