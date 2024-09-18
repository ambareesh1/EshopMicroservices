﻿
namespace Catalog.API.Products.GetProductById
{
    public record GetProductsByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductsByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductsByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id);
            if(product == null) {
                throw new ProductNotFoundException(query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
