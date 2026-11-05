using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WindowMover.Localization;

namespace WindowMover.Classes;

public enum WindowCompareTemplate
{
    [Display(Name = "Zgadza się", Description = "labels.equals")]
    Match,
    [Display(Name = "Zaczyna się", Description = "labels.beginsWith")]
    BeginsWith,
    [Display(Name = "Kończy się", Description = "labels.endsWith")]
    EndsWith,
    [Display(Name = "Zawiera", Description = "labels.contains")]
    Contains
}

public enum EditorMode
{
    [Display(Name = "Nowy", Description = "labels.new")]
    New,
    [Display(Name = "Modyfikuj", Description = "labels.edit")]
    Edit
}

public static class Enums
{
    public static string GetEnumDescription(Enum value)
    {
        DisplayAttribute? attribute = value.GetType().GetField(value.ToString())?.GetCustomAttribute<DisplayAttribute>(false);

        if (attribute?.Description is { } key)
            return JsonStringLocalizer.Instance.GetString(key, attribute.Name ?? value.ToString());
        else
            return value.ToString();
    }
}
