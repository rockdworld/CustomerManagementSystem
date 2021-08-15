using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Data
{
    public class CustomerContext : ICustomerContext
    {

        public CustomerContext(IConfiguration configuration)
        {
            var client = new MongoClient( configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Customers = database.GetCollection<Customer.API.Models.Customer>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CustomerContextSeed.SeedData(Customers);
        }

        public IMongoCollection<Models.Customer> Customers { get; }
    }
}
