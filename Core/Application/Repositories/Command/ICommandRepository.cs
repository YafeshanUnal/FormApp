using Core.Domain.Common;

namespace Core.Application.Repositories.Command
{
    public interface ICommandRepository<T>
        where T : class, IBaseEntity
    {
        Task<Guid> AddAsync(T entity);
    }
}
