namespace Moneris
{
    using System;

    public class TestCanadaMpiAcs
    {
        public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
            string amount = "1.00";
            string xid = "12345678910111214005";
            string MD = xid + "mycardinfo" + amount;
            string PaRes = "eJzFV9mSoloW/ZWMvI9EXQZBpIL0xmEGZR4E3xAREBCUUb++USuzsupWd1R3R0fnS8KKPa2z1z5u6L/Gsnjp40uTVae3V/RP5PUlPkXVPj" +
                    "slb6+uI3xZvP61pJ30EsecHUfdJV7Satw0YRK/ZPu3VwSZIRiCEHOcwhcogRAohZLYHSVIDEOw2euSNoAVNw9rdDGnJssFPqHfki6nnH9iNPz+OkW/RGl" +
                    "4apd0GJ0ZWVviBDqloOFvr3QZX2Ru+UNiGn6CNPzd2+juT81U75jtl6rjDprDE6oTXVUO3FTOnalHeVCP6hsN3y3ofdjGSwx5knhBya8Y8hWZ0fADp+t7" +
                    "OFBW3RQbR9Ap5WeEnk7mMh3cdYliOA1/vNHxWFeneLKYKH480/D34urwNHH54Y+cYk8o7fhLus3KT0Vh6FeU+opNBg+cbtqw7ZoloOFvT3QU9v2SBYBlA" +
                    "i1IU6XW0q2ceJkInn8T2YcJHUfZEplPRU3/H16gSKpL1qblvdQfARq+lwI/+rik7Sw5Tcku8cuknVPz9pq2bf0Vhodh+HOY/VldEnhqDAIjFDwZ7Jss+e" +
                    "P16RXv5dOh+rfc2PBUnbIoLLJb2E76UOM2rfYvH7X9Koxj3SOhsMWzX6ZQXyIUP325I8gMJaaY8K+DfmL2O1l+LvbShF+aNETvCX4KtKSt+BDfFRG/uJb" +
                    "89vrH50HgsiRu2v8k5Xu6zxHe43lh0cVLSBkQUgoUXdYySPQCIyBr1oUvuZu/vfs9LWn4o8ZvBJ7d+nQqT8N8pQSx54bCWHhJeOocSE9lS41nyhHgInZe" +
                    "7zkgQ/rBcZu8QGxd4wU/hGfMQkyrdQz0tDypK6iKdH4V9OeE7HZMVpE3I93nPHk9x3V1rKKqKeJTQ2pJQe3anjxdVi65VnT8Il4gUolLVcsuoXYFm4Tik" +
                    "7OuFcKVt1A3qRoijFUTwTw26/i3T534xnIVX5+sfAKhuLANn09sfGmzwySJadRVWWbNI8uCsGFZk03V0F+kt4OfOEBjkvyc5plIDQgDTFcAHIBUsxlYM+" +
                    "A80xT5QfHcG2+q01EA1OUnb8nEhGuwsdLoxqsqqJ74OF1AfOGq5mLgnr4cP2yH0DfbAOMHKY001TEH9QawyXLQHXncPLD8jqEf2JFljhy/VkH+iMukKut" +
                    "56sg7wGASzWNA4rC81u9E6l5Dr1rJICSPfBI/UHK42Vc7Uei2kpq4pdAFWDJyDlg/fSuHEbaKi/Dj+gbaJ9Y4SrGtI4xP7A2BbH2lC3yr3mFEumMZZ3rH" +
                    "wo1WyLxwizDqGG4EJNxQnWqBgUveee4nPw2JxAJRZfGgAkRk7bNoy7sZZ/L3cwXT8WmAY5nMXDGJyTXXeS8FWX/AzBMRruKVu9ZVQoISSpdjSef5uk2iM" +
                    "cP9UYLxZqYPLZwFnGHYo9AT4FLeIBQSBnHLZJCTWqto6w3QvpHms87wdDeXOPGE72IDk0KrvVydmU+eT6qTHn0pOZy82D3LNbrYWoaTBdo6OPYz+Nzae8" +
                    "I2z3PTHyOBDBMjL1jMsU2ZAyZgfubEPDkxQJWk9a0uGEMuTLbSqi1Gtty2XTDiRgzC3cq48rwIWN8gCB/tZtqi4NGeLAXSKRGNMI0EnQ3XnAp2TKXDJcw" +
                    "6Bz0we0kRqWgOowiBQb7YujOl04qs3uGpI2g4N8/nW2rtljYMmx7cIrNgNASGtGct23W+mLsyUiLKIS8Otevu9HYYyjJtafjnyfjlqJxu06gkWQIGeVKb" +
                    "rAAtjUR4asvQUr86BpUHI3sDylNOgQMKz/kkj9UkDy7wlXQrCjfVHAb2ia/5QTNtz/wkbdVhJabes+h1h1GIyuA+5/CIyqmDdgSIxgU3Da0mTH5g09i8Y" +
                    "4Nx/MXIcED/kD0ykSiFPPDVkePA6l36AGUUj+ONO6+7LxhV8S7j9UZLf1PK9mLIO8EV8DwMs9BeQxYx98L8hnbTzR8IZ5ivfOW2tgcEtOFmgcZSx6bXeE" +
                    "H6CScafgd4ttqtLLSuyGNZ9qSGlueqGPfrtgUVsZIvGyrWtTkEQzMbb+W8W13O0NxbO9fRJtqSlCZs5kmJHnbBeQuGPTvawlnuhGPTHdMG8v2xH5iuIpr" +
                    "hKeUKF7MHN+bBec8l5oZhbDvWYVD3e1gOjCoFiYTKe97WanjFMcP9vCRb5UOHOSXTraBR+MHVTOuEn3WysY9+W2+kvUVmocDXvDyYv7rCfr8flgoW7/2Q" +
                    "H/3wlX43s6frmyNGt5mVcl9vbkB91GWpPONMF7cpwf90TNnWZ5C+LRDIdN1eEotqkZzZ4XhMB25dh5hnNUXYNSuxXeCbwsh8xJEw5jyW8K00rsxRO3X+R" +
                    "pRKE18lQnkOETsWUHAw4GAGNjGvgLlSxUdicRKR9DJnI303XlhoAKplcHKxlnSIQM3rsdYESmKhHJvvRjestw3mbWCsjow5WbamdPWzwPzNMa2c+5iev4" +
                    "+pcRLsWxxkULH7f46penNHVfhxTL9h/yNZmEOyffzqKqtqK6d9pIEHZzBRQ8AkdWX6kWbASiT3WXjhzAQl3WPZK2EjCfZxkxr7HQVTtb/tN2DVRdRwPh+" +
                    "52al35wPUKW0gC2cN730WOuZknOOeQB77nBNmFoIcTlIxH3SvO9zMQgAkZPr1xlHFZje/XofUVwdvF+mLDsUj0YNHiPDiIXeSi2ftzttC9+UyLgqt36CH" +
                    "RiGkzPYO0iK+FiBRGQDEYxLKD27SfaOwEJ1hAl7Q8tkspUyUEQ/TntWNKy3GimCPSp2iSuAx0vJg1aoYg39lW7l2bh6nbv43247FD9zwvgWkj20nKql+L" +
                    "/+sx+FRFz+YgjpNLTj8rV/Cs188kOPttvXNc8GsEDzEkqwU8woO11iwmZadFMGvzgo6DqSeK7C72QM0IReukhPwxVEojCCprCIuTbmWfA/qNtF8c5nLgo" +
                    "6Dw5iZPSRuYGPa0eoOp6pF3FNXpw/Cqln4Bn7buzpuNT4zUJfA6mwD13us1Vcroyp1ZR3ubGJSX8FWXU6SODw693X0b6MKf99D4Y/d9PvW+viifXxt3z/" +
                    "CPn+F/wPBKRo1";
            string processing_country_code = "CA";
            bool status_check = false;

            MpiAcs resMpiAcs = new MpiAcs();
            resMpiAcs.SetPaRes(PaRes);
            resMpiAcs.SetMD(MD);

            //************************OPTIONAL VARIABLES***************************

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resMpiAcs);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            /**********************   REQUEST  ************************/

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("MpiMessage = " + receipt.GetMpiMessage());
                Console.WriteLine("MpiSuccess = " + receipt.GetMpiSuccess());

                if (receipt.GetMpiSuccess() == "true")
                {
                    Console.WriteLine("Cavv = " + receipt.GetMpiCavv());
                    Console.WriteLine("Crypt Type = " + receipt.GetMpiEci());
                }
				else
				{
					Console.WriteLine("Message = " + receipt.GetMessage());
				}

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
