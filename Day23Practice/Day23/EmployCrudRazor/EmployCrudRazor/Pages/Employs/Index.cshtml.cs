using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployCrudRazor.Models;

namespace EmployCrudRazor.Pages.Employs
{
    public class IndexModel : PageModel
    {
        private readonly EmployCrudRazor.Models.EFCoreDbContextcs _context;

        public IndexModel(EmployCrudRazor.Models.EFCoreDbContextcs context)
        {
            _context = context;
        }

        public IList<Employ> Employ { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employ = await _context.Employees.ToListAsync();
        }
    }
}
