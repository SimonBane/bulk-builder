using System.Threading.Tasks;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkBuilder.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) 
            : base(mediator)
        { }

        [HttpGet("current")]
        public async Task<IUserContext> GetCurrent()
        {
            return await ExecuteRequestAsync(new GetCurrentUser());
        }
    }
}