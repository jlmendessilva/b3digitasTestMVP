using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Application.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Type { get; set; }
        public string? Symbol { get; set; }
        public string? Money { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
