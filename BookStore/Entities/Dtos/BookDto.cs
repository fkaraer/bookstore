using Core.Entities.Concrete;
using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Entities.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public int Isbn { get; set; }
        public bool ValidIsbn { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Version { get; set; }
        public string Preface { get; set; }
        public int QuantityLeft { get; set; }
        public string WarehouseLocation { get; set; }
        public DateTime NextStockDate { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public Format Format { get; set; }

        public void Validate()
        {
            var warehouseLocationControl = Regex.IsMatch(WarehouseLocation, @"^[0-9]{3}$");
            if (!warehouseLocationControl)
            {
                throw new ApplicationServiceException("invalid-value", "invalid WarehouseLocation, WarehouseLocation has [001-999]!");
            }

            if (AuthorId == 0)
            {
                throw new ApplicationServiceException("invalid-value", "invalid Author!");
            }

            if (PublisherId == 0)
            {
                throw new ApplicationServiceException("invalid-value", "invalid Publisher!");
            }
        }

    }

    public enum Format
    {
        Digital,
        Print,
        Both
    }
}
