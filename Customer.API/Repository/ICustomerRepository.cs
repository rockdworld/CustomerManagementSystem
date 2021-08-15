using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.API;

namespace Customer.API.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Models.Customer>> GetCustomers();
        Task<Models.Customer> GetCustomer(string Id);
        Task<IEnumerable<Models.Customer>> GetCustomerByName(string Name);
        void AddCustomer(Models.Customer Customer);
        Task<bool> UpdateCustomer(Models.Customer Customer);
        Task<bool> DeleteCustomer(string Id);
    }
}
