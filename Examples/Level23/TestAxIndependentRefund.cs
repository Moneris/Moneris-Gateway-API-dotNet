namespace Moneris
{
	using System;
	using System.Collections;
	using System.Text;

	public class TestAxIndependentRefund
	{
		public static void Main(string[] args)
		{
			string store_id = "moneris";
            string api_token = "hurgle";
			string processing_country_code = "CA";
			bool status_check = false;
			
			string order_id="Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string cust_id="CUST13343";
			string amount="62.37";
			string pan="373269005095005";
			string expiry_date="2012"; //YYMM
			string crypt="7";
			
			//Create Table 1 with details
			string n101 = "R6";	//Entity ID Code
			string n102 = "Retailing Inc. International";	//Name
			string n301 = "919 Oriole Rd.";		//Address Line 1
			string n401 = "Toronto";		//City
			string n402 = "On";			//State or Province
			string n403 = "H1T6W3";			//Postal Code

			string[] ref01 = {"4C", "CR"};	//Reference ID Qualifier
			string[] ref02 = {"M5T3A5", "16802309004"}; //Reference ID

			string big04 = "PO7758545";	//Purchase Order Number
			string big05 = "RN0049858";	//Release Number
			string big10 = "INV99870E";      //Invoice Number

			AxRef axRef1 = new AxRef();
			axRef1.SetRef(ref01[0], ref02[0]);
			axRef1.SetRef(ref01[1], ref02[1]);

			AxN1Loop n1Loop = new AxN1Loop();
			n1Loop.SetN1Loop(n101, n102, n301, n401, n402, n403, axRef1);

			AxTable1 table1 = new AxTable1();
			table1.SetBig04(big04);
			table1.SetBig05(big05);
			table1.SetBig10(big10);
			table1.SetN1Loop(n1Loop);
			
			//Create Table 2 with details
			//the sum of the extended amount field (pam05) must equal the level 1 amount field				
			string[] it102 = {"1", "1", "1", "1", "1"};	//Line item quantity invoiced
			string[] it103 = {"EA", "EA", "EA", "EA", "EA"};  //Line item unit or basis of measurement code
			string[] it104 = {"10.00", "25.00", "8.62", "10.00", "-10.00"};   //Line item unit price
			string[] it105 = {"", "", "", "", ""};	//Line item basis of unit price code
				
			string[] it10618 = {"MG", "MG", "MG", "MG", "MG"};   //Product/Service ID qualifier
			string[] it10719 = {"DJFR4", "JFJ49", "FEF33", "FEE43", "DISCOUNT"};   //Product/Service ID (corresponds to it10618)
				
			string[] txi01_GST = {"GS", "GS", "GS", "GS", "GS"};	//Tax type code
			string[] txi02_GST = {"0.70", "1.75", "1.00", "0.80","0.00"};	//Monetary amount
			string[] txi03_GST = {"", "", "", "",""};		//Percent
			string[] txi06_GST = {"", "", "", "",""};		//Tax exempt code
				
			string[] txi01_PST = {"PG", "PG", "PG","PG","PG"};	//Tax type code
			string[] txi02_PST = {"0.80", "2.00", "1.00", "0.80","0.00"};	//Monetary amount
			string[] txi03_PST = {"", "", "", "",""};		//Percent
			string[] txi06_PST = {"", "", "", "",""};		//Tax exempt code

			string[] pam05 = {"11.50", "28.75", "10.62", "11.50", "-10.00"};	//Extended line-item amount
			string[] pid05 = {"Stapler", "Lamp", "Bottled Water", "Fountain Pen", "DISCOUNT"};	//Line item description

			AxIt106s[] it106s = {new AxIt106s(), new AxIt106s(), new AxIt106s(), new AxIt106s(), new AxIt106s()};
			
			it106s[0].SetIt10618(it10618[0]);
			it106s[0].SetIt10719(it10719[0]);
			
			it106s[1].SetIt10618(it10618[1]);
			it106s[1].SetIt10719(it10719[1]);
			
			it106s[2].SetIt10618(it10618[2]);
			it106s[2].SetIt10719(it10719[2]);
			
			it106s[3].SetIt10618(it10618[3]);
			it106s[3].SetIt10719(it10719[3]);
			
			it106s[4].SetIt10618(it10618[4]);
			it106s[4].SetIt10719(it10719[4]);

			AxTxi[] txi = {new AxTxi(), new AxTxi(), new AxTxi(), new AxTxi(), new AxTxi()};

			txi[0].SetTxi(txi01_GST[0], txi02_GST[0], txi03_GST[0], txi06_GST[0]);
			txi[0].SetTxi(txi01_PST[0], txi02_PST[0], txi03_PST[0], txi06_PST[0]);

			txi[1].SetTxi(txi01_GST[1], txi02_GST[1], txi03_GST[1], txi06_GST[1]);
			txi[1].SetTxi(txi01_PST[1], txi02_PST[1], txi03_PST[1], txi06_PST[1]);

			txi[2].SetTxi(txi01_GST[2], txi02_GST[2], txi03_GST[2], txi06_GST[2]);
			txi[2].SetTxi(txi01_PST[2], txi02_PST[2], txi03_PST[2], txi06_PST[2]);

			txi[3].SetTxi(txi01_GST[3], txi02_GST[3], txi03_GST[3], txi06_GST[3]);
			txi[3].SetTxi(txi01_PST[3], txi02_PST[3], txi03_PST[3], txi06_PST[3]);

			txi[4].SetTxi(txi01_GST[4], txi02_GST[4], txi03_GST[4], txi06_GST[4]);
			txi[4].SetTxi(txi01_PST[4], txi02_PST[4], txi03_PST[4], txi06_PST[4]);

			AxIt1Loop it1Loop = new AxIt1Loop();
			it1Loop.SetIt1Loop(it102[0], it103[0], it104[0], it105[0], it106s[0], txi[0], pam05[0], pid05[0]);
			it1Loop.SetIt1Loop(it102[1], it103[1], it104[1], it105[1], it106s[1], txi[1], pam05[1], pid05[1]);
			it1Loop.SetIt1Loop(it102[2], it103[2], it104[2], it105[2], it106s[2], txi[2], pam05[2], pid05[2]);
			it1Loop.SetIt1Loop(it102[3], it103[3], it104[3], it105[3], it106s[3], txi[3], pam05[3], pid05[3]);
			it1Loop.SetIt1Loop(it102[4], it103[4], it104[4], it105[4], it106s[4], txi[4], pam05[4], pid05[4]);

			AxTable2 table2 = new AxTable2();
			table2.SetIt1Loop(it1Loop);

			//Create Table 3 with details
			AxTxi taxTbl3 = new AxTxi();
			taxTbl3.SetTxi("GS", "4.25","","");	//sum of GST taxes
			taxTbl3.SetTxi("PG", "4.60","","");	//sum of PST taxes
			taxTbl3.SetTxi("TX", "8.85","","");	//sum of all taxes

			AxTable3 table3 = new AxTable3();
			table3.SetTxi(taxTbl3);
			
			//Create and Set Level23 Object
			AxLevel23 level23 = new AxLevel23();
			level23.SetTable1(table1);
			level23.SetTable2(table2);
			level23.SetTable3(table3);

			AxIndependentRefund axIndependentRefund = new AxIndependentRefund();
			axIndependentRefund.SetOrderId(order_id);
			axIndependentRefund.SetCustId(cust_id);
			axIndependentRefund.SetAmount(amount);
			axIndependentRefund.SetPan(pan);
			axIndependentRefund.SetExpDate(expiry_date);
			axIndependentRefund.SetCryptType(crypt);
			axIndependentRefund.SetAxLevel23(level23);

			HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(axIndependentRefund);
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
