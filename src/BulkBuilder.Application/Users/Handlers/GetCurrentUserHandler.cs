using System.Threading;
using System.Threading.Tasks;
using BulkBuilder.Application.Users.Requests;
using MediatR;

namespace BulkBuilder.Application.Users.Handlers
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUser, IUserContext>
    {
        private readonly IUserContext _userContext;

        public GetCurrentUserHandler(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public Task<IUserContext> Handle(GetCurrentUser request, CancellationToken cancellationToken) => Task.FromResult(_userContext);
    }
}