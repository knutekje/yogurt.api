using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using youghurt.Dtos;
using youghurt.Models;
using youghurt.Repositories;
using youghurt.Services;

namespace youghurt.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly ILogger<VehicleController> _logger;
    private readonly IMapper _mapper;

    public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger, IMapper mapper)
    {
        _vehicleService = vehicleService;
        _logger = logger;
        _mapper = mapper;
        
    }

    [HttpGet("vehicle/{id}")]
    public async Task<IActionResult> GetVehicleById(int id)
    {
        try
        {
            _logger.LogInformation("GetVehicleById called");
            var result = await _vehicleService.GetVehicle(id);
            if (result == null)
            {
                throw new LayerException($"Vehicle with id {id} not found");
            }
            var resulToReturn = _mapper.Map<VehicleCreateDto>(result);
            return Ok(resulToReturn);
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"vehicle with id {id} not found {ex}" );
        }
    }

    [HttpGet]
    public async Task<IEnumerable<VehicleResponseDto>> GetAllVehicles()
    {
        try
        {
            _logger.LogInformation("Getting all vehicles");
            var result = await _vehicleService.GetVehicles();
            var resultToReturn = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResponseDto>>(result);
            if (result == null)
            {
                throw new LayerException("Vehicles not found");
            }
            return resultToReturn;

        }
        catch (Exception ex)
        {
            throw new LayerException($"Failed to get vehicles {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody]VehicleCreateDto vehicledto)
    {
        if (vehicledto == null)
        {
            throw new LayerException("Invalid vehicle data");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var vehicleToCreate = _mapper.Map<Vehicle>(vehicledto);
            var result = await _vehicleService.CreateVehicle(vehicleToCreate);
            return result;
        }
        catch (Exception ex)
        {
            throw new LayerException($"Failed to create vehicle {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Vehicle>> UpdateVehicle(Vehicle vehicle)
    {
        try
        {
            var result = await _vehicleService.UpdateVehicle(vehicle);
            if (result == null)
            {
                throw new LayerException("Vehicle not updated");
            }
            return Ok($"Vehicle:{vehicle.Id} updated");
    
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"error while updating vehicle {ex.Message}");
        }
    }

    [HttpDelete]
    public async Task<ActionResult<Vehicle>> DeleteVehicle(Vehicle vehicle)
    {
        try
        {
            var result = await _vehicleService.DeleteVehicle(vehicle.Id);
            if (result == false)
            {
                throw  new LayerException($"Failed to delete vehicle {vehicle.Id}");
            }
            return Ok("vehicle deleted");
        }
        catch (Exception ex)
        {
            
            throw new LayerException($"error while deleting vehicle {ex.Message}");
        }
    }
    
}