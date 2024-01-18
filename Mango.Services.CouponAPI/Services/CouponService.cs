using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CouponService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ResponseDto GetAllCoupons()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDto GetCouponById(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDto GetCouponByCode(string code)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());
                if (obj == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data not found";
                }
                response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDto CreateCoupon(CouponDto couponDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDto UpdateCoupon(CouponDto couponDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseDto DeleteCoupon(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }

}
