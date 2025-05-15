namespace Mango.Services.CouponAPI.Models.DTO
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
