using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IDataResult<List<AuthorDto>> GetAuthors()
        {
            try
            {
                var data = _authorDal.GetList();
                return new SuccessDataResult<List<AuthorDto>>(
                    data.Select(
                        p => new AuthorDto {
                        Id = p.Id,
                        Name = p.AuthorName
                        }
                    ).ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<AuthorDto>>("Servis yanıt alınamadı!");
            }
        }

    }
}
