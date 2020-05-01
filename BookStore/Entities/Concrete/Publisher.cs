using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [DataContract]
    public class Publisher : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new Collection<Book>();
        }
    }
}
