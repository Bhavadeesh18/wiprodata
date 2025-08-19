using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployCrudRazor.Models;

namespace EmployCrudRazor.Pages.Employs
{
    public class CreateModel : PageModel
    {
        private readonly EmployCrudRazor.Models.EFCoreDbContextcs _context;

        public CreateModel(EmployCrudRazor.Models.EFCoreDbContextcs context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employ Employ { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Auto-generate Empno
            var maxEmpno = _context.Employees.Any() ? _context.Employees.Max(e => e.Empno) : 0;
            Employ.Empno = maxEmpno + 1;

            _context.Employees.Add(Employ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
