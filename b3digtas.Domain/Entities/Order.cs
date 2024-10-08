using b3digitas.Domain.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Domain.Entities
{
    public sealed class Order : Entity
    {
        [JsonProperty(PropertyName = "quantity")]
        public string? Quantity { get; private set; }

        [JsonProperty(PropertyName = "price")]
        public string? Price { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string? Type { get; private set; }

        [JsonProperty(PropertyName = "symbol")]
        public string? Symbol { get; private set; }

        [JsonProperty(PropertyName = "money")]
        public string? Money { get; private set; }

        public Order()
        {
                
        }
        public Order(string quantity, string price, string type, string symbol, string money )
        { 
        
            DomainExceptionValidation.When(string.IsNullOrEmpty(price), "Price not null");
            Type = price;

            DomainExceptionValidation.When(string.IsNullOrEmpty(type) || !(type == "B" || type == "A"), "Type must be B (BID - sale) or A (ASK - purchase)");
            Type = type;

            DomainExceptionValidation.When(string.IsNullOrEmpty(money), "Money cannot be empty or null");
            Money = money;

            DomainExceptionValidation.When(string.IsNullOrEmpty(symbol) || !(symbol == "BTC" || symbol == "ETH"), "must be BTC or ETH");
            Symbol = symbol;

            
        }


    }
}
