using Core.Application.Repositories.Query;
using Core.Application.Repositories.Query.Form;
using Core.Application.Wrappers.Responses;
using MediatR;

namespace Core.Application.Features.Queries.Form
{
    public class GetAllFormQuery : IRequest<IResult<IEnumerable<Core.Domain.Entities.Form>>>
    {
        public class GetUserByIdHandler
            : IRequestHandler<GetAllFormQuery, IResult<IEnumerable<Core.Domain.Entities.Form>>>
        {
            private readonly IFormQueryRepository FormRepository;

            public GetUserByIdHandler(IFormQueryRepository FormRepository)
            {
                this.FormRepository = FormRepository;
            }

            public async Task<IResult<IEnumerable<Core.Domain.Entities.Form>>> Handle(
                GetAllFormQuery request,
                CancellationToken cancellationToken
            )
            {
                var query = await FormRepository.GetAllAsync();
                return query;
            }
        }
    }
}
