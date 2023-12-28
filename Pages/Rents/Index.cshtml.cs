using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Rents
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public IndexModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

        public IList<Rent> Rent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rent != null)
            {
                Rent = await _context.Rent
                .Include(r => r.Car)
                .Include(r => r.Client).ToListAsync();
            }
        }
    }
}
