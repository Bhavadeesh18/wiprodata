namespace CarRental.DTOs
{
    public class VehicleDto
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal EngineCapacity { get; set; }
        public string VehicleType { get; set; }
    }

    public class CreateVehicleDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal EngineCapacity { get; set; }
        public string VehicleType { get; set; }
    }
}
