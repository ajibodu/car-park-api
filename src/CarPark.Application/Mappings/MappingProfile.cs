using AutoMapper;
using CarPark.Application.RequestModel;
using CarPark.Application.ResponseModel;
using CarPark.Core.Entities;

namespace CarPark.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Entities.Car, CarRm>();
    }
}