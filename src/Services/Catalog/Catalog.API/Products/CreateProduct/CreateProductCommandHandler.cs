using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductComand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : IComand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : IComandHandler<CreateProductComand, CreateProductResult>
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


        // return result
        return new CreateProductResult(Guid.NewGuid());
    }
}
