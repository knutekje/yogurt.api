using youghurt.Data;
using youghurt.Models;

namespace youghurt.Repositories;

public interface IVehicleRepository
{
    public Task<List<Vehicle>> GetVehicles();
    public Task<Vehicle> GetVehicleById(int id);
    public Task<Vehicle> CreateVehicle(Vehicle vehicle);
    public Task<Vehicle> UpdateVehicle(Vehicle vehicle);
    public Task<bool> DeleteVehicle(int id);
    
}