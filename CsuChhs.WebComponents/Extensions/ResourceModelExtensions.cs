using System.Text.Json;
using CsuChhs.WebComponents.ResourceModels;

namespace CsuChhs.WebComponents.Extensions;

public static class ResourceModelExtensions
{
    public static string SerializeObject(this ResourceModelBase resourceModelBase)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(resourceModelBase,
            options);
    }
}