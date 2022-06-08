using Ecommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductBrand
{
    public class UpdateProductBrandDto : BaseDto , IProductBrandDto
    {
        public string Name { get; set; }
    }
}
