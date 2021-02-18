using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Saniuta_Robert.Data;
using Proiect_Restanta_Saniuta_Robert.Models;

namespace Proiect_Restanta_Saniuta_Robert.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext _context;

        public EditModel(Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.
                Include(b => b.Production)
                .Include(b => b.MovieCategories).ThenInclude(b => b.Category)
                .AsNoTracking().
                FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Movie);
            ViewData["ProductionID"] = new SelectList(_context.Set<Production>(), "ID", "ProductionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
            .Include(i => i.Production)
            .Include(i => i.MovieCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
            movieToUpdate,
            "Movie",
            i => i.Title, i => i.Regizor,
            i => i.Rating, i => i.PublishingDate, i => i.Production))
            {
                UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
            PopulateAssignedCategoryData(_context, movieToUpdate);
            return Page();
        }
    }
}
