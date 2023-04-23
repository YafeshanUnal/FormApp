namespace Infrastructure.Repository.Query
{
    using Core.Application.Repositories.Query;
    using Core.Application.Repositories.Query.Form;
    using Core.Domain.Common;
    using Core.Domain.Common.Interfaces;
    using Infrastructure.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FormQueryRepository
        : QueryRepository<Core.Domain.Entities.Form>,
            IFormQueryRepository
    {
        public FormQueryRepository(DatabaseContext context)
            : base(context) { }
    }
}
