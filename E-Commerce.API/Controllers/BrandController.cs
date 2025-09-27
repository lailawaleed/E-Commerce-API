using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class BrandController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrandById(int id)
        {
            var brand = _unitOfWork.Repository<Brand>().Get(id);
            if (brand == null) return NotFound();
            return Ok(brand);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAllBrands()
        {
            var brands = _unitOfWork.Repository<Brand>().GetAll();
            return Ok(brands);
        }
        //Get all Product By BrandId
        [HttpGet("{id}/products")]
        public ActionResult<IEnumerable<Product>> GetProductsByBrandId(int id)
        {
            var brand = _unitOfWork.Repository<Brand>().Get(id);
            if (brand == null) return NotFound();
            var products = _unitOfWork.Repository<Product>().GetAll().Where(p => p.BrandId == id);
            return Ok(products);
        }
    }
}
