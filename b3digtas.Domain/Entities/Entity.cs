
using Newtonsoft.Json;

namespace b3digitas.Domain.Entities
{
    public abstract class Entity
    {
        [JsonProperty(PropertyName = "OrderId")]
        public Guid Id { get; protected set; }

        [JsonProperty(PropertyName = "datecreated")]
        public DateTime? DateCreated { get; protected set; }

    }
}
