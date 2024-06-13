using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SofthouseCommon.MessageContracts;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Dto.Identity.Role;
using SofthouseMediatR.Dto.Identity.User;
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

        CreateMap<IdentityRole, GetRoleResponse>();
        CreateMap<IdentityRole, CreateRoleResponse>();
        CreateMap<IdentityRole, UpdateRoleResponse>();

        CreateMap<IdentityUser, GetUserResponse>();
        CreateMap<CreateUserRequest, IdentityUser>();
        CreateMap<IdentityUser, CreateUserResponse>();
        CreateMap<UpdateUserRequest, IdentityUser>();
        CreateMap<IdentityUser, UpdateUserResponse>();
    }
}
