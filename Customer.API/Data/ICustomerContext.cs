using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.API.Models;

namespace Customer.API.Data
{
    public interface ICustomerContext
    {
        public IMongoCollection<Customer.API.Models.Customer> Customers { get; }
    }
}
