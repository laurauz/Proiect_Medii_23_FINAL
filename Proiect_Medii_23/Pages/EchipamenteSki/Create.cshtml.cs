using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.EchipamenteSki
{
    public class CreateModel : EchipamentSkiCategoriesPageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public CreateModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            ViewData["SizeDetailsID"] = new SelectList(_context.Set<SizeDetails>(), "ID", "SexAndSize");

            var echipamentSki = new EchipamentSki();
            echipamentSki.EchipamentSkiCategories = new List<EchipamentSkiCategory>();
            PopulateAssignedCategoryData(_context, echipamentSki);

            return Page();
        }

        [BindProperty]
        public EchipamentSki EchipamentSki { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newEchipamentSki = EchipamentSki;
            if (selectedCategories != null)
            {
                newEchipamentSki.EchipamentSkiCategories = new List<EchipamentSkiCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new EchipamentSkiCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newEchipamentSki.EchipamentSkiCategories.Add(catToAdd);
                }
            }
            //   if (await TryUpdateModelAsync<Book>(
            // newBook,
            //"Book",
            // i => i.Title, i => i.Author,
            // i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            //{
            //  _context.Book.Add(newBook);
            //  await _context.SaveChangesAsync();
            //  return RedirectToPage("./Index");
            // }
            _context.EchipamentSki.Add(newEchipamentSki);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newEchipamentSki);
            return Page();
        }
    }
}
