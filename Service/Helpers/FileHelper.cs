using Microsoft.AspNetCore.Http;

namespace Service.Helpers;

public static class FileHelper
{
    private static readonly List<string> AllowedExtensions = new() { ".jpg", ".jpeg", ".png", ".webp" };
    private static readonly List<string> AllowedVideoExtensions = new() { ".mp4" };
    private const long MaxFileSize = 209715200;

    public static (bool IsSuccess, string ErrorMessage) ValidateImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return (false, "Fayl not found.");

        if (file.Length > MaxFileSize)
            return (false, "file 200 MB.");

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!AllowedExtensions.Contains(extension))
            return (false, "(.jpg, .png, .jpeg, .webp).");

        return (true, string.Empty);
    }

    public static (bool IsSuccess, string ErrorMessage) ValidateVideo(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return (false, "Fayl not found.");

        if (file.Length > MaxFileSize)
            return (false, "file 200 MB.");

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!AllowedVideoExtensions.Contains(extension))
            return (false, "(.mp4).");

        return (true, string.Empty);
    }
}
