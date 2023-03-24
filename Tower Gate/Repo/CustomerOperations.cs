using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tower_Gate.Models;

namespace Tower_Gate.Services
{
    public class CustomerOperations : ICustomerOperations
    {

        static IList<Customer> customerlist = new List<Customer>{
                new Customer() {Id = 1, Name = "Jane Smith", Age = 33, PostCode = "TR15 1NA", Height = 5.7 },
                new Customer() {Id = 2, Name = "Edward Reed", Age = 34, PostCode = "PT15 P2A", Height = 6.0 },
                new Customer() {Id = 3, Name = "Sam Brown", Age = 54, PostCode = "CU15 RNA", Height = 5.4 },
                new Customer() {Id = 4, Name = "Katy Withers", Age = 37, PostCode = "Ab1 DNA", Height = 5.8 },
            };

        public List<Customer> GetAllCustomers()
        {

            return (List<Customer>)customerlist;
        }

        public List<Customer> GetCustomerById(int id)
        {
                var record = customerlist.FirstOrDefault(b => b.Id == id);
                var result = new List<Customer>();
                result.Add(record);
                return result;
        }

        public bool UpdateCustomerDetails(Customer cust)
        {
            foreach (Customer customer in customerlist)
            {
                if (customer.Id == cust.Id)
                {
                    customer.Name = cust.Name;
                    customer.Age = cust.Age;
                    customer.PostCode = cust.PostCode;
                    customer.Height = cust.Height;
                };
            };

      
            
            return true;
        }

        public bool CreateCustomer(Customer cust)
        {
            cust.Id = customerlist.Count + 1;
            customerlist.Add(cust);
            return true;
        }

    }
}
