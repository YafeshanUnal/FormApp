using AutoMapper;
using Core.Application.Repositories.Command.User;
using Core.Application.Wrappers.Requests.User;
using Core.Application.Wrappers.Responses;
using MediatR;

namespace Core.Application.Features.Commands.User
{
    public class CreateUserCommand : IRequest<IResult<Guid>>
    {
        public CreateUserRequest RequestModel { get; set; }

        public class CreateUserHandler : IRequestHandler<CreateUserCommand, IResult<Guid>>
        {
            private readonly IUserCommandRepository UserCommandRepository;
            private readonly IMapper mapper;

            public CreateUserHandler(IUserCommandRepository UserCommandRepository, IMapper mapper)
            {
                this.UserCommandRepository = UserCommandRepository;
                this.mapper = mapper;
            }

            public async Task<IResult<Guid>> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken
            )
            {
                var Users = mapper.Map<Domain.Entities.User>(request.RequestModel);
                var command = await UserCommandRepository.AddAsync(Users);

                return Result.Func(command);
            }
        }
    }
}
