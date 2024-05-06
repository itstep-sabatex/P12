using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class Nomenclature
    {
        public int Id { get; set; }
        [MaxLength(100)]
        //[Column(TypeName ="varchar(200)")]
        [Display(Name ="Назва")]
        [StringLength(50,MinimumLength =5)]
        [RegularExpression(@"^[А-ЩЬЮЯҐЄІЇ]{2}\d{6}$",ErrorMessage ="Не правильно зазначено номер паспорта.")]
        public string Name { get; set; } = default!;
        public double Price { get; set; }

        public static IEnumerable<Nomenclature> DefaultNomenclatures()
        {
            yield return new Nomenclature { Id = 1, Name = "Суп гороховий", Price=45 };
            yield return new Nomenclature { Id = 2, Name = "Суп сирний", Price = 75 };
            yield return new Nomenclature { Id = 3, Name = "Суп харчо", Price = 55};
            yield return new Nomenclature { Id = 4, Name = "Лоці", Price = 105 };
            yield return new Nomenclature { Id = 5, Name = "Картопля фрі", Price = 60 };
        }
    }
}
