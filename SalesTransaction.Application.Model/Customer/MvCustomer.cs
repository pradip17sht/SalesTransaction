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
}

