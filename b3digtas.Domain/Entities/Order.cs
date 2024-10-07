using b3digitas.Domain.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            DomainExceptionValidation.When(string.IsNullOrEmpty(type), "Type cannot be empty or null");
            Type = type;

            DomainExceptionValidation.When(string.IsNullOrEmpty(money), "Money cannot be empty or null");
            DomainExceptionValidation.When(money.Length != 3, "Money must be equal to 3 characters");
            Money = money;

            DomainExceptionValidation.When(string.IsNullOrEmpty(symbol), "Symbol cannot be empty or null");
            DomainExceptionValidation.When(symbol.Length != 3, "Symbol must be equal to 3 characters");
            Symbol = symbol;

            
        }


    }
}
