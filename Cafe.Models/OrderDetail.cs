using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order? Order { get; set; }
        public int OrderId { get; set; }
        public Nomenclature? Nomenclature { get; set; }
        public int NomenclatureId { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
        public double Sum { get; set; }
    }
}
