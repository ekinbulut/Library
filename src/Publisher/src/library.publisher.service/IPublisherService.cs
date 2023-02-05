using Library.Publisher.Service.Requests;
using Library.Publisher.Service.Response;

namespace Library.Publisher.Service
{
    public interface IPublisherService
    {
        PublisherServiceResponse SelectAll(int requestOffset, int requestLimit);
        PublisherServiceResponse Select(string id);
        void InsertPublisher(InsertPublisherServiceRequest request);
        void UpdatePublisher(UpdatePublisherServiceRequest request);
        void DeletePublisher(string id);
    }
}