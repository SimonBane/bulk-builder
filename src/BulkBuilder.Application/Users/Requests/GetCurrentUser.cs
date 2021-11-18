using MediatR;

namespace BulkBuilder.Application.Users.Requests
{
    public class GetCurrentUser : IRequest<IUserContext>
    { }
}