namespace youghurt.Dtos;

public class VehicleResponseDto
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public VehicleType Type { get; set; }
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public DateTime ModelDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastMaintenanceAt { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}
