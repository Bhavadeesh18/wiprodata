using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DailyRate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Available";

        [Required]
        public int PassengerCapacity { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal EngineCapacity { get; set; }

        [Required]
        [StringLength(30)]
        public string VehicleType { get; set; }
    }
}
