
namespace Catalog.API.Products.CreateProduct;

public record CreateProductComand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : IComand<CreateProductResult>;
public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler(IDocumentSession session) : IComandHandler<CreateProductComand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductComand command, CancellationToken cancellationToken)
    {
        // Create Product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
        // TODO
        // save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);


        // return result
        return new CreateProductResult(product.Id);
    }
}
