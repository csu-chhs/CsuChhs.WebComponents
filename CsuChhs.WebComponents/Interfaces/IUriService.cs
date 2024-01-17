using CsuChhs.WebComponents.Filters;

namespace CsuChhs.WebComponents.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
