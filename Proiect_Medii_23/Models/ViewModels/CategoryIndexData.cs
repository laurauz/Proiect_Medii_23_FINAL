namespace Proiect_Medii_23.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EchipamentSki> EchipamenteSki { get; set; }
        public IEnumerable<EchipamentSkiCategory> EchipamentSkiCategories { get; set; }
    }
}
