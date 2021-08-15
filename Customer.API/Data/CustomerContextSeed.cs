using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Data
{
    public class CustomerContextSeed
    {
        public static void SeedData(IMongoCollection<Models.Customer> CustomerCollection)
        {
            bool existProduct = CustomerCollection.Find(p => true).Any();
            if (!existProduct)
            {
                CustomerCollection.InsertManyAsync(GetPreconfiguredCustomers());
            }
        }

        private static IEnumerable<Models.Customer> GetPreconfiguredCustomers()
        {
            return new List<Models.Customer>()
            {
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Smith Jacob",
                    Phone = "001 230 454",
                    Address = "234 Street",
                    City = "NY",
                    Email = "SmithJacob@gmail.com"

                },
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Juile Richard",
                    Phone = "001 230 452",
                    Address = "100 Circle",
                    City = "Boston",
                    Email = "JuileRichard@gmail.com"

                },
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Nane N",
                    Phone = "001 230 664",
                    Address = "234 Tower",
                    City = "Downtown",
                    Email = "nanen@gmail.com"
                },
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Joe R",
                    Phone = "001 131 332",
                    Address = "234 Downtown",
                    City = "NY",
                    Email = "joer@gmail.com"
                },
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Nancy Roy",
                    Phone = "001 201 232",
                    Address = "001 002 322",
                    City = "NY",
                    Email = "nancyr@gmail.com"
                },
                new Models.Customer()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Harry Poter",
                    Phone = "001 230 333",
                    Address = "101 Main Town",
                    City = "NY",
                    Email = "harrypoter@gmail.com"
                }
            };
        }
    }
}
