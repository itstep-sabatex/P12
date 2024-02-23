using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    [Index(nameof(Name))]
    public class Currency
    {
        [Key]
        public string Code { get; set; } //EUR //USD //GRN  
        public string Name { get; set; } // Долар Євро Гривня
    }
}
