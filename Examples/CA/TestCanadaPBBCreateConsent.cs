namespace Moneris
{
    using System;

    public class TestCanadaPBBCreateConsent
    {
      
        public static void Main(string[] args)
        {
            string store_id = "monca03650";
            string api_token = "7Yw0MPTlhjBRcZiE6837";
            string pbb_merchant_id = "CAM0000001";
            string processing_country_code = "CA";

            PBB_CreateConsent pbbCreateConsent = new PBB_CreateConsent();
            pbbCreateConsent.setPBBMerchantId(pbb_merchant_id);
            RequiredContactInfo requiredContactInfo= new RequiredContactInfo();
            requiredContactInfo.addcontactField("NAME");
            requiredContactInfo.addcontactField("PHONE");
            requiredContactInfo.addcontactField("EMAIL");
            requiredContactInfo.addcontactField("SHIPPING_ADDRESS");
            pbbCreateConsent.setRequiredContactInfo(requiredContactInfo);

            SupportedMethodInfo supportedMethodInfo= new SupportedMethodInfo();
            supportedMethodInfo.addPaymentMethod("MASTERCARD_DEBIT");
            supportedMethodInfo.addPaymentMethod("VISA_DEBIT");
            supportedMethodInfo.addPaymentMethod("AMEX_CREDIT");
            supportedMethodInfo.addPaymentMethod("VISA_CREDIT");
            supportedMethodInfo.addPaymentMethod("MASTERCARD_CREDIT");

            pbbCreateConsent.setSupportedMethodInfo(supportedMethodInfo);

            PaymentInfo paymentInfo= new PaymentInfo();
            paymentInfo.setCurrency("CAD");
            paymentInfo.setAmount("4.00");
            paymentInfo.setSubTotal("2.00");
            paymentInfo.setTax("0.00");
            paymentInfo.setShippingCost("0.00");

            AdditionalFees additionalFees = new AdditionalFees();
            additionalFees.setAdditionalfee("java","1.00");
            additionalFees.setAdditionalfee("Dotnet","1.00");

            paymentInfo.setAdditionalFees(additionalFees);
            pbbCreateConsent.setPaymentInfo(paymentInfo);

            OrderInfo orderInfo = new OrderInfo();
            orderInfo.setShipmentType("NONE");
            orderInfo.setMerchantOrderRef("1695401825L1CLwAJ98p7JwAc");
            orderInfo.setPlacementMode("STANDARD");

            PBBItems pbbItems= new PBBItems();
            PBBItem pbbItem1 = new PBBItem();
            pbbItem1.setItemPaymentType("SINGLE");
            pbbItem1.setItemRef("1234567890");
            pbbItem1.setDescription("This is a test item 1");
            pbbItem1.setAmount("1.00");
            pbbItem1.setQuantity("1");
			pbbItem1.setItemName("TestItem1");
            RecurringInfo recurringInfo = new RecurringInfo();
            recurringInfo.setAmountCapped("100");
            recurringInfo.setAmountVariance("2.5");
            recurringInfo.setDayOfMonth("1");
            recurringInfo.setDayOfWeek("MON");
            recurringInfo.setStartDate("2023-10-01T00:00:00.000Z");
            recurringInfo.setEndDate("2025-12-31T23:59:59.000Z");
            recurringInfo.setFrequencyRate("50");
            recurringInfo.setFrequencyType("DAY");
            recurringInfo.setWeekOfMonth("FIRST");
 		//	recurringInfo.setRecurringType("SUBSCRIPTION");
            pbbItem1.setRecurringInfo(recurringInfo);
            pbbItems.addPbbItem(pbbItem1);
            
            PBBItem pbbItem2 = new PBBItem();
			pbbItem2.setItemRef("1234567891");
            pbbItem2.setItemPaymentType("SINGLE");
            pbbItem2.setDescription("This is a test item 2");
            pbbItem2.setAmount("1.00");
            pbbItem2.setQuantity("1");
            pbbItems.addPbbItem(pbbItem2);
            
            orderInfo.setPBBItems(pbbItems);
            pbbCreateConsent.setOrderInfo(orderInfo);
            
            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(pbbCreateConsent);
            Console.WriteLine("Request: " + mpgReq.toXML());
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                if (receipt.getConsentId() != null && receipt.getConsentId() != "")
                {
                    Console.WriteLine("ConsentId = "+ receipt.getConsentId());
                    Console.WriteLine("RequestId = "+ receipt.getRequestId());
                    Console.WriteLine("CorrelationId = "+ receipt.getCorrelationId());
                    Console.WriteLine("DeviceProfileSessionId = "+ receipt.getDeviceProfileSessionId());
                    
                }

                else
                {
                    Console.WriteLine("CODE = " +  receipt.getCode());
                    Console.WriteLine("Type = " + receipt.getType());
                    Console.WriteLine("Message" + receipt.GetMessage());
                }
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

