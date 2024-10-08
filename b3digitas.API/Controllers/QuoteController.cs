using b3digitas.Application.DTOs;
using b3digitas.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace b3digitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quote;

        public QuoteController(IQuoteService quote)
        {
           _quote = quote;
        }

        [HttpGet]
        public async Task<QuoteDTO> GetQuote(string operation, string coin, string quantity)
        {
            return await _quote.GetBestPriceQuoteAsync(operation, coin, quantity);
        }

    }
}
