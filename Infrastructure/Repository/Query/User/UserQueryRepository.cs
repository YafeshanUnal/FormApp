namespace Infrastructure.Repository.Query
{
    using Core.Application.Repositories.Query;
    using Core.Domain.Common;
    using Core.Domain.Common.Interfaces;
    using Infrastructure.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserQueryRepository
        : QueryRepository<Core.Domain.Entities.User>,
            IUserQueryRepository
    {
        public UserQueryRepository(DatabaseContext context)
            : base(context) { }
    }
}
