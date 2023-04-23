using Core.Application.Repositories.Command.Form;
using Core.Application.Repositories.Command.User;
using Core.Application.Repositories.Query;
using Core.Application.Repositories.Query.Form;
using Infrastructure.Repository.Command;
using Infrastructure.Repository.Query;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistencecServices(this IServiceCollection serviceCollection)
        {
            #region | User |
            serviceCollection.AddTransient<IUserQueryRepository, UserQueryRepository>();
            serviceCollection.AddTransient<IUserCommandRepository, UserCommandRepository>();
            #endregion

            #region | Form |
            serviceCollection.AddTransient<IFormQueryRepository, FormQueryRepository>();
            serviceCollection.AddTransient<IFormCommandRepository, FormCommandRepository>();
            #endregion
        }
    }
}
