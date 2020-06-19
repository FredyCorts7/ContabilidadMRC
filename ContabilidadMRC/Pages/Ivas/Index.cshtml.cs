using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContabilidadMRC.Data;
using ContabilidadMRC.Models;

namespace ContabilidadMRC.Pages.Ivas
{
    public class IndexModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public IndexModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public IList<Iva> Iva { get;set; }

        public async Task OnGetAsync()
        {
            Iva = await _context.Iva.ToListAsync();
        }
    }
}
