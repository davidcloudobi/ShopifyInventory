using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Data.Model.Identity
{
  public  class ApplicationRole: IdentityRole
  {
      [Required(ErrorMessage = "Specify if the role is active or inactive")]
      public bool IsActive { get; set; } = true;

  }
}
