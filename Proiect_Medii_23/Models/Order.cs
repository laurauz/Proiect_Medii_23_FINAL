using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii_23.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public int? EchipamentSkiID { get; set; }
        public EchipamentSki? EchipamentSki { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}
