namespace Infrastructure.Repository.Command
{
    using Core.Application.Repositories.Command;
    using Core.Application.Repositories.Command.User;
    using Core.Domain.Common;
    using Core.Domain.Common.Interfaces;
    using Infrastructure.Context;

    public class UserCommandRepository
        : CommandRepository<Core.Domain.Entities.User>,
            IUserCommandRepository
    {
        public UserCommandRepository(DatabaseContext context)
            : base(context) { }
    }
}
