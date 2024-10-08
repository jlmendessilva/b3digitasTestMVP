using b3digitas.Domain.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Domain.Entities
{
    public sealed class Quote : Entity
    {
        public string Operation { get; private set; }

        public string Coin { get; private set; }

        public string Quantity { get; private set; }

        public string QuantityAvailable { get; private set; }

        public decimal TotalValue { get; private set; }

        public List<QuoteOrdes> UsedOrders { get; private set; } = new List<QuoteOrdes>();

        public Quote(string operation, string coin, string quantity)
        {
            Id = Guid.NewGuid();

            DomainExceptionValidation.When(string.IsNullOrEmpty(operation) || !(operation == "B" || operation == "A"), "Operation receives only one letter A (Ask) or B (Bid)");
            Operation = operation;

            DomainExceptionValidation.When(string.IsNullOrEmpty(coin) || !(coin == "BTC" || coin == "ETH"), "Coin must be BTC or ETH");
            DomainExceptionValidation.When(!(coin == "BTC" || coin == "ETH"), "BTC or ETH");
            Coin = coin;

            DomainExceptionValidation.When(string.IsNullOrEmpty(quantity.ToString()), "Quantity cannot be empty or null");
            Quantity = quantity;

            DateCreated = DateTime.Now;
        }

        public void SetTotalValue(decimal value) => TotalValue = value;

        public void SetOrders(List<QuoteOrdes> orders) => UsedOrders = orders;

        public void SetQuantityAvailable(string value) => QuantityAvailable = value;

    }
}
