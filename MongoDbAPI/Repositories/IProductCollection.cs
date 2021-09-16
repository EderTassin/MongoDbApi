using MongoDbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbAPI.Repositories
{
    public interface IProductCollection
    {

        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(string id);

    }
}
