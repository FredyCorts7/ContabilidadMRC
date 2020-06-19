using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContabilidadMRC.Data;
using ContabilidadMRC.Models;

namespace ContabilidadMRC.Pages.TypeProducts
{
    public class EditModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public EditModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IvaID"] = new SelectList(_context.Iva, "IvaID", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TypeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeProductExists(TypeProduct.TypeProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TypeProductExists(int id)
        {
            return _context.TypeProduct.Any(e => e.TypeProductID == id);
        }
    }
}
