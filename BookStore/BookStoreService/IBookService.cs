//using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookStoreService
{
	[ServiceContract]
	public interface IBookService
	{
		[OperationContract]
		Output<List<PublisherDto>> GetPublishers();

		[OperationContract]
		Output<BookDto> AddBookToStock(BookDto data);

		[OperationContract]
		OutputBase IsValidISBN(int isbnNo);

		[OperationContract]
		Output<List<BookDto>> GetPublisherBooks(int publisherId);

		[OperationContract]
		Output<List<BookDto>> GetAuthorBooks(int authorId);

		[OperationContract]
		Output<List<AuthorDto>> GetAuthors();

		[OperationContract(Name = "CheckStockByIsbnNumbers")]
		Output<List<BookDto>> CheckStock(List<int> isbnNumbers);

		[OperationContract(Name = "CheckStockByIsbnNo")]
		Output<BookDto> CheckStock(int isbnNo);

	
	}
}
