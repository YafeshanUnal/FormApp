namespace Infrastructure.Repository.Command
{
    using Core.Application.Repositories.Command;
    using Core.Application.Repositories.Command.Form;
    using Core.Application.Repositories.Command.User;
    using Core.Domain.Common;
    using Core.Domain.Common.Interfaces;
    using Infrastructure.Context;

    public class FormCommandRepository
        : CommandRepository<Core.Domain.Entities.Form>,
            IFormCommandRepository
    {
        public FormCommandRepository(DatabaseContext context)
            : base(context) { }
    }
}
