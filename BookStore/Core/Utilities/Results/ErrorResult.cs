using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool isSuccess) : base(false)
        {
        }

        public ErrorResult(bool isSuccess, string message) : base(false, message)
        {
        }
    }
}
