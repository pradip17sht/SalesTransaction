using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTransaction.Application.Model
{
    public class MvAccount
    {
    }
    public class MvLogin { 
        public int UserID { get; set; }
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
