namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestUSAACHDebitCustInfo
    {
        public static void Main(string[] args)
        {
            string order_id = "dotnetachdebitcustinfotest1";
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string amount = "1.00";

            //ACHInfo Variables
            string sec = "ppd";
            string cust_first_name = "Bob";
            string cust_last_name = "Smith";
            string cust_address1 = "3300 Bloor St W";
            string cust_address2 = "4th floor west tower";
            string cust_city = "Toronto";
            string cust_state = "ON";
            string cust_zip = "M1M1M1";
            string routing_num = "490000018";
            string account_num = "222222";
            string check_num = "11";
            string account_type = "checking";
            string micr = "t071000013t742941347o127";
            string dl_num = "CO-12312312";
            string magstripe = "no";
            string image_front = "";
            string image_back = "";
            string processing_country_code = "US";
            bool status_check = false;

            ACHInfo achinfo = new ACHInfo(sec, cust_first_name, cust_last_name,
                cust_address1, cust_address2, cust_city, cust_state, cust_zip,
                routing_num, account_num, check_num, account_type, micr);


            achinfo.SetImgFront(image_front);
            achinfo.SetImgBack(image_back);
            achinfo.SetDlNum(dl_num);
            achinfo.SetMagstripe(magstripe);

            ACHDebit achdebit = new ACHDebit();
            achdebit.SetOrderId(order_id);
            achdebit.SetAmount(amount);
            achdebit.SetAchInfo(achinfo);

            //************************OPTIONAL VARIABLES***************************

            //Cust_id Variable
            string cust_id = "customer1";
            achdebit.SetCustId(cust_id);

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

            achdebit.SetCustInfo(custInfo);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(achdebit);
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
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
