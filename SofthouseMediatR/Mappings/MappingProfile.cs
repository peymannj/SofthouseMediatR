using AutoMapper;
using SofthouseCommon.MessageContracts;
using SofthouseMediatR.Dto;
using SofthouseMediatR.Models;

namespace SofthouseMediatR.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, GetCarResponse>();
        CreateMap<Car, CarCreatedMessage>();

        CreateMap<Car, CreateCarResponse>();
        CreateMap<CreateCarRequest, Car>();

        CreateMap<Car, UpdateCarResponse>();
        CreateMap<UpdateCarRequest, Car>();
        CreateMap<Car, CarUpdatedMessage>();

        CreateMap<Car, DeleteCarResponse>(MemberList.Destination);
        CreateMap<Car, CarDeletedMessage>();
    }
}
