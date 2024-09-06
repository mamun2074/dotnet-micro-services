
namespace Basket.API.Basket.StoreBasket;

public record StroeBasketCommand(ShoppingCart Cart) : IComand<StroeBasketResult>;

public record StroeBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StroeBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is required");
    }
}

public class StoreBasketCommandHandler : IComandHandler<StroeBasketCommand, StroeBasketResult>
{
    public async Task<StroeBasketResult> Handle(StroeBasketCommand comand, CancellationToken cancellationToken)
    {
        ShoppingCart Cart = comand.Cart;

        // Todo: store basket in database (use Maren upsert - if exist then update, if not exist create;
        // Todo: update cache

        return new StroeBasketResult("korim");
    }
}
