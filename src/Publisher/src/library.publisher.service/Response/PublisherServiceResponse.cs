using System.Collections.Generic;
using System.Linq;
using Library.Publisher.Service.ServiceModel;

namespace Library.Publisher.Service.Response
{
    public class PublisherServiceResponse
    {
        public IEnumerable<PublisherServiceModel> Publishers { get; set; } = new List<PublisherServiceModel>();
        
        public int Total => Publishers.Count();

    }
}