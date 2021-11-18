using MediatR;

namespace BulkBuilder.Application.Abstractions
{
    public interface ICacheableRequest<out TResponse> : IRequest<TResponse>
    {
        string Key { get; }
    }
}