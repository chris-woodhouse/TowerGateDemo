using System.Collections.Generic;
using Tower_Gate.Models;

namespace Tower_Gate.Services
{
    public interface ICustomerOperations
    {
        bool CreateCustomer( Customer cust);
        List<Customer> GetAllCustomers();
        List<Customer> GetCustomerById(int id);
        bool UpdateCustomerDetails(Customer cust);
    }
}