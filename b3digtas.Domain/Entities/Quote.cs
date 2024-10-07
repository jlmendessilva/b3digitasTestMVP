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
        [JsonProperty(PropertyName = "operation")]
        public string Operation { get; private set; }

        [JsonProperty(PropertyName = "coin")]
        public string Coin { get; private set; }

        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; private set; }

        [JsonProperty(PropertyName = "totalvalue")]
        public decimal TotalValue { get; private set; }

        [JsonProperty(PropertyName = "usedOrder")]
        public List<Order> UsedOrders { get; private set; }

        public Quote(string operation, string coin, string quantity)
        {
            Id = Guid.NewGuid();
            UsedOrders = new List<Order>();

            DomainExceptionValidation.When(string.IsNullOrEmpty(operation), "Operation cannot be empty or null");
            DomainExceptionValidation.When(!(operation == "A" || operation == "B"), "Operation receives only one letter A (Ask) or B (Bid)");
            Operation = operation;

            DomainExceptionValidation.When(string.IsNullOrEmpty(coin), "Coin cannot be empty or null");
            DomainExceptionValidation.When(!(coin == "BTC" || coin == "ETH"), "BTC or ETH");
            Coin = coin;

            DomainExceptionValidation.When(string.IsNullOrEmpty(quantity.ToString()), "Quantity cannot be empty or null");
            Quantity = quantity;

            DateCreated = DateTime.Now;
        }

        public void SetTotalValue(decimal value) => TotalValue = value;

    }
}
