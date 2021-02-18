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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext _context;

        public IndexModel(Proiect_Restanta_Saniuta_Robert.Data.Proiect_Restanta_Saniuta_RobertContext context)
        {
            _context = context;
        }

        public IList<Production> Production { get;set; }

        public async Task OnGetAsync()
        {
            Production = await _context.Production.ToListAsync();
        }
    }
}
