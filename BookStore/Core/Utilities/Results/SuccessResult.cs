﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool isSuccess) : base(true)
        {
        }

        public SuccessResult(bool isSuccess, string message) : base(true, message)
        {
        }
    }
}
