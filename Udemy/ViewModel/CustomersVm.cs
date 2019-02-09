using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy.Models;

namespace Udemy.ViewModel
{
    public class CustomersVm
    {
        public List<Customer> lstCustomers { get; set; } = new List<Customer>();
    }
}