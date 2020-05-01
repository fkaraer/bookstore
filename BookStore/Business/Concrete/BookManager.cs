using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        IAuthorDal _authorDal;
        IPublisherDal _publisherDal;

        public BookManager(IBookDal bookDal, IAuthorDal authorDal, IPublisherDal publisherDal)
        {
            _bookDal = bookDal;
            _authorDal = authorDal;
            _publisherDal = publisherDal;
        }

        public IDataResult<BookDto> CheckStock(int isbnNo)
        {
            try
            {
                var data = _bookDal.Get(s => s.Isbn.Equals(isbnNo));
                if (data != null)
                {
                    var dto = new BookDto
                    {
                        BookId = data.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), data.Format.ToString()),
                        Isbn = data.Isbn,
                        NextStockDate = data.NextStockDate,
                        Preface = data.Preface,
                        QuantityLeft = data.QuantityLeft,
                        ReleaseDate = data.ReleaseDate,
                        ValidIsbn = data.ValidIsbn,
                        Version = data.Version,
                        WarehouseLocation = data.WarehouseLocation
                    };
                    return new SuccessDataResult<BookDto>(dto);
                }
                else
                {
                    return new ErrorDataResult<BookDto>("Kayıt Bulunamadı!");
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<BookDto>("Servis yanıt alınamadı!");
            }
        }

        public IDataResult<List<BookDto>> CheckStock(List<int> isbnNumbers)
        {
            try
            {
                var data = _bookDal.GetList().Where(s => isbnNumbers.Contains(s.Isbn)).ToList();
                if (data != null)
                {
                    return new SuccessDataResult<List<BookDto>>(data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        ValidIsbn = p.ValidIsbn,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation
                    }).ToList());
                }
                else
                {
                    return new ErrorDataResult<List<BookDto>>("Kayıt Bulunamadı!");
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<BookDto>>("Servis yanıt alınamadı!");
            }
        }

        public IDataResult<List<BookDto>> GetAuthorBooks(int authorId)
        {
            try
            {
                var data = _bookDal.GetList(s => s.Author.Id.Equals(authorId)).ToList();
                if (data != null)
                {
                    return new SuccessDataResult<List<BookDto>>(data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        ValidIsbn = p.ValidIsbn,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation
                    }).ToList());
                }
                else
                {
                    return new ErrorDataResult<List<BookDto>>("Kayıt Bulunamadı!");
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<BookDto>>("Servis yanıt alınamadı!");
            }
        }

        public IDataResult<List<BookDto>> GetPublisherBooks(int publisherId)
        {
            try
            {
                var data = _bookDal.GetList(s => s.Publisher.Id.Equals(publisherId)).ToList();
                if (data != null)
                {
                    return new SuccessDataResult<List<BookDto>>(data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        ValidIsbn = p.ValidIsbn,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation
                    }).ToList());
                }
                else
                {
                    return new ErrorDataResult<List<BookDto>>("Kayıt Bulunamadı!");
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<BookDto>>("Servis yanıt alınamadı!");
            }
        }

        public IResult IsValidISBN(int isbnNo)
        {
            var isbnString = isbnNo.ToString();
            var isbnLength = isbnString.Length;
            if (isbnLength != 10)
            {
                return new ErrorResult(false, "Isbn numarası 10 haneli olmadır!");
            }
            var sum = 0;
            for (int i = 0; i < isbnLength; i++)
            {
                sum += isbnString[i];
            }
            if (sum % 2 == 0)
            {
                return new SuccessResult(true);
            }
            else
            {
                return new ErrorResult(false, "Geçersiz Isbn numarası!");
            }
        }

        public IResult AddBookToStock(BookDto data)
        {
            try
            {
                var publisher = _publisherDal.Get(s => s.Id.Equals(data.PublisherId));
                if (publisher == null)
                {
                    return new ErrorResult(false, "Geçersiz Publisher bilgisi!");
                }
                var author = _authorDal.Get(s => s.Id.Equals(data.AuthorId));
                if (author == null)
                {
                    return new ErrorResult(false, "Geçersiz Auther bilgisi!");
                }

                var bookReq = new Book
                {
                    Author = author,
                    Publisher = publisher,
                    Format = (byte)data.Format,
                    Isbn = data.Isbn,
                    NextStockDate = data.NextStockDate,
                    Preface = data.Preface,
                    QuantityLeft = data.QuantityLeft,
                    ReleaseDate = data.ReleaseDate,
                    ValidIsbn = data.ValidIsbn,
                    Version = data.Version,
                    WarehouseLocation = data.WarehouseLocation
                };
                _bookDal.Add(bookReq);
                return new SuccessResult(true);
            }
            catch (Exception)
            {
                return new ErrorResult(false, "Servis yanıt alınamadı!");
            }
        }
    }
}
