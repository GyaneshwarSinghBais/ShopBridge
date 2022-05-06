using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService , ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return Ok(await _productService.FindAll());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          
            var result = await _productService.FindOne(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
         
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (product.Product_Id == null || product.Product_Id <= 0)
            {
                return BadRequest("Id should be set for insert action.");
            }

            if (product.Product_Id != id)
            {
                return BadRequest("Id not match with object id");
            }

            bool isExist = await ProductExists(id);

            if (!isExist)
            {
                return NotFound();
            }

            var result = await _productService.Update(product);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product.Product_Id != 0 )
            {
                return BadRequest("Id cannot be set for insert action.");
            }


            var result = await _productService.Insert(product);
            if (!string.IsNullOrEmpty(result.ToString().Trim()))
                return Ok();
            else
                return BadRequest();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool isExist = await ProductExists(id);
            if (!isExist)
            {
                return NotFound();
            }

            var result = await _productService.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        private async Task<bool> ProductExists(int id)
        {
            var res = await _productService.FindOne(id);
            if (res != default)
                return true;
            else
                return false;
        }

        //private bool ProductExists(int id)
        //{
        //    var res =  _productService.FindOne(id);
        //    if (res != default)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
