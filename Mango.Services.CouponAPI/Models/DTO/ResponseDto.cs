namespace Mango.Services.CouponAPI.Models.DTO
{
    public class ResponseDto
    {
        public Object? Result { get; set; }
        public bool? Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
