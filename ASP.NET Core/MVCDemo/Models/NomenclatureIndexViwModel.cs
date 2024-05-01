namespace MVCDemo.Models
{
    public class NomenclatureIndexViwModel
    {
        public IEnumerable<Cafe.Models.Nomenclature> Items { get; set; }
        public  bool SearchMiddle { get; set; }
        public string Filter { get; set; }
    }
}
