﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContabilidadMRC.Data;
using ContabilidadMRC.Models;

namespace ContabilidadMRC.Pages.TypeProducts
{
    public class DetailsModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public DetailsModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        public TypeProduct TypeProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeProduct = await _context.TypeProduct
                .Include(t => t.Iva).FirstOrDefaultAsync(m => m.TypeProductID == id);

            if (TypeProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
