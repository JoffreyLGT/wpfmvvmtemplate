using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.Business.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int? Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(){}

        public Customer(Customer toCopy)
        {
            if (toCopy == null) return;
            Id = toCopy.Id;
            Reference = toCopy.Reference;
            FirstName = toCopy.FirstName;
            LastName = toCopy.LastName;
        }

        /// <summary>
        /// Copy the content of the provided customer to this instance.
        /// </summary>
        /// <param name="customerToCopy"></param>
        public void CopyFromCustomer(Customer customerToCopy)
        {
            if (customerToCopy == null) return;
            Id = customerToCopy.Id;
            Reference = customerToCopy.Reference;
            FirstName = customerToCopy.FirstName;
            LastName = customerToCopy.LastName;
        }
    }
}
