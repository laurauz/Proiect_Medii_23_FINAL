namespace Proiect_Medii_23.Models
{
    public class SizeDetails
    {
        public int ID { get; set; }
        public string Sex { get; set; }
        public string Size { get; set; }

        public string SexAndSize { get { return Sex + " " + Size; } }
    }
}
