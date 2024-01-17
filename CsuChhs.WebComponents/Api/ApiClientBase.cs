using System.Text.Json;

namespace CsuChhs.WebComponents.Api
{
    public class ApiClientBase
    {
        /// <summary>
        /// Deserializes a response that was executed
        /// via BadRequest();
        /// </summary>
        /// <param name="responseContent"></param>
        /// <returns></returns>
        public string? BuildErrorMessage(string responseContent)
        {
            return JsonSerializer.Deserialize<string>(responseContent);
        }
    }
}
