namespace CsuChhs.WebComponents.ResourceModels
{
    public class PagedResourceListBase<T>
    {
        public PagedResourceListBase(int take,
            int page,
            int totalCollectionCount)
        {
            Items = new();
            CurrentPage = page;
            Take = take;
            Skip = (CurrentPage * take) - take;
        }

        public int CurrentPage { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public int TotalCollectionCount { get; set; }

        public int TotalPages => (TotalCollectionCount + Take - 1) / Take;
        List<T> Items { get; set; }
    }
}
