using SofthouseMediatR.Dto.Car;

namespace SofthouseMediatR.Services.Interfaces;

public interface ICarService
{
    Task<GetCarResponse?> GetByIdAsync(Guid id);

    Task<IEnumerable<GetCarResponse>> GetAllAsync();

    Task<CreateCarResponse> CreateCarAsync(CreateCarRequest car);

    Task<UpdateCarResponse?> UpdateCarAsync(Guid id, UpdateCarRequest car);

    Task<Guid> DeleteCarAsync(Guid id);
}
