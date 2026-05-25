namespace Moneris
{
    using System;
	    using System.Collections;

    public class TestCanadaPBBGetConsentId
    {
      
        public static void Main(string[] args)
        {
            string store_id = "monca03650";
            string api_token = "7Yw0MPTlhjBRcZiE6837";
            string consentId = "d7636275-9f5e-4117-8e00-1845fab7a5e2";
            string processing_country_code = "CA";

            PBB_GetConsentId pbbGetConsentId = new PBB_GetConsentId();
            pbbGetConsentId.setConsentId(consentId);
            
            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(pbbGetConsentId);
            Console.WriteLine("Request: " + mpgReq.toXML());
            mpgReq.Send();
            try
            {
                Receipt receipt = mpgReq.GetReceipt();
                

                Console.WriteLine("CreatedOn = "+ receipt.getCreatedOn());
                Console.WriteLine("ConsentId = "+ receipt.getConsentId());
				 Console.WriteLine("Status =  "+ receipt.getStatus());

	            Console.WriteLine("");    
				Console.WriteLine("ShippingAddress");
                Console.WriteLine("StreetNumber = "+ receipt.getStreetNumber());
                Console.WriteLine("StreetName = "+ receipt.getStreetName());
                Console.WriteLine("City = "+ receipt.getCity());
                Console.WriteLine("Province = "+ receipt.getProvince());
                Console.WriteLine("PostalCode = "+ receipt.getPostalCode());
                Console.WriteLine("Country = "+ receipt.getCountry());
                Console.WriteLine("RecipientName = "+ receipt.getRecipientName());
                Console.WriteLine("ShippingAddressRef = "+ receipt.getShippingAddressRef());


				Console.WriteLine("");                
                Console.WriteLine("CustomerInfo Name = "+ receipt.getName());
                Console.WriteLine("CustomerInfo Email = "+ receipt.getEmail());
                Console.WriteLine("CustomerInfo PhoneNumber = "+ receipt.getPhoneNumber());
                Console.WriteLine("CustomerInfo AuthMethod = "+ receipt.getAuthMethod());
                Console.WriteLine("CustomerInfo UserType = "+ receipt.getUserType());
               
				Console.WriteLine("");	
                Console.WriteLine("Order Deatils:");
                Console.WriteLine("MerchantOrderRef = "+ receipt.getMerchantOrderRef());
                Console.WriteLine("PlacementMode ="+ receipt.getPlacementMode());
                Console.WriteLine("ShipmentType = "+ receipt.getShipmentType());
                PBBItems pbbItems = receipt.getPBBItems();
				int totalItems=pbbItems.getItemsCount();
				PBBItem[] pbbItem=pbbItems.getItems();
				
				Console.WriteLine("Total Items = "+totalItems);
                
				for(int i=totalItems-1;i>=0;i--)
				{
					Console.WriteLine("Item:", i-1);
					Console.WriteLine("ItemRef = "+pbbItem[i].getItemRef());
	                Console.WriteLine("ItemPaymentType = "+pbbItem[i].getItemPaymentType());
					Console.WriteLine("Amount = "+pbbItem[i].getAmount());	
					Console.WriteLine("Quantity = "+pbbItem[i].getQuantity());
	                Console.WriteLine("Description = "+pbbItem[i].getDescription());
					Console.WriteLine("ItemType = "+pbbItem[i].getItemType());
					if(pbbItem[i].getRecurringInfo() != null)
                    {
                    Console.WriteLine("Recurring Info: ");
					Console.WriteLine("AmountCapped = " + pbbItem[i].getRecurringInfo().getAmountCapped());
					Console.WriteLine("AmountVariance = " + pbbItem[i].getRecurringInfo().getAmountVariance());
					Console.WriteLine("DayOfMonth = " + pbbItem[i].getRecurringInfo().getDayOfMonth());
					Console.WriteLine("DayOfWeek = " + pbbItem[i].getRecurringInfo().getDayOfWeek());
					Console.WriteLine("FrequencyRate = " + pbbItem[i].getRecurringInfo().getFrequencyRate());
					Console.WriteLine("FrequencyType = " + pbbItem[i].getRecurringInfo().getFrequencyType());
					Console.WriteLine("MaxNumberOfPayments = " + pbbItem[i].getRecurringInfo().getMaxNumberOfPayments());
					Console.WriteLine("StartDate = " + pbbItem[i].getRecurringInfo().getStartDate());
					Console.WriteLine("EndDate = " + pbbItem[i].getRecurringInfo().getEndDate());
					Console.WriteLine("WeekOfMonth = " + pbbItem[i].getRecurringInfo().getWeekOfMonth());
					Console.WriteLine("RecurringType = " + pbbItem[i].getRecurringInfo().getRecurringType());
						
                    }
                    else
                    {
                        Console.WriteLine("Recurring Info is not present");
                    }
					Console.WriteLine("ItemName = "+pbbItem[i].getItemName());
					
					Console.WriteLine("");
                }
				  	Console.WriteLine("Payment Details ");
					Console.WriteLine("SubTotal = "+receipt.getSubTotal());
					Console.WriteLine("Amount = "+receipt.getAmount2());
					Console.WriteLine("Tax = "+receipt.getTax());
					Console.WriteLine("ShippingCost = "+receipt.getShippingCost());
					Console.WriteLine("Currency = "+receipt.getCurrency2());

					AdditionalFees additionalFees = receipt.getAdditionalFees();
					int totalAdditionalfee= additionalFees.getAdditionalFeeCount();
					AdditionalFee[] additionalFee=additionalFees.getAdditionalFee();
					
					Console.WriteLine("Additional Fees = ");
					Console.WriteLine("Total Additional Fees = "+totalAdditionalfee);
					for(int i=0;i<totalAdditionalfee;i++)
					{
						Console.WriteLine("Additional Fee:", i+1);
						Console.WriteLine("Name = "+additionalFee[i].getName());
						Console.WriteLine("Amount = "+additionalFee[i].getAmount());
					}

					Console.WriteLine("");
				    ArrayList merchant= receipt.getMerchantRequiredArray();
					for(int i=0;i<merchant.Count;i++)
                    {
                        Console.WriteLine("MerchantRequiredContactField =" +merchant[i]);
                    }

					Console.WriteLine("");
					ArrayList merchantSupported = receipt.getMerchantSupportedPaymentMethodArray();
					for(int i=0;i<merchantSupported.Count;i++)
                    {
                        Console.WriteLine("MerchantSupportedPaymentMethod =" +merchantSupported[i]);
                    }

					Console.WriteLine("");
					Console.WriteLine("TokenMetaData");
					Console.WriteLine("AccountType = "+receipt.getAccountType());
					Console.WriteLine("TokenState = "+receipt.getTokenState());
					Console.WriteLine("AccountLastDigits = "+receipt.getAccountLastDigits());
					Console.WriteLine("TokenPanLastDigits = "+receipt.getTokenPanLastDigits2());
					Console.WriteLine("\nAuthOn = "+receipt.getAuthOn());

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

