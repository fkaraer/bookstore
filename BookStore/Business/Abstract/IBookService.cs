using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<BookDto> CheckStock(int isbnNo);

        IDataResult<List<BookDto>> CheckStock(List<int> isbnNumbers);

        IResult IsValidISBN(int isbnNo);

        IResult AddBookToStock(BookDto data);

        IDataResult<List<BookDto>> GetAuthorBooks(int authorId);

        IDataResult<List<BookDto>> GetPublisherBooks(int publisherId);

    }
}
