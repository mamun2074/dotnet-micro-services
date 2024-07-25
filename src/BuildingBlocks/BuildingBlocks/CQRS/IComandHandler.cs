using MediatR;

namespace BuildingBlocks.CQRS;

public interface IComandHandler<in TComand> : IComandHandler<TComand, Unit>
        where TComand : IComand<Unit>
{
}

public interface IComandHandler<in TComand, TResponse> : IRequestHandler<TComand, TResponse>
    where TComand : IComand<TResponse>
    where TResponse : notnull
{
}
