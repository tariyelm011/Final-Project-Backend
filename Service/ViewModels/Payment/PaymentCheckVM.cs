using Domain.Enum;

namespace Service.ViewModels.Payment
{
    public class PaymentCheckVM
    {
        public string Token { get; set; } = null!;
        public int ID { get; set; }
        public PaymentStatuses STATUS { get; set; }
    }

    public class OrderVMS
    {
        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string HppUrl { get; set; } = null!;
        public string Cvv2AuthStatus { get; set; } = null!;
        public string Secret { get; set; } = null!;
    }

}
