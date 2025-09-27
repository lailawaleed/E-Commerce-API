using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace E_Commerce.Infrastructure.DataSeed
{
    public class DataSeeding
    {
        public static void AddData(E_commerceContext e_CommerceContext)
        {
            if (e_CommerceContext.Brands.Count() == 0)
            {
                var brands = File.ReadAllText("../E-Commerce.Infrastructure/DataJson/brands.json");
                var result = JsonSerializer.Deserialize<List<Brand>>(brands);
                if (result == null || result.Count == 0) return;
                foreach (var brand in result)
                {
                    e_CommerceContext.Brands.Add(brand);
                }
            }
            e_CommerceContext.SaveChanges();
            if (e_CommerceContext.ProductTypes.Count() == 0)
            {
                var productTypes = File.ReadAllText("../E-Commerce.Infrastructure/DataJson/types.json");
                var productTypesResult = JsonSerializer.Deserialize<List<ProductType>>(productTypes);
                if (productTypesResult == null || productTypesResult.Count == 0) return;
                foreach (var category in productTypesResult)
                {
                    e_CommerceContext.ProductTypes.Add(category);
                }
            }
            e_CommerceContext.SaveChanges();
            if (e_CommerceContext.Products.Count() == 0)
            {
                var products = File.ReadAllText("../E-Commerce.Infrastructure/DataJson/products.json");
                var productResult = JsonSerializer.Deserialize<List<Product>>(products);
                if (productResult == null || productResult.Count == 0) return;
                foreach (var product in productResult)
                {
                    e_CommerceContext.Add(product);
                }
            }
            e_CommerceContext.SaveChanges();
        }
    }
}
