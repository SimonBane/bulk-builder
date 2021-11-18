using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.Users.Data;
using MediatR;

namespace BulkBuilder.Application.Common.RequestInterceptors
{
    public class UserExistenceCheckBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IUserOwnedRequest<TResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserExistenceCheckBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!await _userRepository.IsExistingUser(request.UserId))
            {
                throw new HttpException(HttpStatusCode.BadRequest, "A user with the provided Id doesn't exist!");
            }

            return await next();
        }
    }
}