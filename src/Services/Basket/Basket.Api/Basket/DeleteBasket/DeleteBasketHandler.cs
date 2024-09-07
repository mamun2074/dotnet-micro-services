
namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IComand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class DeleteBasketCommandHandler(IBasketRepository _basketRepository) : IComandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache
        await _basketRepository.DeleteBasket(command.UserName, cancellationToken);
        return new DeleteBasketResult(true);
    }
}
