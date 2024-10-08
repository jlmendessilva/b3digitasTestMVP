using b3digitas.Domain.Entities;
using b3digitas.Domain.Interfaces;
using b3digitas.Infra.Data.Context;


namespace b3digitas.Infra.Data.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        ApplicationDbContext _db;
        private readonly IOrderRepository _orderRepository;

        public QuoteRepository(IOrderRepository orderRepository, ApplicationDbContext db)
        {
            _orderRepository = orderRepository;
            _db = db;
                
        }

        public async Task<Quote> GetBestPriceQuoteAsync(string operation, string coin, string quantity)
        {
            var quote = new Quote(operation, coin, quantity);   


            // Obter a coleção de dados (JSON)
            var orders = await _orderRepository.GetLatestOrdersAsync(coin, operation);

            //reorganiza as orders
            var relevantOrders = operation.ToUpper() == "A"
            ? orders.Where(o => o.Symbol == coin && o.Type == "A").OrderBy(o => o.Price).ToList()
            : orders.Where(o => o.Symbol == coin && o.Type == "B").OrderByDescending(o => o.Price).ToList();

            quote.SetTotalValue(CalculatePrice(relevantOrders, Decimal.Parse(quantity, System.Globalization.CultureInfo.InvariantCulture), out var usedOrders));

            quote.SetOrders(usedOrders);
            quote.SetQuantityAvailable(quote.UsedOrders.Sum(x => Decimal.Parse(x.Quantity, System.Globalization.CultureInfo.InvariantCulture)).ToString());


            // Gravar a cotação no banco de dados
            await SaveQuoteAsync(quote);

            return quote;
        }

        public async Task SaveQuoteAsync(Quote quote)
        {
            _db.Add(quote);
            await _db.SaveChangesAsync();
        }

        private decimal CalculatePrice(IEnumerable<Order> orders, decimal quantity, out List<QuoteOrdes> usedOrders)
        {
            if(orders.Count() == 0 || orders == null)
                throw new InvalidOperationException("Existe lista de ordens para cotação");

            usedOrders = new List<QuoteOrdes>();
            decimal accumulatedQuantity = 0;
            decimal totalPrice = 0;

            foreach (var order in orders)
            {
                decimal orderQuantity = Decimal.Parse(order.Quantity, System.Globalization.CultureInfo.InvariantCulture);
                decimal remainingQuantity = quantity - accumulatedQuantity;

                if (orderQuantity <= remainingQuantity)
                {
                    totalPrice += orderQuantity * Decimal.Parse(order?.Price);
                    accumulatedQuantity += orderQuantity;

                    usedOrders.Add(new QuoteOrdes { Order = order.Id, Price = order.Price, Quantity = order.Quantity });
                }
                
            }


            return totalPrice;
        }
    }
}
