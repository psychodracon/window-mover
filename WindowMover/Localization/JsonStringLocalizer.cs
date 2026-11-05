using System.Text.Json.Nodes;
using WindowMover.Localization.Extensions;

namespace WindowMover.Localization;

public class JsonStringLocalizer
{
    private static JsonStringLocalizer? _instance;
    public static JsonStringLocalizer Instance
    {
        get
        {
            if (_instance == null) { _instance = new JsonStringLocalizer(); }
            return _instance;
        }
    }

    private static JsonObject? current;
    private static string currentLanguage = "en-US";

    public void LoadTranslations(string? language)
    {
        currentLanguage = language != null ? language : "en-US";

        string? relativeFilePath = $"Resources/{currentLanguage}.json";
        var fullFilePath = Path.GetFullPath(relativeFilePath);
        if (File.Exists(fullFilePath))
        {
            string json = File.ReadAllText(fullFilePath);
            try
            {
                current = JsonObject.Parse(json)?.AsObject();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }

    public string GetCurrentLanguage() { return currentLanguage; }
    public List<Language> GetAvailableLanguages()
    {
        List<Language> result = new List<Language>();

        string? relativeFilePath = $"Resources/languages.json";
        var fullFilePath = Path.GetFullPath(relativeFilePath);
        if (File.Exists(fullFilePath))
        {
            string json = File.ReadAllText(fullFilePath);
            try
            {
                JsonArray languages = JsonObject.Parse(json)?.AsArray() ?? new JsonArray();

                foreach (JsonNode? node in languages)
                {
                    if (node is JsonObject language
                        && language.GetValue<string>("name") is { } name
                        && language.GetValue<string>("iso") is { } iso)
                    {
                        result.Add(new Language(name, iso));
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        return result;
    }

    public string? GetString(string key)
    {
        return current?.GetValue<string>(key);
    }

    public string GetString(string key, string defaultValue)
    {
        return current?.GetValue<string>(key) ?? defaultValue;
    }
}

public class Language
{
    public string Name { get; set; }
    public string Value { get; set; }

    public Language(string name, string value)
    {
        this.Name = name;
        this.Value = value;
    }
}
