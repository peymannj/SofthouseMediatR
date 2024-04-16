using AutoMapper;
using SofthouseMediatR.Dto;
using SofthouseMediatR.Models;

namespace SofthouseMediatR.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, GetCarResponse>();

        CreateMap<Car, CreateCarResponse>();
        CreateMap<CreateCarRequest, Car>();

        CreateMap<Car, UpdateCarResponse>();
        CreateMap<UpdateCarRequest, Car>();

        CreateMap<Car, DeleteCarResponse>(MemberList.Destination);
    }
}
