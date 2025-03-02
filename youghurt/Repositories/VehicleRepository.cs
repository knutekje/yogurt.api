using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using youghurt.Data;
using youghurt.Models;

namespace youghurt.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly YoghurtDbContext _dbContext;

    public VehicleRepository(YoghurtDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Vehicle>> GetVehicles()
    {
        try
        {
            var result = await _dbContext.Vehicles.ToListAsync();
          

            return result;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"Error while getting vehicles: {ex}");
        }
    }



    public async Task<Vehicle> GetVehicleById(int id)
    {
        try
        {
           var result = await _dbContext.Vehicles.FindAsync(id);
           if (result == null)
           {
               throw new LayerException($"vehicle with id: {id}, not found");
           }
           return result;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"error while getting vehicle by id: {ex}");
        }
    }

    public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
    {
        try
        {
            var result = await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"unable to create vehicle: {ex}");
        }
    }

    public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
    {
        try
        {
            var currentVehicle = await _dbContext.Vehicles.FindAsync(vehicle.Id);
            if (currentVehicle == null)
            {
                throw new LayerException($"Vehicle with id: {vehicle.Id}, not found");
            }
            _dbContext.Entry(currentVehicle).CurrentValues.SetValues(vehicle);
            await _dbContext.SaveChangesAsync();
            return vehicle;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"unable to update vehicle: {ex}");
        }
    }

    public async Task<bool> DeleteVehicle(int id)
    {
        try
        {
            var currentVehicle = await _dbContext.Vehicles.FindAsync(id);
            var result =_dbContext.Vehicles.Remove(currentVehicle);
            if (result.Entity == null)
            {
                return false;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"Error while deleting vehicle: {ex}");
        }
    }
}