using AutoMapper;
using Core.Application.Repositories.Command.Form;
using Core.Application.Repositories.Command.User;
using Core.Application.Wrappers.Requests.Form;
using Core.Application.Wrappers.Requests.User;
using Core.Application.Wrappers.Responses;
using MediatR;

namespace Core.Application.Features.Commands.Form
{
    public class CreateFormCommand : IRequest<IResult<Guid>>
    {
        public CreateFormRequest RequestModel { get; set; }

        public class CreateFormHandler : IRequestHandler<CreateFormCommand, IResult<Guid>>
        {
            private readonly IFormCommandRepository FormCommandRepository;
            private readonly IMapper mapper;

            public CreateFormHandler(IFormCommandRepository FormCommandRepository, IMapper mapper)
            {
                this.FormCommandRepository = FormCommandRepository;
                this.mapper = mapper;
            }

            public async Task<IResult<Guid>> Handle(
                CreateFormCommand request,
                CancellationToken cancellationToken
            )
            {
                var Forms = mapper.Map<Core.Domain.Entities.Form>(request.RequestModel);
                System.Console.WriteLine(Forms);
                var command = await FormCommandRepository.AddAsync(Forms);

                return Result.Func(command);
            }
        }
    }
}
