namespace CsuChhs.WebComponents.ResourceModels
{
    public interface IPagedResource<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } 
    }
}
