using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Common.Exceptions;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.Users.Data;
using BulkBuilder.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BulkBuilder.Application.Common.RequestInterceptors
{
    public class UserContextBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ClaimsPrincipal _currentUser;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public UserContextBehavior(IHttpContextAccessor accessor, IUnitOfWork unitOfWork, IMapper mapper,
            IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userContext = userContext;
            _currentUser = accessor.HttpContext?.User;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _mapper.Map(_currentUser, _userContext);

            var user = await _unitOfWork.User.GetUserByEmail(_userContext.Email);
            if (user == null)
            {
                user = _mapper.Map<User>(_currentUser);
                await _unitOfWork.User.InsertAsync(user);
                await _unitOfWork.CommitAsync();
            }

            _userContext.Id = user.Id;

            return await next();
        }
    }
}