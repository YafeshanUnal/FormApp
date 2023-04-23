using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Repositories.Command.Form
{
    public interface IFormCommandRepository : ICommandRepository<Core.Domain.Entities.Form> { }
}
