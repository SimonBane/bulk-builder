using MediatR;

namespace BulkBuilder.Application.Users
{
    public interface IUserOwnedRequest<out TResponse> : IRequest<TResponse>
    {
        int UserId { get; set; }
    }
}