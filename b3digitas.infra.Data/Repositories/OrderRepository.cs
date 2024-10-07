using b3digitas.Domain.Entities;
using b3digitas.Domain.Interfaces;
using Microsoft.Azure.Cosmos;


namespace b3digitas.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Container _container;

        public OrderRepository(Container container)
        {
            _container = container;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await ExecuteQueryAsync("SELECT o.Quantity, o.Price, o.Symbol, o.Type FROM Orders o");
        }

        public async Task<IEnumerable<Order>> GetBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            ValidateDates(startDate, endDate);

            var query = new QueryDefinition("SELECT o.Quantity, o.Price, o.Symbol, o.Type FROM Orders o WHERE o.CreatedDate >= @startDate AND o.CreatedDate <= @endDate")
                        .WithParameter("@startDate", startDate.ToString("yyyy-MM-ddTHH:mm:ss"))
                        .WithParameter("@endDate", endDate.ToString("yyyy-MM-ddTHH:mm:ss"));

            return await ExecuteQueryAsync(query);
        }

        public async Task<IEnumerable<Order>> GetLatestOrdersAsync(string coin, string operation)
        {
            ValidateParameters(coin, operation);

            var query = new QueryDefinition("SELECT o.Quantity, o.Price, o.Type, o.Symbol FROM Orders o WHERE o.Type = @type AND o.Symbol = @symbol")
                        .WithParameter("@type", operation)
                        .WithParameter("@symbol", coin);

            return await ExecuteQueryAsync(query);
        }

        private async Task<IEnumerable<Order>> ExecuteQueryAsync(string queryString)
        {
            var query = new QueryDefinition(queryString);
            var iterator = _container.GetItemQueryIterator<Order>(query);
            return await ReadIteratorAsync(iterator);
        }

        private async Task<IEnumerable<Order>> ExecuteQueryAsync(QueryDefinition query)
        {
            var iterator = _container.GetItemQueryIterator<Order>(query);
            return await ReadIteratorAsync(iterator);
        }

        private async Task<IEnumerable<Order>> ReadIteratorAsync(FeedIterator<Order> iterator)
        {
            var items = new List<Order>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                items.AddRange(response.Resource);
            }

            return items;
        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("startDate deve ser menor ou igual a endDate");
            }
        }

        private void ValidateParameters(string coin, string operation)
        {
            if (string.IsNullOrEmpty(operation) || !(operation == "B" || operation == "A"))
            {
                throw new ArgumentNullException("Operation must be B (BID - sale) or A (ASK - purchase)");
            }

            if (string.IsNullOrEmpty(coin) || !(coin == "BTC" || coin == "ETH"))
            {
                throw new ArgumentNullException("Coin must be BTC or ETH");
            }
        }
    }

}
