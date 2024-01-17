using CsuChhs.WebComponents.Filters;
using CsuChhs.WebComponents.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace CsuChhs.WebComponents.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter,
            string route)
        {
            var endPointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri =
                QueryHelpers.AddQueryString(endPointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
