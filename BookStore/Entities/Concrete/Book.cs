using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        [Key]
        public int BookId { get; set; }
        public int Isbn { get; set; }

        public bool ValidIsbn { get; set; }

        public byte Format { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public string Preface { get; set; }

        public int QuantityLeft { get; set; }

        public string WarehouseLocation { get; set; }

        public DateTime NextStockDate { get; set; }

        public virtual Author Author{ get; set; }

        public virtual Publisher Publisher{ get; set; }
    }
}
