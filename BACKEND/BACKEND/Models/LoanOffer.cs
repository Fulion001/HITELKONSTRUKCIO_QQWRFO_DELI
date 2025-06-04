namespace BACKEND.Models
{
    public class LoanOffer
    {
        // Futamidő években
        public int Years { get; set; }

        // Havi törlesztőrészlet
        public double MonthlyPayment { get; set; }

        // Teljes visszafizetendő összeg
        public double TotalRepayment { get; set; }
    }
}
