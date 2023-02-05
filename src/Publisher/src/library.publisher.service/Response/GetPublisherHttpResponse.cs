using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Library.Publisher.Service.Response
{
    [ExcludeFromCodeCoverage]
    public class GetPublisherHttpResponse
    {
        public int Total { get; set; }
        public IEnumerable<object> PublisherCollection { get; set; }
    }
}