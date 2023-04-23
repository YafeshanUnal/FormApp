using AutoMapper;
using Core.Application.Wrappers.Requests.Form;
using Core.Application.Wrappers.Requests.User;

namespace Core.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            #region | User |
            CreateMap<CreateUserRequest, Domain.Entities.User>().ReverseMap();
            #endregion

            #region | Form |
            CreateMap<CreateFormRequest, Domain.Entities.Form>().ReverseMap();
            #endregion
        }
    }
}
