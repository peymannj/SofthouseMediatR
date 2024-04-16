using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.DataContext;
using SofthouseMediatR.Models;

namespace SofthouseMediatR.Repositories.Interfaces;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDataContext _applicationDataContext;

    public CarRepository(ApplicationDataContext applicationDataContext)
    {
        _applicationDataContext = applicationDataContext;
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _applicationDataContext.Cars.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _applicationDataContext.Cars.ToListAsync();
    }

    public async Task<Car> CreateCarAsync(Car car)
    {
        await _applicationDataContext.Cars.AddAsync(car);
        await _applicationDataContext.SaveChangesAsync();

        return car;
    }

    public async Task<Car?> UpdateCarAsync(Guid id, Car? car)
    {
        var carToUpdate = await _applicationDataContext.Cars
            .SingleOrDefaultAsync(x => x.Id == id);

        if (car is null)
        {
            return null;
        }

        carToUpdate!.Name = car.Name;
        carToUpdate.Color = car.Color;

        await _applicationDataContext.SaveChangesAsync();

        return car;
    }

    public async Task<Guid> DeleteCarAsync(Guid id)
    {
        var carToDelete = await _applicationDataContext.Cars.SingleOrDefaultAsync(x => x.Id == id);

        _applicationDataContext.Cars.Remove(carToDelete!);
        await _applicationDataContext.SaveChangesAsync();

        return id;
    }
}
