﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
