using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> FindAll();
        public Task<int> Insert(Product product);
        public Task<int> Delete(int id);
        public Task<Product> FindOne(int id);
        public Task<int> Update(Product product);
    }
}
