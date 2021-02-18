using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Saniuta_Robert.Data;
using Proiect_Restanta_Saniuta_Robert.Models;

namespace Proiect_Restanta_Saniuta_Robert.Pages.Productions
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext _context;

        public DeleteModel(Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Production Production { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Production = await _context.Production.FirstOrDefaultAsync(m => m.ID == id);

            if (Production == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Production = await _context.Production.FindAsync(id);

            if (Production != null)
            {
                _context.Production.Remove(Production);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
