using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Saniuta_Robert.Data;
using Proiect_Restanta_Saniuta_Robert.Models;

namespace Proiect_Restanta_Saniuta_Robert.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext _context;

        public IndexModel(Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
