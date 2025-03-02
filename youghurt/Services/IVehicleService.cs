using youghurt.Models;

namespace youghurt.Services;

public interface IVehicleService
{
    public Task<List<Vehicle>> GetVehicles();
    public Task<Vehicle> GetVehicle(int id);
    public Task<Vehicle> CreateVehicle(Vehicle vehicle);
    public Task<Vehicle> UpdateVehicle(Vehicle vehicle);
    public Task<bool> DeleteVehicle(int id);
    
}