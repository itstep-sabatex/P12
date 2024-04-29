using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Nomenclature? Nomenclature { get; set; }
        public int NomenclatureId { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
        public double Sum { get; set; }
    }
}
