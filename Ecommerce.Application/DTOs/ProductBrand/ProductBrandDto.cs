using Ecommerce.Application.DTOs.Common;

namespace Ecommerce.Application.DTOs.ProductBrand
{
    public class ProductBrandDto : BaseDto , IProductBrandDto
    {
        public string Name { get; set; }

    }
}