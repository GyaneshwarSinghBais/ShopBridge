using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly Shopbridge_Context _dbContext;

        public ProductService(ILogger<ProductService> logger, Shopbridge_Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var productDetail = _dbContext.Product.FirstOrDefault(x => x.Product_Id == id);     
                _dbContext.Product.Remove(productDetail);

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Delete", ex);
                return 0;
            }

        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            try
            { 
            return await _dbContext.Product.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Find All", ex);
                return null;
            }

        }

        public async Task<Product> FindOne(int id)
        {
            try
            {
                return await _dbContext.Product.FirstOrDefaultAsync(x => x.Product_Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Findone", ex);
                return null;
            }
        }

        public async Task<int> Insert(Product product)
        {
            try
            {
                _dbContext.Add(product);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Insert", ex);
                return 0;
            }
        }

        public async Task<int> Update(Product product)
        {
            try
            {
                var productDetail = _dbContext.Product.FirstOrDefault(x => x.Product_Id == product.Product_Id);
                productDetail.Product_Id = product.Product_Id;
                productDetail.Description = product.Description;
                productDetail.Price = product.Price;
                productDetail.Code = product.Code;
                productDetail.Stock_Quantity = product.Stock_Quantity;
                productDetail.Name = product.Name;

                _dbContext.Update(productDetail);               
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in Update", ex);
                return 0;
            }
        }
    }


}

