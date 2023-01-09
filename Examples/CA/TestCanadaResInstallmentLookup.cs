namespace Moneris
{
	using System;
	using System.Collections;

	public class TestCanadaResInstallmentLookup
	{
		public static void Main(string[] args)
		{
			string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
			string store_id = "monca03650";
			string api_token = "7Yw0MPTlhjBRcZiE6837";
			string amount = "600.00";
			string data_key = "8cwY6hotzkM362ygNiyt1BtY0";
			string expdate = "2212";

			ResInstallmentLookup resInstallmentLookup = new ResInstallmentLookup();
			resInstallmentLookup.SetOrderId(order_id);
			resInstallmentLookup.SetAmount(amount);
			resInstallmentLookup.SetDataKey(data_key);
			//resInstallmentLookup.SetExpdate(expdate); //Temp Tokens only

			HttpsPostRequest mpgReq = new HttpsPostRequest();
			mpgReq.SetTestMode(true); //false or comment out this line for production transactions
			mpgReq.SetStoreId(store_id);
			mpgReq.SetApiToken(api_token);
			mpgReq.SetTransaction(resInstallmentLookup);

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
				Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());

				EligibleInstallmentPlans eligibleInstallmentPlans = receipt.GetEligibleInstallmentPlans();

				int planCount = eligibleInstallmentPlans.GetPlanCount();
				PlanDetails[] installmentPlans = eligibleInstallmentPlans.GetInstallmentPlans();

				for (int i = 0; i < planCount; i++)
				{
					Console.WriteLine("\nPlanId = " + installmentPlans[i].GetPlanId() + "\n");
					Console.WriteLine("PlanIdRef = " + installmentPlans[i].GetPlanIdRef());
					Console.WriteLine("Name = " + installmentPlans[i].GetName());
					Console.WriteLine("Type = " + installmentPlans[i].GetType());
					Console.WriteLine("NumInstallments = " + installmentPlans[i].GetNumInstallments());
					Console.WriteLine("InstallmentFrequency = " + installmentPlans[i].GetInstallmentFrequency());


					TAC tac = installmentPlans[i].GetTac();

					TACDetails[] tacDetailsList = tac.GetTacDetailsList();
					int tacCount = tac.GetTacCount();

					for (int j = 0; j < tacCount; j++)
					{
						TACDetails tacDetails = tacDetailsList[j];

						Console.WriteLine("\nText = " + tacDetails.GetText() + "\n");
						Console.WriteLine("Url = " + tacDetails.GetUrl());
						Console.WriteLine("Version = " + tacDetails.GetVersion());
						Console.WriteLine("LanguageCode = " + tacDetails.GetLanguageCode());
					}

					PromotionInfo promotionInfo = installmentPlans[i].GetPromotionInfo();

					Console.WriteLine("\nPromotionCode = " + promotionInfo.GetPromotionCode() + "\n");
					Console.WriteLine("PromotionId = " + promotionInfo.GetPromotionId());


					FirstInstallment firstInstallment = installmentPlans[i].GetFirstInstallment();

					Console.WriteLine("\nUpfrontFee = " + firstInstallment.GetUpfrontFee() + "\n");
					Console.WriteLine("InstallmentFee = " + firstInstallment.GetInstallmentFee());
					Console.WriteLine("Amount = " + firstInstallment.GetAmount());

					LastInstallment lastInstallment = installmentPlans[i].GetLastInstallment();

					Console.WriteLine("\nInstallmentFee = " + lastInstallment.GetInstallmentFee());
					Console.WriteLine("Amount = " + lastInstallment.GetAmount());

					Console.WriteLine("\nAPR = " + installmentPlans[i].GetAPR());
					Console.WriteLine("\nTotalFees = " + installmentPlans[i].GetTotalFees());
					Console.WriteLine("\nTotalPlanCost = " + installmentPlans[i].GetTotalPlanCost());
				}

				//Resolve Data
				Console.WriteLine("\ncust_id = " + receipt.GetResCustId());
				Console.WriteLine("phone = " + receipt.GetResPhone());
				Console.WriteLine("email = " + receipt.GetResEmail());
				Console.WriteLine("note = " + receipt.GetResNote());
				Console.WriteLine("expdate = " + receipt.GetResExpDate());
				Console.WriteLine("masked_pan = " + receipt.GetResMaskedPan());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}



