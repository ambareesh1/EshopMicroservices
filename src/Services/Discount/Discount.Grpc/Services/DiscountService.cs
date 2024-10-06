using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
        :DiscountProtoService.DiscountProtoServiceBase
        
    {

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupones.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
            {
                coupon = new Coupon { ProductName = "No discount", Amount = 0, Description = "No Discount", Id = 0 };
            }
            logger.LogInformation("Discount is retrived for productName : {productName} Amount : {Amount}", coupon.ProductName, coupon.Amount);
              var couponModal = coupon.Adapt<CouponModel>();
             return couponModal;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));

            dbContext.Coupones.Add(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is created for productName : {productName} Amount : {Amount}", coupon.ProductName, coupon.Amount);
            var couponModal = coupon.Adapt<CouponModel>();
            return couponModal;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
            dbContext.Coupones.Update(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is Updated for productName : {productName} Amount : {Amount}", coupon.ProductName, coupon.Amount);
            var couponModal = coupon.Adapt<CouponModel>();
            return couponModal;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {

            var coupon = await dbContext.Coupones.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
            dbContext.Coupones.Remove(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is Deleted for productName : {productName} Amount : {Amount}", coupon.ProductName, coupon.Amount);
            
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
