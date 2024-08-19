
namespace Catalog.API.Products.CreateProduct;

public record CreateProductComand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : IComand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductComand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(command => command.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(command => command.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(command => command.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}


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
