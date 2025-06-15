using Domain.Common;

namespace Domain.Entity
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }

    }


}
