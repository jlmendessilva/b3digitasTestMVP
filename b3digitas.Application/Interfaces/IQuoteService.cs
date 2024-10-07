using b3digitas.Application.DTOs;


namespace b3digitas.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<QuoteDTO> GetBestPriceQuoteAsync(string operation, string coin, string quantity);
    }
}
