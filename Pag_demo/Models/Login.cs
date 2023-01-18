using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pag_demo.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]


        [Required(ErrorMessage = "UserName cannot be empty")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        
        public string RememberMe { get; set; }
    }
}