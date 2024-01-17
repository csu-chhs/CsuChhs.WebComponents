namespace CsuChhs.WebComponents.Api.Exceptions
{
    public class InvalidInputException : Exception 
    {
        public InvalidInputException() : base()
        {

        }

        public InvalidInputException(string message) : base(message)
        {

        }

        public InvalidInputException(string message, Exception? inner) : base(message, inner)
        {
            
        }
    }
}