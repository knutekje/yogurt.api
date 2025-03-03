using Microsoft.Extensions.Logging;
using NSubstitute;
using youghurt.Models;
using youghurt.Repositories;
using youghurt.Services;

namespace youghurt.Tests;

public class VehicleServiceTest
{
    private readonly IVehicleService _vehicleService;
    private readonly IVehicleRepository _vehicleRepository;
    
    private List<Vehicle> testVehicles;
    private ILogger<VehicleService> _logger;

    public VehicleServiceTest()
    { 
        _vehicleRepository = Substitute.For<IVehicleRepository>();
        _logger = Substitute.For<ILogger<VehicleService>>();
        testVehicles = new List<Vehicle>{ new Vehicle
                {
                    Id = 1,
                    RegistrationNumber = "ABC123",
                    Type = VechicleType.Car,
                    CarMake = "Toyota",
                    CarModel = "Corolla",
                    ModelDate = new DateTime(2018, 3, 15),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-3),
                    Longitude = 34.0522m,
                    Latitude = -118.2437m
                },
                new Vehicle
                {
                    Id = 2,
                    RegistrationNumber = "XYZ789",
                    Type = VechicleType.Truck,
                    CarMake = "Ford",
                    CarModel = "F-150",
                    ModelDate = new DateTime(2016, 6, 20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-6),
                    Longitude = 40.7128m,
                    Latitude = -74.0060m
                },
                new Vehicle
                {
                    Id = 3,
                    RegistrationNumber = "LMN456",
                    Type = VechicleType.Lorry,
                    CarMake = "Volvo",
                    CarModel = "FH16",
                    ModelDate = new DateTime(2019, 11, 5),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-1),
                    Longitude = 51.5074m,
                    Latitude = -0.1278m
                },
                new Vehicle
                {
                    Id = 4,
                    RegistrationNumber = "QRS234",
                    Type = VechicleType.Car,
                    CarMake = "Honda",
                    CarModel = "Civic",
                    ModelDate = new DateTime(2020, 1, 10),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-4),
                    Longitude = 48.8566m,
                    Latitude = 2.3522m
                },
                new Vehicle
                {
                    Id = 5,
                    RegistrationNumber = "TUV567",
                    Type = VechicleType.Truck,
                    CarMake = "Chevrolet",
                    CarModel = "Silverado",
                    ModelDate = new DateTime(2017, 7, 25),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-2),
                    Longitude = 41.8781m,
                    Latitude = -87.6298m
                },
                new Vehicle
                {
                    Id = 6,
                    RegistrationNumber = "DEF890",
                    Type = VechicleType.Lorry,
                    CarMake = "Mercedes-Benz",
                    CarModel = "Actros",
                    ModelDate = new DateTime(2021, 4, 30),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    LastMaintenanceAt = DateTime.Now.AddMonths(-5),
                    Longitude = 35.6895m,
                    Latitude = 139.6917m
                }};
        _vehicleRepository.GetVehicles().Returns(testVehicles);
        _vehicleRepository.GetVehicleById(Arg.Any<int>()).Returns(callInfo =>
        {
            var vehicleId = callInfo.Arg<int>();
            return testVehicles.FirstOrDefault(v => v.Id == vehicleId);
        } );
        
        _vehicleService = new VehicleService(_vehicleRepository, _logger);
    }

    [Fact]
    public async Task GetAll_ReturnsAllVehicles()
    {
        var result = await _vehicleService.GetVehicles();
        Assert.NotNull(result);
        Assert.Equal(testVehicles, result);
        
    }

    [Fact]
    public async Task GetById_ReturnsVehicle()
    {
        var result = await _vehicleService.GetVehicle(1);
        Assert.NotNull(result);
        Assert.IsType<Vehicle>(result);
        Assert.Equal(result, testVehicles[0]);
    }
    
    
}