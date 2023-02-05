using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Library.Publisher.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class PutPublisherHttpRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Series { get; set; }
    }
}