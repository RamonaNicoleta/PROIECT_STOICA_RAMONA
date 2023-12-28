using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Rents
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public EditModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rent Rent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent =  await _context.Rent
                 .Include(b => b.Car)
                 .Include(b => b.Client)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (rent == null)
            {
                return NotFound();
            }
            Rent = rent;
           ViewData["CarID"] = new SelectList(_context.Car, "Id", "Name",Rent.CarID);
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID",Rent.ClientID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(Rent.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RentExists(int id)
        {
          return (_context.Rent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
