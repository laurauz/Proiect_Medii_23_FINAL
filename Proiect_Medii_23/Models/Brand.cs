namespace Proiect_Medii_23.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<EchipamentSki>? EchipamenteSki { get; set; }
    }
}
