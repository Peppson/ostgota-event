namespace BlazorStandAlone.Helpers;

public static class Helper
{
    public static string GetBackgroundImageUrl(string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            return "/images/Knight.jpg";
        }

        return imagePath; 
    }
}
