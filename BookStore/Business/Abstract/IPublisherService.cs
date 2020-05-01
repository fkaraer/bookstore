using Core.Utilities.Results;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<List<PublisherDto>> GetPublishers();
    }
}
