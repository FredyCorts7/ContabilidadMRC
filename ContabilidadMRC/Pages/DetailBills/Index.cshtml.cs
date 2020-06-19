using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContabilidadMRC.Data;
using ContabilidadMRC.Models;

namespace ContabilidadMRC.Pages.DetailBills
{
    public class IndexModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public IndexModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public IList<DetailBill> DetailBill { get;set; }

        public async Task OnGetAsync()
        {
            DetailBill = await _context.DetailBill
                .Include(d => d.Bill)
                .Include(d => d.Product).ToListAsync();
        }
    }
}
