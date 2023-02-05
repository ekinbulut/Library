using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Library.Publisher.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class PostPublisherHttpRequest
    {
        public string Name { get; set; }
        public List<string> Series { get; set; }
    }
}