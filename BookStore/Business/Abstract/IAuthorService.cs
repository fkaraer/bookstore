using Core.Utilities.Results;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<AuthorDto>> GetAuthors();
    }
}
