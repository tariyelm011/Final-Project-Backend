namespace Service.ViewModels.Contact
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsAnswer { get; set; }
    }

}
