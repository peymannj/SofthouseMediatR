// using MediatR;
// using SofthouseMediatR.Commands;
// using SofthouseMediatR.Services.Interfaces;
//
// namespace SofthouseMediatR.Handlers;
//
// public class MessageHandler<T> : IRequestHandler<PublishMessageCommand<T>>
// {
//     private readonly IMessagingService _messagingService;
//
//     public MessageHandler(IMessagingService messagingService)
//     {
//         _messagingService = messagingService;
//     }
//
//     public async Task Handle(PublishMessageCommand<T> request, CancellationToken cancellationToken)
//     {
//         await _messagingService.PublishAsync(request, request.RoutingKey);
//     }
// }
