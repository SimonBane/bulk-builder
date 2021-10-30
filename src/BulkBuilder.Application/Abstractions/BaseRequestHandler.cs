using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace BulkBuilder.Application.Abstractions
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
