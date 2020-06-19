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
    public class DeleteModel : PageModel
    {
        private readonly ContabilidadMRC.Data.ContabilidadMRCContext _context;

        public DeleteModel(ContabilidadMRC.Data.ContabilidadMRCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Iva Iva { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Iva = await _context.Iva.FirstOrDefaultAsync(m => m.IvaID == id);

            if (Iva == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Iva = await _context.Iva.FindAsync(id);

            if (Iva != null)
            {
                _context.Iva.Remove(Iva);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
