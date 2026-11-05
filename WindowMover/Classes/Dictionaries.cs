namespace WindowMover.Classes;

public static class Dictionaries
{
    public static Dictionary<string, WindowCompareTemplate> windowCompareTemplateDictionary = new Dictionary<string, WindowCompareTemplate>();

    static Dictionaries()
    {
        foreach (WindowCompareTemplate enumValue in Enum.GetValues(typeof(WindowCompareTemplate)))
        {
            windowCompareTemplateDictionary.Add(Enums.GetEnumDescription(enumValue), enumValue);
        }
    }
}
