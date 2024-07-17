using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductComand(string Name, List<string> Category, string Description, string imageFile, decimal Price) : IRequest<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductComand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductComand request, CancellationToken cancellationToken)
    {
        //Business logic to create a product
        throw new NotImplementedException();
    }
}
