namespace Service.ViewModels.Contact
{
    public class ContactCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Answer { get; set; }
        public bool IsAnswer { get; set; }
    }

}
