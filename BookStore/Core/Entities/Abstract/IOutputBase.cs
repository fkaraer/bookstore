using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IOutputBase
    {
        bool IsSuccess { get; }

        string Message { get; }
    }
}
