using System.ComponentModel.DataAnnotations;

namespace youghurt.Dtos;

public class VehicleCreateDto
{
    [Required(ErrorMessage = "Registration number is required")]
    [StringLength(20, ErrorMessage = "Registration number can't exceed 20 characters")]
    public string RegistrationNumber { get; set; }

    [Required(ErrorMessage = "Vehicle type is required")]
    [EnumDataType(typeof(VehicleType), ErrorMessage = "Invalid vehicle type")]
    public VehicleType Type { get; set; }

    [Required(ErrorMessage = "Car make is required")]
    [StringLength(50, ErrorMessage = "Car make can't exceed 50 characters")]
    public string CarMake { get; set; }

    [Required(ErrorMessage = "Car model is required")]
    [StringLength(50, ErrorMessage = "Car model can't exceed 50 characters")]
    public string CarModel { get; set; }

    [Required(ErrorMessage = "Model date is required")]
    public DateTime ModelDate { get; set; }

    [Range(-180, 180, ErrorMessage = "Invalid longitude value")]
    public decimal Longitude { get; set; }

    [Range(-90, 90, ErrorMessage = "Invalid latitude value")]
    public decimal Latitude { get; set; }
}

public class VehicleType
{
}

public enum VechicleType
{
    Truck = 1,
    Car = 2,
    Lorry = 3,
}
