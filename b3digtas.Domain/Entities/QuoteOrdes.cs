using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Domain.Entities
{
    public class QuoteOrdes : Entity
    {
        public Guid Order { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public Guid QuoteId { get; set; }
        public Quote Quote { get; set; }

        public QuoteOrdes() { 
        
            Id = Guid.NewGuid();
        }


    }
}
