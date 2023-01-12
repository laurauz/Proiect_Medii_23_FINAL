using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.EchipamenteSki
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public IndexModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        public IList<EchipamentSki> EchipamentSki { get; set; } = default!;
        public EchipamentSkiData EchipamentSkiD { get; set; }
        public int EchipamentSkiID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string SizeDetailsSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            EchipamentSkiD = new EchipamentSkiData();
           
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            SizeDetailsSort = String.IsNullOrEmpty(sortOrder) ? "sizeDetails_desc" : "";
            //          BrandSort = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";

            CurrentFilter = searchString;

            EchipamentSkiD.EchipamenteSki = await _context.EchipamentSki
            .Include(b => b.Brand)
            .Include(b => b.SizeDetails)
            .Include(b => b.EchipamentSkiCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                EchipamentSkiD.EchipamenteSki = EchipamentSkiD.EchipamenteSki.Where(s => s.SizeDetails.SexAndSize.Contains(searchString)

               || s.SizeDetails.Sex.Contains(searchString)
               || s.Title.Contains(searchString));

            }

            if (id != null)
            {
                EchipamentSkiID = id.Value;
                EchipamentSki echipamentSki = EchipamentSkiD.EchipamenteSki
                .Where(i => i.ID == id.Value).Single();
                EchipamentSkiD.Categories = echipamentSki.EchipamentSkiCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    EchipamentSkiD.EchipamenteSki = EchipamentSkiD.EchipamenteSki.OrderByDescending(s =>
                   s.Title);
                    break;
                case "sizeDetails_desc":
                    EchipamentSkiD.EchipamenteSki = EchipamentSkiD.EchipamenteSki.OrderByDescending(s =>
                   s.SizeDetails.SexAndSize);
                    break;
            }
            
        }
    }
}
