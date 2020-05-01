using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ApplicationServiceException : Exception
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ApplicationServiceException() { }
        public ApplicationServiceException(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Code, this.Description);
        }
    }
}
