using System.Threading;
using System.Threading.Tasks;
using BulkBuilder.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BulkBuilder.Application.Common.RequestInterceptors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheableRequest<TResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public CachingBehavior(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cachedResponse = _memoryCache.Get<TResponse>(request.Key);
            if (cachedResponse != null)
                return cachedResponse;

            var response = await next();

            _memoryCache.Set(request.Key, response);
            return response;
        }
    }
}