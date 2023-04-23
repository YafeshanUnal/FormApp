using Core.Application.Repositories.Query.Form;
using Core.Application.Wrappers.Responses;
using MediatR;

namespace Core.Application.Features.Queries.Form
{
    public class GetFormByIdQuery : IRequest<IResult<Core.Domain.Entities.Form>>
    {
        public Guid Id { get; set; }

        public GetFormByIdQuery(Guid id)
        {
            Id = id;
        }

        public class GetUserByIdHandler
            : IRequestHandler<GetFormByIdQuery, IResult<Core.Domain.Entities.Form>>
        {
            private readonly IFormQueryRepository FormRepository;

            public GetUserByIdHandler(IFormQueryRepository FormRepository)
            {
                this.FormRepository = FormRepository;
            }

            public async Task<IResult<Core.Domain.Entities.Form>> Handle(
                GetFormByIdQuery request,
                CancellationToken cancellationToken
            )
            {
                var query = await FormRepository.GetByIdAsync(request.Id);
                return query;
            }
        }
    }
}
