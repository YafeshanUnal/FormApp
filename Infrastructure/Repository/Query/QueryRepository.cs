using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Repositories.Query;
using Core.Application.Wrappers.Responses;
using Core.Domain.Common;
using Core.Domain.Common.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Query
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : class, IBaseEntity
    {
        private readonly DatabaseContext _context;

        public QueryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IResult<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();
                return Result.Func(result);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<IResult<T>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                return Result.Func(result);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
