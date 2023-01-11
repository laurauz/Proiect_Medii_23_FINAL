using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;
using Proiect_Medii_23.Models.ViewModels;

namespace Proiect_Medii_23.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public IndexModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get; set; } = default!;

        public BrandIndexData BrandData { get; set; }
        public int BrandID { get; set; }
        public int EchipamentSkiID { get; set; }
        public async Task OnGetAsync(int? id, int? echipamentSkiID)
        {
            BrandData = new BrandIndexData();
            BrandData.Brands = await _context.Brand
            .Include(i => i.EchipamenteSki)
            .ThenInclude(c => c.SizeDetails)
            .OrderBy(i => i.BrandName)
            .ToListAsync();
            if (id != null)
            {
                BrandID = id.Value;
                Brand brand = BrandData.Brands
                .Where(i => i.ID == id.Value).Single();
                BrandData.EchipamenteSki = brand.EchipamenteSki;
            }
        }
    }
}
