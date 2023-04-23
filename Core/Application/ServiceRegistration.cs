using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection serviceCollection)
        {
            var assm = Assembly.GetExecutingAssembly();

            serviceCollection.AddAutoMapper(assm);
            serviceCollection.AddMediatR(assm);
        }
    }
}
