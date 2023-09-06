using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace IndataCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
       

        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpGet]
        public List<Product> Get()
        {
            var claims = _httpContextAccessor.HttpContext.User?.Claims?.ToList();
      
            return _productService.GetAllProducts();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _productService.CreateProduct(product);
        }

        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _productService.DeleteProduct(id);
        }

    }
}
