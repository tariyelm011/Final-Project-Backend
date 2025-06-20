using Domain.Entity;
using Service.Dtos.AboutUs;
using Service.Dtos.Expert;

namespace Final_Backend_Project.ViewModelsUI
{
    public class AboutUsUiVM
    {
        public AboutUsVM AboutUsVM { get; set; }
        public List<ExpertVM> Experts { get; set; } = new List<ExpertVM>();
    }
}
