using AutoMapper;
using youghurt.Dtos;
using youghurt.Models;

namespace youghurt.MappingProfle;

public class VehicleMappingProfile : Profile
{
    public VehicleMappingProfile()
    {
        CreateMap<VehicleCreateDto, Vehicle >();
        CreateMap<Vehicle, VehicleCreateDto>();

    }
}