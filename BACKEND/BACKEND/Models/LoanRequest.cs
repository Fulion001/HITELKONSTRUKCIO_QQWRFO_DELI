namespace BACKEND.Models
{
    public class LoanRequest
    {
        // A felvenni kívánt hitel összege
        public double LoanAmount { get; set; }

        // A megadott kamatláb (pl. 7.5)
        public double InterestRate { get; set; }
    }
}
