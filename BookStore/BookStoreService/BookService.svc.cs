using BookStoreService.Extension;
using Business.Concrete;
using Core.Entities.Concrete;
//using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookStoreService
{

    [CustomServiceBehavior]
    public class BookService : IBookService
    {

        private readonly BookManager bookManager;
        private readonly AuthorManager authorManager;
        private readonly PublisherManager publisherManager;

        public BookService()
        {
            var efBookDal = new EfBookDal();
            var efAutherDal = new EfAuthorDal();
            var efPublisherDal = new EfPublisherDal();
            bookManager = new BookManager(efBookDal, efAutherDal, efPublisherDal);
            authorManager = new AuthorManager(efAutherDal);
            publisherManager = new PublisherManager(efPublisherDal);
        }

        public Output<List<PublisherDto>> GetPublishers()
        {
            var output = new Output<List<PublisherDto>>();
            try
            {
                var data = publisherManager.GetPublishers();
                output.Data = data.Data;
                output.IsSuccess = data.IsSuccess;
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public Output<BookDto> AddBookToStock(BookDto data)
        {
            var output = new Output<BookDto>();
            try
            {
                data.Validate();
                var isValidIsbn = bookManager.IsValidISBN(data.Isbn);
                if (!isValidIsbn.IsSuccess)
                {
                    output.Data = data;
                    output.IsSuccess = false;
                    output.Message = "Invalid isbn no!";
                    return output;
                }
                var stock = bookManager.AddBookToStock(data);
                output.Data = data;
                output.IsSuccess = stock.IsSuccess;
            }
            catch (ApplicationServiceException e)
            {
                output.Data = data;
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public OutputBase IsValidISBN(int isbnNo)
        {
            var output = new OutputBase();
            try
            {
                var isValidIsbn = bookManager.IsValidISBN(isbnNo);
                output.IsSuccess = isValidIsbn.IsSuccess;
                output.Message = isValidIsbn.Message;
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public Output<List<BookDto>> GetPublisherBooks(int publisherId)
        {
            var output = new Output<List<BookDto>>();
            try
            {
                var data = bookManager.GetPublisherBooks(publisherId);
                output.IsSuccess = data.IsSuccess;
                if (data.Data != null)
                {
                    output.Data = data.Data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation,
                    }).ToList();
                }
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }



        public Output<List<BookDto>> GetAuthorBooks(int authorId)
        {
            var output = new Output<List<BookDto>>();
            try
            {
                var data = bookManager.GetAuthorBooks(authorId);
                output.IsSuccess = data.IsSuccess;
                if (data.Data != null)
                {
                    output.Data = data.Data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation,
                    }).ToList();
                }
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public Output<List<AuthorDto>> GetAuthors()
        {
            var output = new Output<List<AuthorDto>>();
            try
            {
                var data = authorManager.GetAuthors();
                output.Data = data.Data;
                output.IsSuccess = data.IsSuccess;
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public Output<List<BookDto>> CheckStock(List<int> isbnNumbers)
        {
            var output = new Output<List<BookDto>>();
            try
            {
                var data = bookManager.CheckStock(isbnNumbers);
                output.IsSuccess = data.IsSuccess;
                if (data.Data != null)
                {
                    output.Data = data.Data.Select(p => new BookDto
                    {
                        BookId = p.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), p.Format.ToString()),
                        Isbn = p.Isbn,
                        NextStockDate = p.NextStockDate,
                        Preface = p.Preface,
                        QuantityLeft = p.QuantityLeft,
                        ReleaseDate = p.ReleaseDate,
                        Version = p.Version,
                        WarehouseLocation = p.WarehouseLocation,
                    }).ToList();
                }
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

        public Output<BookDto> CheckStock(int isbnNo)
        {
            var output = new Output<BookDto>();
            try
            {
                var data = bookManager.CheckStock(isbnNo);
                output.IsSuccess = data.IsSuccess;
                if (data.Data != null)
                {
                    output.Data = new BookDto
                    {
                        BookId = data.Data.BookId,
                        Format = (Format)Enum.Parse(typeof(Format), data.Data.Format.ToString()),
                        Isbn = data.Data.Isbn,
                        NextStockDate = data.Data.NextStockDate,
                        Preface = data.Data.Preface,
                        QuantityLeft = data.Data.QuantityLeft,
                        ReleaseDate = data.Data.ReleaseDate,
                        Version = data.Data.Version,
                        WarehouseLocation = data.Data.WarehouseLocation,
                    };
                }
            }
            catch (ApplicationServiceException e)
            {
                output.IsSuccess = false;
                output.Message = e.Description;
            }
            return output;
        }

       
    }
}
