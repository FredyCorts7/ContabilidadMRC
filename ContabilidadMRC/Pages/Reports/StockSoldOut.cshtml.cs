using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadMRC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadMRC.Pages.Reports
{
    public class StockSoldOutModel : PageModel
    {

        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public StockSoldOutModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Where(p => p.Stock <= 5)
                .Include(p => p.TypeProduct)
                .Include(p => p.Brand)
                .ToListAsync();
        }
    }
}