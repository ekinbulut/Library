using System.Diagnostics.CodeAnalysis;

namespace Library.Publisher.Service.Requests
{
    [ExcludeFromCodeCoverage]
    public class GetPublisherHttpRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}