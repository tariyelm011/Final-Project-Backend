namespace Service.ViewModels
{
    public class ErrorVM
    {
        public string Name { get; set; } = "Error";
        public string Message { get; set; } = null!;
        public int StatusCode { get; set; }
    }
}
