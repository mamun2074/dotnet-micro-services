
namespace Basket.API.Basket.StoreBasket;

public record StroeBasketRequest(ShoppingCart Cart);
public record StroeBasketResponse(string UserName);

public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StroeBasketRequest request, ISender sender) =>
        {
            var result = await sender.Send(request);
            var response = result.Adapt<StroeBasketResponse>();
            return Results.Created($"/basket/{response.UserName}", response);
        })
        .WithName("PostStoreBusket")
        .Produces<StroeBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("store basket")
        .WithDescription("store basket");
    }
}
