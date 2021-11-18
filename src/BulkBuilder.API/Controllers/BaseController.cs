using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkBuilder.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<T> ExecuteRequestAsync<T>(IRequest<T> request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
