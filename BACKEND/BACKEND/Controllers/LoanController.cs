using BACKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Services;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanCalculatorService _calculator;

        public LoanController()
        {
            _calculator = new LoanCalculatorService();
        }

        [HttpPost("offers")]
        public IActionResult GetLoanOffers([FromBody] LoanRequest request)
        {
            if (request.LoanAmount <= 0 || request.InterestRate <= 0)
                return BadRequest("A hitelösszegnek és kamatlábnak pozitívnak kell lennie.");

            var offers = _calculator.CalculateOffers(request);
            return Ok(offers);
        }
    }
}
