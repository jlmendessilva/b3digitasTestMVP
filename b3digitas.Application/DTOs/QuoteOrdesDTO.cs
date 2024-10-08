
namespace b3digitas.Application.DTOs
{
    public class QuoteOrdesDTO
    {
        public Guid Order { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public Guid QuoteId { get; set; }
    }
}
