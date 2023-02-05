using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Library.Publisher.Service;
using Library.Publisher.Service.Requests;
using Library.Publisher.Service.Response;
using Microsoft.AspNetCore.Mvc;

namespace Library.Publisher.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetPublisherHttpResponse), (int) HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] GetPublisherHttpRequest request)
        {
            var serviceResponse = _publisherService.SelectAll(request.Offset, request.Limit);

            var response = new GetPublisherHttpResponse
                           {
                               Total = serviceResponse.Total, PublisherCollection =
                                   serviceResponse.Publishers.SelectMany(
                                       publisher => new List<object>
                                                    {
                                                        new
                                                        {
                                                            publisher.Id, publisher.Name, publisher.Series
                                                        }
                                                    })
                           };

            return StatusCode((int) HttpStatusCode.OK, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetPublisherHttpResponse), (int) HttpStatusCode.OK)]
        public IActionResult Get([FromRoute] string id)
        {
            var serviceResponse = _publisherService.Select(id);

            var response = new GetPublisherHttpResponse
                           {
                               Total = serviceResponse.Total, PublisherCollection =
                                   serviceResponse.Publishers.SelectMany(
                                       publisher => new List<object>
                                                    {
                                                        new
                                                        {
                                                            publisher.Id, publisher.Name, publisher.Series
                                                        }
                                                    })
                           };

            return StatusCode((int) HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        public IActionResult Post([FromBody] PostPublisherHttpRequest request)
        {
            _publisherService.InsertPublisher(new InsertPublisherServiceRequest()
                                              {
                                                  Name = request.Name, Series = request.Series.ToArray()
                                              });

            return StatusCode((int) HttpStatusCode.Created);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        public IActionResult Put([FromRoute] string id, [FromBody] PutPublisherHttpRequest request)
        {
            _publisherService.UpdatePublisher(new  UpdatePublisherServiceRequest()
                                          {
                                              Id = id, Name = request.Name,
                                              Series = request.Series.ToArray()
                                          });

            return StatusCode((int) HttpStatusCode.Accepted);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public IActionResult Delete([FromRoute] string id)
        {
            _publisherService.DeletePublisher(id);

            return StatusCode((int) HttpStatusCode.OK);
        }
    }
}