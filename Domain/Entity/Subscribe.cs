using Domain.Common;

namespace Domain.Entity
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; } = null!;
        public DateTime SubscribedDate { get; set; }

    }


}
