namespace Proiect_Medii_23.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<EchipamentSkiCategory>? EchipamentSkiCategories { get; set; }
    }
}
