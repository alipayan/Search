using MassTransit;
using System.Reflection;

namespace Search.Infrasctructor.Extensions
{

    public static class ApplicationExtensions
    {
        public static void BrokerConfigure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(configure =>
            {
                var brokerConfig = builder.Configuration.GetSection(BrokerOptions.SectionName)
                                                        .Get<BrokerOptions>();
                if (brokerConfig is null)
                {
                    throw new ArgumentNullException(nameof(BrokerOptions));
                }

                //configure.AddConsumers(Assembly.GetExecutingAssembly());

                configure.AddConsumers(Assembly.GetExecutingAssembly());

                configure.UsingRabbitMq((context, cfg) =>
                {
                    //cfg.UseRawJsonDeserializer();

                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.Username);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }

}
