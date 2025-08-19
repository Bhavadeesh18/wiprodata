using System.ComponentModel.DataAnnotations;
namespace EmployCrud.Models
{
    public class Employ2 
    {
        [Key]
        public int Empno { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Dept { get; set; }
        public string? Desig { get; set; }
        public decimal Basic { get; set; }
    }
}
