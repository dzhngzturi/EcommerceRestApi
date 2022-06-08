using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductBrand
{
    public class CreateProductBrandDto : IProductBrandDto
    {
        public string Name { get; set; }
    }
}
