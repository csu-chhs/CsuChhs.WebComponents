namespace CsuChhs.WebComponents.ResourceModels
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T items)
        {
            Items = items;
        }

        public T Items { get; set; }
    }
}
