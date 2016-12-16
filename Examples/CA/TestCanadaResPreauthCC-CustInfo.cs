namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaResPreauthCCcustInfo
    {
        public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store1";
            string api_token = "yesguy";
            string data_key = "v8iwTS0FbsSLg8dfSc54kONfw";
            string amount = "1.00";
            string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
            string crypt_type = "1";
            string processing_country_code = "CA";
            bool status_check = false;

            ResPreauthCC resPreauthCC = new ResPreauthCC();
            resPreauthCC.SetDataKey(data_key);
            resPreauthCC.SetOrderId(order_id);
            resPreauthCC.SetCustId(cust_id);
            resPreauthCC.SetAmount(amount);
            resPreauthCC.SetCryptType(crypt_type);
            
            //CustInfo Variables
            CustInfo custInfo = new CustInfo();

            custInfo.SetEmail("nick@widget.com");
            custInfo.SetInstructions("Make it fast!");


            Hashtable b = new Hashtable();

            b.Add("first_name", "Bob");
            b.Add("last_name", "Smith");
            b.Add("company_name", "Widget Company Inc.");
            b.Add("address", "111 Bolts Ave.");
            b.Add("city", "Toronto");
            b.Add("province", "Ontario");
            b.Add("postal_code", "M8T 1T8");
            b.Add("country", "Canada");
            b.Add("phone", "416-555-5555");
            b.Add("fax", "416-555-5555");
            b.Add("tax1", "123.45");       //federal tax
            b.Add("tax2", "12.34");        //prov tax
            b.Add("tax3", "15.45");        //luxury tax
            b.Add("shipping_cost", "456.23");   //shipping cost

            custInfo.SetBilling(b);

            /* OR you can pass the individual args.
            custInfo.SetBilling(
                                   "Bob",                  //first name
                                   "Smith",                //last name
                                   "Widget Company Inc.",  //company name
                                   "111 Bolts Ave.",       //address
                                   "Toronto",              //city
                                   "Ontario",              //province
                                   "M8T 1T8",              //postal code
                                   "Canada",               //country
                                   "416-555-5555",         //phone
                                   "416-555-5555",         //fax
                                   "123.45",               //federal tax
                                   "12.34",                //prov tax
                                   "15.45",                //luxury tax
                                   "456.23"                //shipping cost
            );
            */

            Hashtable s = new Hashtable();

            s.Add("first_name", "Bob");
            s.Add("last_name", "Smith");
            s.Add("company_name", "Widget Company Inc.");
            s.Add("address", "111 Bolts Ave.");
            s.Add("city", "Toronto");
            s.Add("province", "Ontario");
            s.Add("postal_code", "M8T 1T8");
            s.Add("country", "Canada");
            s.Add("phone", "416-555-5555");
            s.Add("fax", "416-555-5555");
            s.Add("tax1", "123.45");       //federal tax
            s.Add("tax2", "12.34");        //prov tax
            s.Add("tax3", "15.45");        //luxury tax
            s.Add("shipping_cost", "456.23");   //shipping cost

            custInfo.SetShipping(s);

            /* OR you can pass the individual args.
            custInfo.SetShipping(
                                   "Bob",                  //first name
                                   "Smith",                //last name
                                   "Widget Company Inc.",  //company name
                                   "111 Bolts Ave.",       //address
                                   "Toronto",              //city
                                   "Ontario",              //province
                                   "M8T 1T8",              //postal code
                                   "Canada",               //country
                                   "416-555-5555",         //phone
                                   "416-555-5555",         //fax
                                   "123.45",               //federal tax
                                   "12.34",                //prov tax
                                   "15.45",                //luxury tax
                                   "456.23"                //shipping cost
            );
            */

            Hashtable i1 = new Hashtable();

            i1.Add("name", "item1's name");
            i1.Add("quantity", "5");
            i1.Add("product_code", "item1's product code");
            i1.Add("extended_amount", "1.01");

            custInfo.SetItem(i1);

            /* OR you can pass the individual args.
            custInfo.SetItem(
                "item1's name",         //name
                "5",                    //quantity
                "item1's product code", //product code
                "1.01"                  //extended amount
            );
            */

            Hashtable i2 = new Hashtable();

            i2.Add("name", "item2's name");
            i2.Add("quantity", "7");
            i2.Add("product_code", "item2's product code");
            i2.Add("extended_amount", "5.01");

            custInfo.SetItem(i2);

            resPreauthCC.SetCustInfo(custInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resPreauthCC);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

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
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());

                //ResolveData
                Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    } // end TestResPreauthCC-CustInfo
}
