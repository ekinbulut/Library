using System.Collections.Generic;
using Library.Publisher.Data.Entities;

namespace Library.Publisher.Data.Repositories
{
    public interface IPublisherRepository
    {
        void Delete(string id);
        void Update(EPublisher entity);
        void Insert(EPublisher entity);
        IEnumerable<EPublisher> SelectAll();
        EPublisher Select(string id);
    }
}