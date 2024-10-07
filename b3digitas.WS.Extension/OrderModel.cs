using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.WS.Extension
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Type { get; set; }
        public string? Symbol { get; set; }
        public string? Money { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
