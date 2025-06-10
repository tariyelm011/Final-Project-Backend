using Domain.Common;

namespace Domain.Entity
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
