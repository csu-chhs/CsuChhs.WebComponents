namespace CsuChhs.WebComponents.ResourceModels
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

        public PagedResponse(T items, int pageNumber, int pageSize)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
