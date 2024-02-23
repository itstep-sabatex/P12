using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class Nomenclature
    {
        public int Id { get; set; }
        [MaxLength(100)]
        //[Column(TypeName ="varchar(200)")]
        public string Name { get; set; } = default!;
        public double Price { get; set; }

    }
}
