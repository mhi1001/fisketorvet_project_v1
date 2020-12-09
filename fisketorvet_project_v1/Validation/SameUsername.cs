using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;

namespace fisketorvet_project_v1.Validation
{
    public class SameUsername : ValidationAttribute 
    {
        private CustomerCatalog _customerCatalog = new CustomerCatalog();
        private Dictionary<int, Customer> _customers;
        public string Username { get; set; }
        

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                _customers = _customerCatalog.GetAllCustomers();
                foreach (Customer customer in _customers.Values)
                {
                    if (customer.UserName.ToLower() == strValue.ToLower())
                    {
                        return false;
                    }
                        
                }
            }

            return true;
        }
    }
}
