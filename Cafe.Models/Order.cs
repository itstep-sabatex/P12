using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Waiter? Waiter { get; set; }
        public int WaiterId { get; set; }
        public ClientTable? ClientTable { get; set; }
        public int ClientTableId { get; set; }
        public double Bill { get; set; }
    }
}
