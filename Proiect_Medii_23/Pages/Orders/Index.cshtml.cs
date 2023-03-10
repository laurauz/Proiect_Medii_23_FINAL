using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public IndexModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }
        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(b => b.EchipamentSki)
                .ThenInclude(b => b.SizeDetails)
                .Include(b => b.Customer).ToListAsync();
            }
        }
    }
}