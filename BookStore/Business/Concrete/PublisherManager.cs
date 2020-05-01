using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IDataResult<List<PublisherDto>> GetPublishers()
        {
            try
            {
                var data = _publisherDal.GetList();
                var dto = data.Select(p => new PublisherDto
                {
                    Id = p.Id,
                    Name = p.PublisherName
                }).ToList();
                return new SuccessDataResult<List<PublisherDto>>(dto);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<PublisherDto>>("Servis yanıt alınamadı!");
            }
        }
       
    }
}
