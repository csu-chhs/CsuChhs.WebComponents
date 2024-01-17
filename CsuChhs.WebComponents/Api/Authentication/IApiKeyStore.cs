namespace CsuChhs.WebComponents.Api.Authentication
{
    public interface IApiKeyStore
    {
        string GetKey();

        string GetWriteKey()
        {
            return string.Empty;
        }
    }
}
