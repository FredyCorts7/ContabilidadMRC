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
    public class ExpirationDateModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public ExpirationDateModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            DateTime expirationDate = DateTime.Now.AddDays(15);
            Product = await _context.Product
                .Where(p => p.ExpiredAt <= expirationDate)
                .Include(p => p.TypeProduct)
                .Include(p => p.Brand)
                .ToListAsync();
        }
    }
}