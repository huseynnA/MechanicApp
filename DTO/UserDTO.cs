using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum UserSortOrder
    {
        NameAsc,
        NameDesc,
    }


    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Min length is 5!")]
        public string Username { get; set; }
        public string? Salt { get; set; }

        public string? PasswordHash { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "Min length is 8!")]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
