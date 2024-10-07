using b3digitas.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Domain.Interfaces
{
    public interface IQuoteRepository
    {
        Task<Quote> GetBestPriceQuoteAsync(string operation, string coin, string quantity);

        Task SaveQuoteAsync(Quote quote);
    }
}
