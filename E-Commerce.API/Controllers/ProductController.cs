using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _unitOfWork.Repository<Product>().Get(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _unitOfWork.Repository<Product>().GetAll();
            return Ok(products);
        }
    }
}
