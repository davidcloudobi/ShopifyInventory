using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Request
{
  public  class UserRequest
    { 
        [Required(ErrorMessage = "Username must not be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Username must not be empty")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Username must not be empty")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        public string PictureURL { get; set; }
        [Required(ErrorMessage = "Password must not be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role must not be empty")]
        public string  Role { get; set; }
        [Required(ErrorMessage = "Outlet Id  must not be empty")]
        public List<Guid> OutletId { get; set; }
    }
}
