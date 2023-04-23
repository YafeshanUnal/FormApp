using Core.Application.Wrappers.Responses;

namespace Core.Application.Repositories.Query
{
    public interface IQueryRepository<T>
        where T : class
    {
        Task<IResult<IEnumerable<T>>> GetAllAsync();
        Task<IResult<T>> GetByIdAsync(Guid id);
    }
}
