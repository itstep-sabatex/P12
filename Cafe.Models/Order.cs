
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    //[Table("or_der_f")]
    //[Comment("Client Order Table")]
    public class Order
    {
        public int Id { get; set; }
        [Key]
        public DateTime Date { get; set; }
        public Waiter? Waiter { get; set; }
        public int WaiterId { get; set; }
        public ClientTable? ClientTable { get; set; }
        public int ClientTableId { get; set; }
        //[NotMapped]
        //[Column("ITOG")]
        //[Precision(16,2)]    // 2345.56  real/double  (numeric/decimal)
        public double Bill { get; set; }
    }
    
 

}
