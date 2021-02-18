using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Saniuta_Robert.Data;
using Proiect_Restanta_Saniuta_Robert.Models;

namespace Proiect_Restanta_Saniuta_Robert.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext _context;

        public DetailsModel(Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
