namespace Service.ViewModels.Payment
{
    public class PaymentCreateVM
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
        public int OrderId { get; set; }
    }

}
