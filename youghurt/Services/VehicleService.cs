using youghurt.Data;
using youghurt.Models;
using youghurt.Repositories;

namespace youghurt.Services;

public class VehicleService : IVehicleService
{
    private readonly ILogger<VehicleService> _logger;
    private readonly IVehicleRepository _vehicleRepository;
    public VehicleService(IVehicleRepository vehicleRepository, ILogger<VehicleService> logger)
    {
        _vehicleRepository = vehicleRepository;
        _logger = logger;
        
    }
    
    public async Task<List<Vehicle>> GetVehicles()
    {

        try
        {
            _logger.LogInformation("Getting vehicles"); 
            var result = await _vehicleRepository.GetVehicles();
            if (result == null)
            {
                throw new LayerException("No vehicles found");
            }
            _logger.LogInformation("Returning vehicles");
            return result;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Getting vehicles");
            throw new LayerException($"Error loading vehicles {ex.Message}");
        }
    }

    public async Task<Vehicle> GetVehicle(int id)
    {
        try
        {
            _logger.LogInformation("Getting vehicle");
            var result = await _vehicleRepository.GetVehicleById(id);
            if (result == null)
            {
                _logger.LogError("Vehicle not found");
                throw new LayerException($"No vehicle with id {id} found");
            }
            _logger.LogInformation("Returning vehicle");
            return result;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"Error loading vehicle {ex.Message}");
        }
    }

    public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
    {
        try
        {
            _logger.LogInformation("Creating vehicle");
            var result = await _vehicleRepository.CreateVehicle(vehicle);
            if (result == null)
            {
                _logger.LogError("Unable to create vehicle");
                throw new LayerException("Unable to create vehicle");
            }
            _logger.LogInformation("Created vehicle");
            return result;
        }
        catch (Exception ex)
        {
            throw new LayerException($"Error creating vehicle {ex.Message}");
        }
    }

    public Task<Vehicle> UpdateVehicle(Vehicle vehicle)
    {
        try
        {
            _logger.LogInformation("Updating vehicle");
            var result = _vehicleRepository.UpdateVehicle(vehicle);
            if (result == null)
            {
                throw new LayerException("Unable to update vehicle");
            }        
            return result;
            
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"Error updating vehicle {ex.Message}");
        }
    }

    public async Task<bool> DeleteVehicle(int id)
    {
        try
        {
            _logger.LogInformation("Deleting vehicle");
            var result = await _vehicleRepository.DeleteVehicle(id);
            if (result == false)
            {
                _logger.LogError("Unable to delete vehicle");
                throw new LayerException("Unable to delete vehicle");
            }
            return true;
            
            
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"Error deleting vehicle {ex.Message}");
        }
    }
}