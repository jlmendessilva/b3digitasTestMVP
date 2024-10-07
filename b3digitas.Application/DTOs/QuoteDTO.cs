using b3digitas.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Application.DTOs
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Operation { get; set; }
        public string Coin { get; set; }
        public string Quantity { get; set; }
        public decimal TotalValue { get; set; }
        public List<Order> UsedOrders { get; set; }
    }
}
