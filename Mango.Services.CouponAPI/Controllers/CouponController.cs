using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CouponController : Controller
    {
        private readonly AppDbContext _appDb;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponController(AppDbContext db, IMapper mapper)
        {
            _appDb = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> list = _appDb.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(list);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _appDb.Coupons.First(x => x.Id == id);
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon coupon = _appDb.Coupons.First(c => c.Code.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _appDb.Coupons.Add(coupon);
                _appDb.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _appDb.Coupons.Update(coupon);
                _appDb.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                var coupon = _appDb.Coupons.First(c => c.Id == id);
                _appDb.Coupons.Remove(coupon);
                _appDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
