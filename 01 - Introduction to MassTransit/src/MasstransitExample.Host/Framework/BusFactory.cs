using System;
using MassTransit;
using MasstransitExample.Host.Events;

namespace MasstransitExample.Host.Framework
{
    public static class BusFactory
    {
        public static IBusControl CreateForRabbitMq()
        {
            return Bus.Factory.CreateUsingRabbitMq(configuration =>
            {
                configuration.Host("rabbitmq://localhost");
                configuration.ReceiveEndpoint(nameof(SomethingHappendEvent), endpointConfigurator =>
                {
                    endpointConfigurator.Handler<SomethingHappendEvent>(context =>
                    {
                        Console.WriteLine("Inside my consumer. Content of message was: " + context.Message.Content);
                        return null;
                    });
                });
            });
        }
    }
}