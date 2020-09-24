using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.Customer
{
    class MvCustomer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string District { get; set; }
        public int InsertPersonId { get; set; }
    }
}

