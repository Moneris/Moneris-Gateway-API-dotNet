namespace Moneris
{
    using System;

    public class TestCanadaPBBGetTransactionData
    {
      
        public static void Main(string[] args)
        {
            string store_id = "monca00597";
            string api_token = "uZIVXpqYgLn2epnt9HuH";
            string consentId = "d9abb1dd-b499-4bce-9de3-63d7560b6347";
            string amount = "21.00";
            string currency = "CAD";
            string transcation_type = "PURCHASE";
            string payment_type= "SINGLE";
            string processing_country_code = "CA";

            PBB_GetTransactionData pbbGetTransactionData = new PBB_GetTransactionData();
            pbbGetTransactionData.setConsentId(consentId);
            pbbGetTransactionData.setAmount(amount);
            pbbGetTransactionData.setCurrency(currency);
            pbbGetTransactionData.setTransactionType(transcation_type);
            pbbGetTransactionData.setPaymentType(payment_type);
            

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(pbbGetTransactionData);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();
                

                Console.WriteLine("TransactionRef = "+ receipt.getTransactionRef());
                Console.WriteLine("Transaction Data - PaymentMethod = "+ receipt.getPaymentMethod());
               // Console.WriteLine("Transaction Data - TransactionType = "+ receipt.getTransactionType());
                Console.WriteLine("Transaction Data - PaymentType = "+ receipt.getPBBPaymentType());
                Console.WriteLine("Transaction Data - Currency = "+ receipt.getCurrency());
                Console.WriteLine("Transaction Data - Amount = "+ receipt.getAmount());
                Console.WriteLine("Transaction Data - TransactionRef = "+ receipt.getTransactionReference());
                Console.WriteLine("Transaction Data - TokenExpiry = "+ receipt.getTokenExpiry());
                Console.WriteLine("Transaction Data - PaymentToken = "+ receipt.getPaymentToken());
                Console.WriteLine("Transaction Data - Cryptogram = "+ receipt.getCryptogram());
                Console.WriteLine("Transaction Data - CryptogramExpiry = "+ receipt.getCryptogramExpiry());
                Console.WriteLine("PaymentMethod = "+ receipt.getPaymentMethod2());
                Console.WriteLine("TokenPanLastDigits = "+ receipt.getTokenPanLastDigits());
				Console.WriteLine("Order MerchantOrderRef = "+ receipt.getMerchantOrderRef());
                Console.WriteLine("ECI = "+ receipt.GetECI());
                Console.WriteLine("Par ="+ receipt.GetPar());
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

