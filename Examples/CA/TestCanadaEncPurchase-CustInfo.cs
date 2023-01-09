namespace Moneris
{
    using System;
    public class TestCanadaEncPurchaseCustInfo
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
			string api_token = "yesguy";
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string amount = "1.00";
			string device_type = "idtech_bdk";
			string crypt = "7";
			string enc_track2 = "02840085000000000416BC6FCE0D7A8B07E6278E60D237CA9362767ADC2C93A2EA5D9BED3E4D1A791C3F4FC61C1800486A8A6B6CCAA00431353131FFFF3141594047A00090055103";
			string processing_country_code = "CA";
			bool status_check = false;

            EncPurchase encpurchase = new EncPurchase();
            encpurchase.SetOrderId(order_id);
            encpurchase.SetAmount(amount);
            encpurchase.SetEncTrack2(enc_track2);
            encpurchase.SetDeviceType(device_type);
            encpurchase.SetCryptType(crypt);

            /********************* Billing/Shipping Variables ****************************/

            string first_name = "Bob";
            string last_name = "Smith";
            string company_name = "ProLine Inc.";
            string address = "623 Bears Ave";
            string city = "Chicago";
            string province = "Illinois";
            string postal_code = "M1M2M1";
            string country = "Canada";
            string phone = "777-999-7777";
            string fax = "777-999-7778";
            string tax1 = "10.00";
            string tax2 = "5.78";
            string tax3 = "4.56";
            string shipping_cost = "10.00";

            /********************* Order Line Item Variables *****************************/

            string[] item_description = new string[] { "Chicago Bears Helmet", "Soldier Field Poster" };
            string[] item_quantity = new string[] { "1", "1" };
            string[] item_product_code = new string[] { "CB3450", "SF998S" };
            string[] item_extended_amount = new string[] { "150.00", "19.79" };

            /********************** Customer Information Object **************************/

            CustInfo customer = new CustInfo();

            /********************** Set Customer Billing Information **********************/

            customer.SetBilling(first_name, last_name, company_name, address, city,
                         province, postal_code, country, phone, fax, tax1, tax2,
                         tax3, shipping_cost);

            /******************** Set Customer Shipping Information ***********************/

            customer.SetShipping(first_name, last_name, company_name, address, city,
                         province, postal_code, country, phone, fax, tax1, tax2,
                         tax3, shipping_cost);

            /***************************** Order Line Items  ******************************/

            customer.SetItem(item_description[0], item_quantity[0],
                      item_product_code[0], item_extended_amount[0]);

            customer.SetItem(item_description[1], item_quantity[1],
                      item_product_code[1], item_extended_amount[1]);

            encpurchase.SetCustInfo(customer);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(encpurchase);
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
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
                Console.WriteLine("SourcePanLast4 = " + receipt.GetSourcePanLast4());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
