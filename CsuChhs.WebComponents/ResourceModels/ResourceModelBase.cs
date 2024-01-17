namespace CsuChhs.WebComponents.ResourceModels
{
    public class ResourceModelBase
    {
        public ResourceModelBase()
        {
            DataGenerationDate = DateTime.Now;
        }

        public int ID { get; set; }
        public DateTime DataGenerationDate { get; set; }
    }
}
