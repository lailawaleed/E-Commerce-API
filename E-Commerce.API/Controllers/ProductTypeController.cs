using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class ProductTypeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductType> GetProductTypeById(int id)
        {
            var productType = _unitOfWork.Repository<ProductType>().Get(id);
            if (productType == null) return NotFound();
            return Ok(productType);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductType>> GetAllProductTypes()
        {
            var productTypes = _unitOfWork.Repository<ProductType>().GetAll();
            return Ok(productTypes);
        }

        //Get All Product By Type Id
        [HttpGet("{id}/products")]
        public ActionResult<IEnumerable<Product>> GetProductsByTypeId(int id)
        {
            var productType = _unitOfWork.Repository<ProductType>().Get(id);
            if (productType == null) return NotFound();
            var products = _unitOfWork.Repository<Product>().GetAll().Where(p => p.TypeId == id);
            return Ok(products);
        }

    }
}
