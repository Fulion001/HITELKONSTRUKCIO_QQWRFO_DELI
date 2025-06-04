using BACKEND.Models;
namespace BACKEND.Services
{
    public class LoanCalculatorService
    {
        public List<LoanOffer> CalculateOffers(LoanRequest request)
        {
            List<LoanOffer> offers = new List<LoanOffer>();
            int[] durations = { 5, 10, 15, 20, 25, 30 };

            foreach (var years in durations)
            {
                int months = years * 12;
                double monthlyRate = request.InterestRate / 100 / 12;

                double monthlyPayment = request.LoanAmount *
                    (monthlyRate * Math.Pow(1 + monthlyRate, months)) /
                    (Math.Pow(1 + monthlyRate, months) - 1);

                offers.Add(new LoanOffer
                {
                    Years = years,
                    MonthlyPayment = Math.Round(monthlyPayment, 2),
                    TotalRepayment = Math.Round(monthlyPayment * months, 2)
                });
            }

            return offers;
        }
    }
}
