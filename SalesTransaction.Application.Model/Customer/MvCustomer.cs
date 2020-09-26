using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesTransaction.Application.Model.Customer
{
    public class MvCustomer
    {
        public int customerId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string middleName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string customerAddress { get; set; }
        [Required]
        public string emailId { get; set; }
        [Required]
        public int phoneNo { get; set; }
        [Required]
        public string district { get; set; }
        public int insertPersonId { get; set; }
    }

    public class MvEditCustomer
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

