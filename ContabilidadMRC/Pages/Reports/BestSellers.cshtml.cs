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
    public class BestSellersModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public BestSellersModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            var Detail = (from d in _context.DetailBill
                         group d by d.ProductID into gp
                         select new DetailBill
                         {
                             ProductID = gp.Key,
                             Quantity = gp.Sum(p => p.Quantity)
                         });

            Product = (from p in _context.Product
                       join d in Detail
                       on p.ProductID equals d.ProductID
                       orderby d.Quantity descending
                       select p).Take(5).ToList();
        }
    }
}