using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.TechnologyAggregate
{
    public class Technology
    {
        [JsonPropertyName("guid")]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
