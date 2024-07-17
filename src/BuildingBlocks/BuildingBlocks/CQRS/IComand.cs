
using MediatR;

namespace BuildingBlocks.CQRS;

public interface IComand : IComand<Unit>
{

}

public interface IComand<out TResponse> : IRequest<TResponse>
{
}

