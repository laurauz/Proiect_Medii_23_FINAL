namespace Proiect_Medii_23.Models
{
    public class EchipamentSkiCategory
    {
        public int ID { get; set; }
        public int EchipamentSkiID { get; set; }
        public EchipamentSki EchipamentSki { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
