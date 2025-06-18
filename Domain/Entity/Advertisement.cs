using Domain.Common;

namespace Domain.Entity;

public class Advertisement : BaseEntity
{
    public string Title { get; set; } = null!;
    public string YoutubeLink { get; set; } = null!;

}
