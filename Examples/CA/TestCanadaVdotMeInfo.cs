using System;
using System.Collections.Generic;

using System.Text;

namespace Moneris
{
    public class TestCanadaVdotMeInfo
    {
        public static void Main(string[] args)
        {
            string store_id = "store2";
            string api_token = "yesguy";
            string call_id = "5840726785406561048";
            string processing_country_code = "CA";
            bool status_check = false;

            VdotMeInfo vmeinfo = new VdotMeInfo();
            vmeinfo.SetCallId(call_id);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(vmeinfo);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("Response Code: " + receipt.GetResponseCode());
                Console.WriteLine("Response Message: " + receipt.GetMessage());
                Console.WriteLine("Currency Code: " + receipt.GetCurrencyCode());
                Console.WriteLine("Payment Totals: " + receipt.GetPaymentTotal());
                Console.WriteLine("User First Name: " + receipt.GetUserFirstName());
                Console.WriteLine("User Last Name: " + receipt.GetUserLastName());
                Console.WriteLine("Username: " + receipt.GetUserName());
                Console.WriteLine("User Email: " + receipt.GetUserEmail());
                Console.WriteLine("Encrypted User ID: " + receipt.GetEncUserId());
                Console.WriteLine("Creation Time Stamp: " + receipt.GetCreationTimeStamp());
                Console.WriteLine("Name on Card: " + receipt.GetNameOnCard());
                Console.WriteLine("Expiration Month: " + receipt.GetExpirationDateMonth());
                Console.WriteLine("Expiration Year: " + receipt.GetExpirationDateYear());
                Console.WriteLine("Last 4 Digits: " + receipt.GetLastFourDigits());
                Console.WriteLine("Bin Number (6 Digits): " + receipt.GetBinSixDigits());
                Console.WriteLine("Card Brand: " + receipt.GetCardBrand());
                Console.WriteLine("Card Type: " + receipt.GetVdotMeCardType());
                Console.WriteLine("Billing Person Name: " + receipt.GetPersonName());
                Console.WriteLine("Billing Address Line 1: " + receipt.GetBillingAddressLine1());
                Console.WriteLine("Billing City: " + receipt.GetBillingCity());
                Console.WriteLine("Billing State/Province Code: " + receipt.GetBillingStateProvinceCode());
                Console.WriteLine("Billing Postal Code: " + receipt.GetBillingPostalCode());
                Console.WriteLine("Billing Country Code: " + receipt.GetBillingCountryCode());
                Console.WriteLine("Billing Phone: " + receipt.GetBillingPhone());
                Console.WriteLine("Billing ID: " + receipt.GetBillingId());
                Console.WriteLine("Billing Verification Status: " + receipt.GetBillingVerificationStatus());
                Console.WriteLine("Partial Shipping Country Code: " + receipt.GetPartialShippingCountryCode());
                Console.WriteLine("Partial Shipping Postal Code: " + receipt.GetPartialShippingPostalCode());
                Console.WriteLine("Shipping Person Name: " + receipt.GetShippingPersonName());
                Console.WriteLine("Shipping Address Line 1: " + receipt.GetShipAddressLine1());
                Console.WriteLine("Shipping City: " + receipt.GetShippingCity());
                Console.WriteLine("Shipping State/Province Code: " + receipt.GetShippingStateProvinceCode());
                Console.WriteLine("Shipping Postal Code: " + receipt.GetShippingPostalCode());
                Console.WriteLine("Shipping Country Code: " + receipt.GetShippingCountryCode());
                Console.WriteLine("Shipping Phone: " + receipt.GetShippingPhone());
                Console.WriteLine("Shipping Default: " + receipt.GetShippingDefault());
                Console.WriteLine("Shipping ID: " + receipt.GetShippingId());
                Console.WriteLine("Shipping Verification Status: " + receipt.GetShippingVerificationStatus());
                Console.WriteLine("isExpired: " + receipt.GetIsExpired());
                Console.WriteLine("Base Image File Name: " + receipt.GetBaseImageFileName());
                Console.WriteLine("Height: " + receipt.GetHeight());
                Console.WriteLine("Width: " + receipt.GetWidth());
                Console.WriteLine("Issuer Bid: " + receipt.GetIssuerBid());
                Console.WriteLine("Risk Advice: " + receipt.GetRiskAdvice());
                Console.WriteLine("Risk Score: " + receipt.GetRiskScore());
                Console.WriteLine("AVS Response Code: " + receipt.GetAvsResponseCode());
                Console.WriteLine("CVV Response Code: " + receipt.GetCvvResponseCode());
                Console.WriteLine("\r\nPress the enter key to exit");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
