using System.Reflection;
using System.Text.Json;

namespace WindowMover.Classes;

public static class Helpers
{
    public static int[] ConvertKeys(Keys keyData)
    {
        int modifiers = 0;
        if (keyData.HasFlag(Keys.Alt))
            modifiers |= 1;
        if (keyData.HasFlag(Keys.Control))
            modifiers |= 2;
        if (keyData.HasFlag(Keys.Shift))
            modifiers |= 4;

        int keys = (int)keyData;
        keys &= ~(int)Keys.Alt;
        keys &= ~(int)Keys.Control;
        keys &= ~(int)Keys.Shift;

        return new int[] { keys, modifiers };
    }
    public static T? GetPropertyValue<T>(object obj, string propName)
    {
        return (T?)obj.GetType().GetProperty(propName)?.GetValue(obj, null);
    }

    public static void SetPropertyValue<T>(object obj, string propName, T value)
    {
        obj.GetType().GetProperty(propName)?.SetValue(obj, value);
    }
    public static byte[] ObjectToByteArray(Object obj)
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj);
    }

    // Convert a byte array to an Object
    public static T? ByteArrayToObject<T>(byte[]? arrayOfBytes)
    {
        if (arrayOfBytes != null)
        {
            return JsonSerializer.Deserialize<T>(arrayOfBytes);
        }
        else
            return default;
    }

    public static Stream GenerateStreamFromByteArray(byte[] s)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    //Convert a byte array to a File
    public static bool ByteArrayToFile(string fileName, byte[] arrayOfBytes)
    {
        try
        {
            // Open file for reading
            FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            fileStream.Write(arrayOfBytes, 0, arrayOfBytes.Length);
            fileStream.Close();

            return true;
        }
        catch (Exception exp)
        {
            Console.WriteLine("Błąd podczas zapisu pliku: {0}", exp.ToString());
        }

        return false;
    }

    //Convert a byte array to a File
    public static byte[]? FileToByteArray(string fileName)
    {
        try
        {
            return File.ReadAllBytes(fileName);
        }
        catch (Exception exp)
        {
            Console.WriteLine("Błąd podczas otwierania pliku: {0}", exp.ToString());
        }

        return null;
    }

    public static void CopyProperties(this WindowHandler destination, WindowHandler source)
    {
        // Iterate the Properties of the destination instance and  
        // populate them from their source counterparts  
        PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
        foreach (PropertyInfo destinationPi in destinationProperties)
        {
            destinationPi.SetValue(destination, destinationPi.GetValue(source, null), null);
        }
    }

    public static T DeepCopy<T>(T input)
    {
        var jsonString = JsonSerializer.Serialize(input);
        return JsonSerializer.Deserialize<T>(jsonString) ?? throw new InvalidOperationException("Deep copy produced null.");
    }

    public static string GetSettingsPath()
    {
#if DEBUG
        return AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar);
#else
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WindowMover");
#endif
    }
}
