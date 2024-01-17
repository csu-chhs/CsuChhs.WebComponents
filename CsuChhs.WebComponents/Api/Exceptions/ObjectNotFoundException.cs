namespace CsuChhs.WebComponents.Api.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base()
        {

        }

        public ObjectNotFoundException(string message) : base(message)
        {

        }

        public ObjectNotFoundException(string message, Exception? inner) : base(message, inner)
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
