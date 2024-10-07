using b3digitas.Domain.Entities;


namespace b3digitas.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetBetweenDatesAsync(DateTime date1, DateTime date2);
        Task<IEnumerable<Order>> GetLatestOrdersAsync(string coin, string operation);
    }
}
