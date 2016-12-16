namespace Moneris
{
    using System;

    public class TestCanadaBatchClose
    {
        public static void Main(string[] args)
        {
            string store_id = "store5";
            string api_token = "yesguy";
            string ecr_no = "66013455";	//ecr within store
            string processing_country_code = "CA";
            bool status_check = false;

            BatchClose batchclose = new BatchClose();
            batchclose.SetEcrno(ecr_no);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(batchclose);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                if ((receipt.GetReceiptId()).Equals("Global Error Receipt"))
                {

                    Console.WriteLine("CardType = " + receipt.GetCardType());
                    Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                    Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                    Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                    Console.WriteLine("TransType = " + receipt.GetTransType());
                    Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                    Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                    Console.WriteLine("ISO = " + receipt.GetISO());
                    Console.WriteLine("BankTotals = null");
                    Console.WriteLine("Message = " + receipt.GetMessage());
                    Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                    Console.WriteLine("Complete = " + receipt.GetComplete());
                    Console.WriteLine("TransDate = " + receipt.GetTransDate());
                    Console.WriteLine("TransTime = " + receipt.GetTransTime());
                    Console.WriteLine("Ticket = " + receipt.GetTicket());
                    Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                }
                else
                {
                    foreach (string ecr in receipt.GetTerminalIDs())
                    {
                        Console.WriteLine("ECR: " + ecr);
                        foreach (string cardType in receipt.GetCreditCards(ecr))
                        {
                            Console.WriteLine("\tCard Type: " + cardType);

                            Console.WriteLine("\t\tPurchase: Count = "
                                                + receipt.GetPurchaseCount(ecr, cardType)
                                                + " Amount = "
                                                + receipt.GetPurchaseAmount(ecr,
                                                                              cardType));

                            Console.WriteLine("\t\tRefund: Count = "
                                                + receipt.GetRefundCount(ecr, cardType)
                                                + " Amount = "
                                                + receipt.GetRefundAmount(ecr, cardType));

                            Console.WriteLine("\t\tCorrection: Count = "
                                                + receipt.GetCorrectionCount(ecr, cardType)
                                                + " Amount = "
                                                + receipt.GetCorrectionAmount(ecr,
                                                                               cardType));

                        }
                    }
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
