using Core.Application.Repositories.Query;
using Core.Application.Wrappers.Responses;
using MediatR;

namespace Core.Application.Features.Queries.User
{
    public class GetAllUserQuery : IRequest<IResult<IEnumerable<Core.Domain.Entities.User>>>
    {
        public class GetUserByIdHandler
            : IRequestHandler<GetAllUserQuery, IResult<IEnumerable<Core.Domain.Entities.User>>>
        {
            private readonly IUserQueryRepository UserRepository;

            public GetUserByIdHandler(IUserQueryRepository UserRepository)
            {
                this.UserRepository = UserRepository;
            }

            public async Task<IResult<IEnumerable<Core.Domain.Entities.User>>> Handle(
                GetAllUserQuery request,
                CancellationToken cancellationToken
            )
            {
                var query = await UserRepository.GetAllAsync();
                return query;
            }
        }
    }
}
