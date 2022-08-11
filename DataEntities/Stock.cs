using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockMarketApp.DataEntities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string SpecialRemarks { get; set; }
        [JsonIgnore]
        public DateTime? LastUpdate { get; set; }
    }
}
