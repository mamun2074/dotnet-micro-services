using Marten.Linq.QueryHandlers;
using System.Linq;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProducstByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

public record GetProductsByCategoryResult(IEnumerable<Product> Products);

internal class GetProductsByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProducstByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProducstByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();
        return new GetProductsByCategoryResult(products);
    }
}
