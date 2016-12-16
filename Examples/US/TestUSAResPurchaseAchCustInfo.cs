namespace Moneris
{
        using System;
    using System.Text;
    using System.Collections;

public class TestUSAResPurchaseAchCustInfo
{
public static void Main(string[] args)
	{
		/********************** Request Variables ****************************/

		string store_id = "monusqa002";
		string api_token = "qatoken";

		/********************** Transaction Variables ************************/

		string data_key = "QMlFZodHBk5K102EKnoyobs1N";
		string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
		string cust_id = "Hilton_1";
		string amount = "1.00";
		string processing_country_code = "US";

		/********************* Billing/Shipping Variables ********************/

		string last_name = "Harris";
		string first_name = "Tommie";
		string company_name = "Da Bears";
		string address = "454 Michigan Ave";
		string city = "Chicago";
		string province = "Illinois";
		string zip_code = "99879";
		string country = "USA";
		string phone = "764-908-9989";
		string fax = "764-908-9990";
		string tax1 = "1.00";
		string tax2 = "1.00";
		string tax3 = "1.00";
		string shipping_cost = "2.00";

		/************************* Line Item Variables *************************/

		string[] name = new string[]{"Mini Bears Helmet", "Mini Bills Helmet"};
		string[] quantity = new string[]{"1", "2"};
		string[] product_code = new string[] {"BEOOOWS9", "BUFD099D"};
		string[] extended_amount = new string[] {"4.00", "6.00"};

		/************************ Miscellaneous Variables **********************/

		string email = "T.Harris@ChicagoBears.com";
		string instructions = "Must arrive before opening day at Lambeau";

		/*********************** Transaction Object *******************************/

		ResPurchaseAch resPurchaseAch = new ResPurchaseAch();
		resPurchaseAch.SetDataKey(data_key);
		resPurchaseAch.SetOrderId(order_id);
		resPurchaseAch.SetAmount(amount);
		resPurchaseAch.SetCustId(cust_id);
        /********************* Order Line Item Variables *****************************/

        string[] item_description = new string[] { "Chicago Bears Helmet", "Soldier Field Poster" };
        string[] item_quantity = new string[] { "1", "1" };
        string[] item_product_code = new string[] { "CB3450", "SF998S" };
        string[] item_extended_amount = new string[] { "150.00", "19.79" };


        /*****************************************************************************/
        /*								             */
        /*			Customer Information Option 1			     */
        /*									     */
        /*****************************************************************************/

        /********************** Customer Information Object **************************/

        CustInfo customer = new CustInfo();

        /********************** Set Customer Billing Information **********************/

        customer.SetBilling(first_name, last_name, company_name, address, city,
                     province, zip_code, country, phone, fax, tax1, tax2,
                     tax3, shipping_cost);

        /******************** Set Customer Shipping Information ***********************/

        customer.SetShipping(first_name, last_name, company_name, address, city,
                     province, zip_code, country, phone, fax, tax1, tax2,
                     tax3, shipping_cost);

        /***************************** Order Line Items  ******************************/

        customer.SetItem(item_description[0], item_quantity[0],
                  item_product_code[0], item_extended_amount[0]);

        customer.SetItem(item_description[1], item_quantity[1],
                  item_product_code[1], item_extended_amount[1]);


        /*****************************************************************************/
        /*								             */
        /*			Customer Information Option 2			     */
        /*									     */
        /*****************************************************************************/


        /********************** Customer Information Object **************************/

        CustInfo customer2 = new CustInfo();

        /******************************* Billing Hashtable ***************************/


        Hashtable b = new Hashtable();	//billing hashtable

        b.Add("first_name", first_name);
        b.Add("last_name", last_name);
        b.Add("company_name", company_name);
        b.Add("address", address);
        b.Add("city", city);
        b.Add("province", province);
        b.Add("postal_code", zip_code);
        b.Add("country", country);
        b.Add("phone", phone);
        b.Add("fax", fax);
        b.Add("tax1", tax1);       //federal tax
        b.Add("tax2", tax2);        //prov tax
        b.Add("tax3", tax3);        //luxury tax
        b.Add("shipping_cost", shipping_cost);   //shipping cost  

        customer2.SetBilling(b);

        /****************************** Shipping Hashtable ***************************/

        Hashtable s = new Hashtable();	//shipping hashtable

        s.Add("first_name", first_name);
        s.Add("last_name", last_name);
        s.Add("company_name", company_name);
        s.Add("address", address);
        s.Add("city", city);
        s.Add("province", province);
        s.Add("postal_code", zip_code);
        s.Add("country", country);
        s.Add("phone", phone);
        s.Add("fax", fax);
        s.Add("tax1", tax1);       //federal tax
        s.Add("tax2", tax2);        //prov tax
        s.Add("tax3", tax3);        //luxury tax
        s.Add("shipping_cost", shipping_cost);   //shipping cost

        customer2.SetShipping(s);

        /************************* Order Line Item1 Hashtable ************************/

        Hashtable i1 = new Hashtable();		//item hashtable #1

        i1.Add("name", item_description[0]);
        i1.Add("quantity", item_quantity[0]);
        i1.Add("product_code", item_product_code[0]);
        i1.Add("extended_amount", item_extended_amount[0]);

        customer2.SetItem(i1);

        /************************* Order Line Item2 Hashtable **************************/

        Hashtable i2 = new Hashtable();		//item hashtable #2

        i2.Add("name", "item2's name");
        i2.Add("quantity", "7");
        i2.Add("product_code", "item2's product code");
        i2.Add("extended_amount", "5.01");

        customer2.SetItem(i2);

        /*************** Miscellaneous Customer Information Methods *******************/

        customer.SetEmail("nick@widget.com");
        customer.SetInstructions("Make it fast!");

		/************************ Request Object ******************************/

		HttpsPostRequest mpgReq = new HttpsPostRequest();
		mpgReq.SetProcCountryCode(processing_country_code);
		mpgReq.SetTestMode(true); //false or comment out this line for production transactions
		mpgReq.SetStoreId(store_id);
		mpgReq.SetApiToken(api_token);
		mpgReq.SetTransaction(resPurchaseAch);
		mpgReq.Send();

		/************************ Receipt Object ******************************/

		try
		{
			Receipt receipt = mpgReq.GetReceipt();

			Console.WriteLine("DataKey = " + receipt.GetDataKey());
			Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
			Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
			Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
			Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
			Console.WriteLine("Message = " + receipt.GetMessage());
			Console.WriteLine("TransDate = " + receipt.GetTransDate());
			Console.WriteLine("TransTime = " + receipt.GetTransTime());
			Console.WriteLine("TransType = " + receipt.GetTransType());
			Console.WriteLine("Complete = " + receipt.GetComplete());
			Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
			Console.WriteLine("CardType = " + receipt.GetCardType());
			Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
			Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
			Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
			Console.WriteLine("PaymentType = " + receipt.GetPaymentType() + "\n");

			Console.WriteLine("Cust ID = " + receipt.GetResCustId());
			Console.WriteLine("Phone = " + receipt.GetResPhone());
			Console.WriteLine("Email = " + receipt.GetResEmail());
			Console.WriteLine("Note = " + receipt.GetResNote());
			Console.WriteLine("Sec = " + receipt.GetResSec());
			Console.WriteLine("Cust First Name = " + receipt.GetResCustFirstName());
			Console.WriteLine("Cust Last Name = " + receipt.GetResCustLastName());
			Console.WriteLine("Cust Address1 = " + receipt.GetResCustAddress1());
			Console.WriteLine("Cust Address2 = " + receipt.GetResCustAddress2());
			Console.WriteLine("Cust City = " + receipt.GetResCustCity());
			Console.WriteLine("Cust State = " + receipt.GetResCustState());
			Console.WriteLine("Cust Zip = " + receipt.GetResCustZip());
			Console.WriteLine("Routing Num = " + receipt.GetResRoutingNum());
			Console.WriteLine("Account Num = " + receipt.GetResAccountNum());
			Console.WriteLine("Masked Account Num = " + receipt.GetResMaskedAccountNum());
			Console.WriteLine("Check Num = " + receipt.GetResCheckNum());
			Console.WriteLine("Account Type = " + receipt.GetResAccountType());
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}  
}
}
