using b3digitas.Domain.Entities;
using b3digitas.Domain.Interfaces;
using b3digitas.Infra.Data.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var relevantOrders = operation.ToLower() == "A"
            ? orders.Where(o => o.Symbol == coin && o.Type == "A").OrderBy(o => o.Price).ToList()
            : orders.Where(o => o.Symbol == coin && o.Type == "B").OrderByDescending(o => o.Price).ToList();

            quote.SetTotalValue(CalculatePrice(relevantOrders, Decimal.Parse(quantity), out var usedOrders));

            //quote.UsedOrders = usedOrders;

            // Gravar a cotação no banco de dados
            await SaveQuoteAsync(quote);

            return quote;
        }

        public async Task SaveQuoteAsync(Quote quote)
        {
            _db.Add(quote);
            await _db.SaveChangesAsync();
        }

        private decimal CalculatePrice(IEnumerable<Order> orders, decimal quantity, out List<Order> usedOrders)
        {
            if(orders.Count() == 0 || orders == null)
                throw new InvalidOperationException("Não há ordens suficientes para atender à quantidade solicitada.");

            usedOrders = new List<Order>();
            decimal accumulatedQuantity = 0;
            decimal totalPrice = 0;

            foreach (var order in orders)
            {
                decimal orderQuantity = Math.Min(Decimal.Parse(order?.Quantity), quantity - accumulatedQuantity);
                totalPrice += orderQuantity * Decimal.Parse(order?.Price);
                accumulatedQuantity += orderQuantity;
                usedOrders.Add(order);

                if (accumulatedQuantity >= quantity)
                {
                    break;
                }
            }

            if (accumulatedQuantity < quantity)
            {
                throw new InvalidOperationException("Não há ordens suficientes para atender à quantidade solicitada.");
            }

            return totalPrice;
        }
    }
}
