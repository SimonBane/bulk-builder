using MediatR;

namespace BulkBuilder.Application.Abstractions
{
    public class BaseCommandRequest<TRequest, TResponse> : IRequest<TResponse>
    {
        public TRequest Model { get; set; }
    }
}
