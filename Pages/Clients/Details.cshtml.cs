using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public DetailsModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

      public Client Client { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }
    }
}
