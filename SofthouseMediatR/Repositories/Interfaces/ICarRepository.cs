using SofthouseMediatR.Models;

namespace SofthouseMediatR.Repositories.Interfaces;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id);

    Task<IEnumerable<Car>> GetAllAsync();

    Task<Car> CreateCarAsync(Car car);

    Task<Car?> UpdateCarAsync(Guid id, Car? car);

    Task<Guid> DeleteCarAsync(Guid id);
}
