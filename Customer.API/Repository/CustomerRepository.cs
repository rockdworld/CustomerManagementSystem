using Customer.API.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        ICustomerContext context;

        public CustomerRepository(ICustomerContext context)
        {
            this.context = context;
        }
        public void AddCustomer(Models.Customer Customer)
        {
            context.Customers.InsertOne(Customer);
        }

        public async Task<bool> DeleteCustomer(string Id)
        {
            var Filter = Builders<Models.Customer>.Filter.Eq("Id", Id);

            var DeleteResult = await context.Customers
                                    .DeleteOneAsync(Filter);


            return DeleteResult.IsAcknowledged && DeleteResult.DeletedCount > 0;

        }

        public async Task<Models.Customer> GetCustomer(string Id)
        {
            var customer = await context.Customers
                        .Find(c => c.Id == Id)
                        .FirstOrDefaultAsync<Models.Customer>();

            return customer;
        }

        public async Task<IEnumerable<Models.Customer>> GetCustomerByName(string Name)
        {
            var filter = Builders<Models.Customer>.Filter.Eq("Name", Name);

            var customers = await context.Customers
                                            .Find(filter)
                                            .ToListAsync<Models.Customer>();

            return customers;

        }

        public async Task<IEnumerable<Models.Customer>> GetCustomers()
        {
            var customers = await context.Customers
                                            .Find(c => true)
                                            .ToListAsync<Models.Customer>();

            return customers;
        }

        public async Task<bool> UpdateCustomer(Models.Customer Customer)
        {
            var UpdateResult = await context.Customers
                                                .ReplaceOneAsync(filter: g => g.Id == Customer.Id, replacement: Customer);

            return UpdateResult.IsAcknowledged && UpdateResult.ModifiedCount > 0;


        }
    }
}
