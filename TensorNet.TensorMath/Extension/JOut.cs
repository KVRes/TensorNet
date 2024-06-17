using System.Text.Json;

namespace TensorNet.TensorMath.Extension;

public static class JOut
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        
    };
    public static string JObj<T>(this T v)
    {
        return JsonSerializer.Serialize(v, options: options);
    }
    
    public static void Output<T>(this T v)
    {
        Console.WriteLine(v.JObj());
    }
    
    
    public static void WriteLine<T>(T v)
    {
        Console.WriteLine(v.JObj());
    }
}