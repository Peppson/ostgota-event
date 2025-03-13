namespace Blazor.Helpers;

public static class Helper
{
    public static string GetBackgroundImageUrl(string? imagePath)
    {
        // Return a default image if no ImagePath is null
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            return "/images/Knight.jpg";
        }

        return imagePath; 
    }
}
