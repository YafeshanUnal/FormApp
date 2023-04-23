using Core.Application.Repositories.Command;
using Core.Domain.Common;
using Core.Domain.Common.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository.Command
{
    public class CommandRepository<T> : ICommandRepository<T>
        where T : class, IBaseEntity
    {
        private readonly DatabaseContext _context;

        public CommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
