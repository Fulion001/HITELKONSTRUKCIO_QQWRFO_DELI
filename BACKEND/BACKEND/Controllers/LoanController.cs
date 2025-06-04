using BACKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        [HttpPost("offers")]
        public IActionResult GetLoanOffers([FromBody] LoanRequest request)
        {
            if (request.LoanAmount <= 0 || request.InterestRate <= 0)
                return BadRequest("A hitelösszegnek és kamatlábnak pozitívnak kell lennie.");

            List<LoanOffer> offers = new List<LoanOffer>();
            int[] durations = { 5, 10, 15, 20, 25, 30 };

            foreach (var years in durations)
            {
                int months = years * 12;
                double monthlyRate = request.InterestRate / 100 / 12;

                // Kamatos kamat képlet (PMT formula)
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

            return Ok(offers);
        }
    }
}
