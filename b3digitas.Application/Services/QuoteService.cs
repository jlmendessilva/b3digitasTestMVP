using AutoMapper;
using b3digitas.Application.DTOs;
using b3digitas.Application.Interfaces;
using b3digitas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Application.Services
{
    public class QuoteService : IQuoteService
    {
        private IQuoteRepository _quote;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quote, IMapper mapper)
        {
                _quote = quote;
                _mapper = mapper;
        }

        public async Task<QuoteDTO> GetBestPriceQuoteAsync(string operation, string coin, string quantity)
        {
            var quoteEntities = await _quote.GetBestPriceQuoteAsync(operation, coin, quantity);

            return _mapper.Map<QuoteDTO>(quoteEntities);
        }
    }
}
