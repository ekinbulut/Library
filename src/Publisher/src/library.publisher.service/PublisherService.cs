using System;
using System.Collections.Generic;
using System.Linq;
using Library.Publisher.Data;
using Library.Publisher.Data.Entities;
using Library.Publisher.Data.Repositories;
using Library.Publisher.Service.Requests;
using Library.Publisher.Service.Response;
using Library.Publisher.Service.ServiceModel;

namespace Library.Publisher.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public PublisherServiceResponse SelectAll(int requestOffset, int requestLimit)
        {
            var storage = _publisherRepository.SelectAll()?.Skip(requestOffset).Take(requestLimit);

            if (storage == null) return new PublisherServiceResponse();

            return new PublisherServiceResponse
                   {
                       Publishers = storage.SelectMany(t => new List<PublisherServiceModel>
                                                          {
                                                              new PublisherServiceModel
                                                              {
                                                                  Id = t.Id, 
                                                                  Name = t.Name, 
                                                                  Series = t.Series
                                                              }
                                                          })
                   };
        }

        public PublisherServiceResponse Select(string id)
        {
            var publisher = _publisherRepository.Select(id);

            if (publisher == null) return new PublisherServiceResponse();

            return new PublisherServiceResponse
                   {
                       Publishers = new List<PublisherServiceModel>
                                  {
                                      new PublisherServiceModel
                                      {
                                          Id = publisher.Id, 
                                          Name = publisher.Name, 
                                          Series = publisher.Series
                                      }
                                  }
                   };
        }

        public void InsertPublisher(InsertPublisherServiceRequest request)
        {
            var entity = new EPublisher
                         {
                             Name = request.Name, 
                             Series = request.Series, 
                             CreateDateTime = DateTime.Now,
                             UpdateDateTime = null
                         };
            _publisherRepository.Insert(entity);
        }

        public void UpdatePublisher(UpdatePublisherServiceRequest request)
        {
            var entity = new EPublisher
                         {
                             Id = request.Id, 
                             Name = request.Name, 
                             Series = request.Series,
                             UpdateDateTime = DateTime.Now
                         };

            _publisherRepository.Update(entity);
        }

        public void DeletePublisher(string id)
        {
            _publisherRepository.Delete(id);
        }
    }
}