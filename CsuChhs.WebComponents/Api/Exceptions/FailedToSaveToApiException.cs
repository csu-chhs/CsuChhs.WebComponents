using System.Text.Json;

namespace CsuChhs.WebComponents.Api.Exceptions
{
    public class FailedToSaveToApiException : Exception
    {
        public FailedToSaveToApiException() : base()
        {

        }

        public FailedToSaveToApiException(string message) : base(message)
        {

        }

        public FailedToSaveToApiException(string message, Exception? inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Add a data object for the web trace.
        /// </summary>
        /// <param name="webStackTrace"></param>
        public void AddWebTrace(string? webStackTrace)
        {
            if (!string.IsNullOrEmpty(webStackTrace))
            {
                Data.Add("Web API Response", webStackTrace);
            }
        }

        /// <summary>
        /// Add the resource model for this trace.
        /// </summary>
        /// <param name="resourceModel"></param>
        public void AddResourceModel(object? resourceModel)
        {
            if (resourceModel != null)
            {
                Data.Add("Resource Model", JsonSerializer.Serialize(resourceModel));
            }
        }
    }
}
