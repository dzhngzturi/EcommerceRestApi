using Ecommerce.Application.DTOs.Common;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Product
{
    public class ProductDto : BaseDto , IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrandDto ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
