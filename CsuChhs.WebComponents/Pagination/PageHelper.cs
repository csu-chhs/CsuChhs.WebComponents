namespace CsuChhs.WebComponents.Pagination
{
    public static class PageHelper
    {
        public static int CalculateSkip(int page,
            int take)
        {
            return (page * take) - take;
        }

        public static int CalculateTotalPages(int totalCollectionCount,
            int take)
        {
            return (totalCollectionCount + take - 1) / take;
        }
    }
}
