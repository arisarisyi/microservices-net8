using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI.Services
{
    public interface ICouponService
    {
        ResponseDto GetAllCoupons();
        ResponseDto GetCouponById(int id);
        ResponseDto GetCouponByCode(string code);
        ResponseDto CreateCoupon(CouponDto couponDto);
        ResponseDto UpdateCoupon(CouponDto couponDto);
        ResponseDto DeleteCoupon(int id);
    }

}
