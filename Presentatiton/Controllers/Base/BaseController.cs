using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Presentation.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Guid JwtUserId
        {
            get
            {
                var token = HttpContext.Request.Headers["Authorization"];
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(
                    token.ToString().Replace("Bearer ", "")
                );

                return new Guid(jwtSecurityToken.Claims.First(claim => claim.Type == "jti").Value);
            }
        }
    }
}
