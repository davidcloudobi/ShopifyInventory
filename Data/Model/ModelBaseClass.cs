using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Model
{
  public class ModelBaseClass
    {
        [Key]
        public virtual Guid Id { get; set; }        
    }
}
