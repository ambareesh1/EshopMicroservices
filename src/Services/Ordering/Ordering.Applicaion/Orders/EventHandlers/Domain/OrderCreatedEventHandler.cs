﻿using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Ordering.Domain.Events;


namespace Ordering.Applicaion.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler
    (IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
    {
        public  Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);
            return Task.CompletedTask;
            //if (await featureManager.IsEnabledAsync("OrderFullfilment"))
            //{
            //   // var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
            //   // await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            //}
        }
    }
}
