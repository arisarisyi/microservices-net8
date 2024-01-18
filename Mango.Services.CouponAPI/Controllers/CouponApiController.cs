using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.CouponAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponApiController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            return _couponService.GetAllCoupons();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            return _couponService.GetCouponById(id);
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            return _couponService.GetCouponByCode(code);
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            return _couponService.CreateCoupon(couponDto);
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            return _couponService.UpdateCoupon(couponDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            return _couponService.DeleteCoupon(id);
        }
    }
}
