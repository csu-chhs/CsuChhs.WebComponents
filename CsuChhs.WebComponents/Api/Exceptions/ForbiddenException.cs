namespace CsuChhs.WebComponents.Api.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base() 
        {
        
        }

        public ForbiddenException(string message) : base(message)
        {

        }

        public ForbiddenException(string message, Exception? inner) : base(message, inner)
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
    }
}
