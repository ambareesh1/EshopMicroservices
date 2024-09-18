
namespace Catalog.API.Products.GetPoducts
{
    public record GetProductRequest(int? PageNumber = 1, int ? PageSize = 10);
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var result = await sender.Send(new GetProductsQuery(request.PageNumber, request.PageSize));
                var response = result.Adapt<GetProductResponse>();
                return Results.Ok(response);
            }).WithName("GetProducts")
             .Produces<GetProductResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("GetProducts")
             .WithDescription("GetProducts");
        }
    }
}
