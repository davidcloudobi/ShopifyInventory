﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Request
{
  public  class BrandRequest
    {
        [Required(ErrorMessage = "Name must not be empty")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
