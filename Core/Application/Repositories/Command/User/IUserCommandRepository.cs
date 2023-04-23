using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Repositories.Command.User
{
    public interface IUserCommandRepository : ICommandRepository<Core.Domain.Entities.User> { }
}
