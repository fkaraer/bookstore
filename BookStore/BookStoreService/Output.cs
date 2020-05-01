using Core.Entities.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace BookStoreService
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(PublisherDto))]
    [KnownType(typeof(BookDto))]
    [KnownType(typeof(AuthorDto))]
    public class Output<T>
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public T Data { get; set; }

    }
}
