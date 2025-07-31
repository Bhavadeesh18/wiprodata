using DOTNETCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DOTNETCORE.Pages
{
    public class EmployShow : PageModel
    {
        public List<Employ>? Employees { get; set; }

        public void OnGet()
        {
            Employees = new List<Employ>
            {
                new Employ{Empno=1,Name="Yamini",Basic=216579},
                new Employ{Empno=2,Name="Bablu",Basic=216579},
                new Employ{Empno=3,Name="Charan",Basic=216579}
            };
        }
    }
}
