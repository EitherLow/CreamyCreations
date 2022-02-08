using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class UserRoleVM
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
