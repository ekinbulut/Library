namespace Library.Publisher.Service.Requests
{
    public class UpdatePublisherServiceRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Series { get; set; }
    }
}