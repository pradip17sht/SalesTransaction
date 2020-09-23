using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model
{
    public class MvAccount
    {
    }
    public class MvLogin { 
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
