namespace Proiect_Medii_23.Models
{
    public class EchipamentSkiData
    {
        public IEnumerable<EchipamentSki> EchipamenteSki { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EchipamentSkiCategory> EchipamentSkiCategories { get; set; }
    }
}
