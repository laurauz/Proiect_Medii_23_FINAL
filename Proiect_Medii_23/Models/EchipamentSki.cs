using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace Proiect_Medii_23.Models
{
    public class EchipamentSki
    {
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        public string Title { get; set; }

        public int? SizeDetailsID { get; set; }
        public SizeDetails? SizeDetails { get; set; }


        [Column(TypeName = "decimal(6, 2)")
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime StocDate { get; set; }

        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }

        public ICollection<EchipamentSkiCategory>? EchipamentSkiCategories { get; set; }
    }
}
