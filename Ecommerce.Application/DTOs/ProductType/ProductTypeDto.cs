using Ecommerce.Application.DTOs.Common;

namespace Ecommerce.Application.DTOs.ProductType
{
    public class ProductTypeDto : BaseDto, IProductTypeDto
    {
        public string Name { get; set; }

    }
}