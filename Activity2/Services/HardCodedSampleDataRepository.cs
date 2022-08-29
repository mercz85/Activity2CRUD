using Activity2.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2.Services
{
    //NOTES implement our IProductDataService interface
    public class HardCodedSampleDataRepository : IProductDataService
    {
        /* NOTES static keyword
         Statics are unique to the application domain, all users of that application domain will share the same value for each static property. When you see the word static, think "there will only be one instance of this." How long that instance lasts is a separate question, but the short answer is that it is variable.
         */
        static List<ProductModel> productsList = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            /**** NOTES decimal(0.00m) / fake data (bogus)****             

                To add a Decimal we use m => 5.99m

                To use FAKE data https://github.com/bchavez/Bogus
                we can install Bogus package from NuGet

            */
            if (productsList.Count == 0) 
            {
                productsList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "A square piece of plastic to make mousing easier" });
                productsList.Add(new ProductModel { Id = 2, Name = "Web Cam", Price = 45.50m, Description = "Enables you to attend more Zoom meetings." });
                productsList.Add(new ProductModel { Id = 3, Name = "4 TB USB hard drive", Price = 130.00m, Description = "Backup all of your work. You won't regret it." });
                productsList.Add(new ProductModel { Id = 4, Name = "Wireless Mouse", Price = 15.99m, Description = "Notebook mice don't work very well, do they?" });

                for (int i = 0; i < 100; i++)
                {
                    //Bogus fake data generation
                    productsList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }
 
            return productsList;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
