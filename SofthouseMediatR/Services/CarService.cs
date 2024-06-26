﻿using AutoMapper;
using SofthouseCommon.Constants;
using SofthouseCommon.MessageContracts;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Models;
using SofthouseMediatR.Repositories.Interfaces;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMessagingService _messagingService;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMessagingService messagingService, IMapper mapper)
    {
        _carRepository = carRepository;
        _messagingService = messagingService;
        _mapper = mapper;
    }

    public async Task<GetCarResponse?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Car Id not provided");
        }

        var car = await _carRepository.GetByIdAsync(id);

        return car is not null ? _mapper.Map<GetCarResponse>(car) : null;
    }

    public async Task<IEnumerable<GetCarResponse>> GetAllAsync()
    {
        var cars = await _carRepository.GetAllAsync();

        return cars.Any() ? _mapper.Map<IEnumerable<GetCarResponse>>(cars) : Enumerable.Empty<GetCarResponse>();
    }

    public async Task<CreateCarResponse> CreateCarAsync(CreateCarRequest carToCreateCarRequest)
    {
        if (carToCreateCarRequest is null)
        {
            throw new ArgumentNullException(nameof(carToCreateCarRequest), "Request cannot be null");
        }

        var carToCreate = _mapper.Map<Car>(carToCreateCarRequest);
        carToCreate.Id = Guid.NewGuid();

        var message = _mapper.Map<CarCreatedMessage>(carToCreate);
        await _messagingService.PublishAsync(message, MessageBrokerSettings.CarCreatedRout);
        
        await _carRepository.CreateCarAsync(carToCreate);

        return _mapper.Map<CreateCarResponse>(carToCreate);
    }

    public async Task<UpdateCarResponse?> UpdateCarAsync(Guid id, UpdateCarRequest updateCarRequest)
    {
        if (updateCarRequest.Id != id)
        {
            throw new ArgumentNullException(nameof(updateCarRequest), "Correct car Id not provided");
        }

        if (updateCarRequest is null)
        {
            throw new ArgumentNullException(nameof(updateCarRequest), "Request cannot be null");
        }

        var carToUpdate = await _carRepository.GetByIdAsync(id);

        if (carToUpdate is null)
        {
            return null;
        }

        carToUpdate.Id = id;
        carToUpdate.Name = updateCarRequest.Name;
        carToUpdate.Color = updateCarRequest.Color;

        var message = _mapper.Map<CarUpdatedMessage>(carToUpdate);
        await _messagingService.PublishAsync(message, MessageBrokerSettings.CarUpdatedRout);

        var updatedCar = await _carRepository.UpdateCarAsync(id, _mapper.Map<Car>(carToUpdate));

        return updatedCar is null ? null : _mapper.Map<UpdateCarResponse>(carToUpdate);
    }

    public async Task<Guid> DeleteCarAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Car Id not provided");
        }

        var carToDelete = await _carRepository.GetByIdAsync(id);

        if (carToDelete is null)
        {
            return Guid.Empty;
        }

        var message = _mapper.Map<CarDeletedMessage>(carToDelete);
        await _messagingService.PublishAsync(message, MessageBrokerSettings.CarDeletedRout);

        return await _carRepository.DeleteCarAsync(id);
    }
}
